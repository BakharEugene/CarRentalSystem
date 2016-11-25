using CarRentalSystem.DAL.EF;
using CarRentalSystem.DAL.Models;
using CarRentalSystem.DAL.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CarRentalSystem.Controllers
{
    public class AccountController : Controller
    {
        UnitOfWork unit = new UnitOfWork();

        public ActionResult Login()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {          
            return View(unit.Users.GetAll().ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
                User user = null;
                using (CarRentalSystemContext db = new CarRentalSystemContext())
                {
                    user = unit.Users.GetAll().FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
                       
                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }

            return View(model);
        }
        public ActionResult Profile()
        {
            User user = unit.Users.GetAll().FirstOrDefault(u => u.Email == User.Identity.Name);
            EditModel edit = new EditModel
            {
                FirstName = user.FirstName,
                Gender = user.Gender,
                LastName = user.LastName,
                Id = user.Id,
                Skype = user.Skype,
                Telephone = user.Telephone,
                Role = user.Role,
                RoleId = user.RoleId
            };
            return View(edit);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            ViewBag.Roles = new SelectList(unit.Roles.GetAll(), "Id", "Name");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = unit.Users.GetById(id);//db.Monuments.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Monuments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                user.Role = unit.Roles.GetById(user.RoleId);
                unit.Users.Update(user);
                unit.Save();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Profile(EditModel edit)
        {
            User user = unit.Users.GetAll().FirstOrDefault(u => u.Email == User.Identity.Name);

            if (ModelState.IsValid)
            {
                user.Telephone = edit.Telephone;
                user.Skype = edit.Skype;
                user.LastName = edit.LastName;
                user.Gender = edit.Gender;
                user.FirstName = edit.FirstName;
                unit.Users.Update(user);
                unit.Save();
                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }
        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]  
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (CarRentalSystemContext db = new CarRentalSystemContext())
                {
                    user = unit.Users.GetAll().FirstOrDefault(u => u.Email == model.Email);
                }
                if (user == null)
                {
                    // создаем нового пользователя
                    using (CarRentalSystemContext db = new CarRentalSystemContext())
                    {
                        unit.Users.Create(new User
                        {
                            Email = model.Email,
                            Password = model.Password,
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            ConfirmPassword = model.ConfirmPassword,
                            Gender = model.Gender,
                            Skype = model.Skype,
                            Telephone = model.Telephone,
                            RoleId=2
                        });
                        unit.Save();
                        //db.SaveChanges();
                        user = unit.Users.GetAll().Where(u => u.Email == model.Email && u.Password == model.Password).FirstOrDefault();
                    }
                    // если пользователь удачно добавлен в бд
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }
            return View(model);
        }
        
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}