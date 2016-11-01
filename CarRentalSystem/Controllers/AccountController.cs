using CarRentalSystem.DAL.EF;
using CarRentalSystem.DAL.Models;
using CarRentalSystem.DAL.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CarRentalSystem.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {//kek;
            return View();
        }
        UnitOfWork unit = new UnitOfWork();
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
                        
                        //db.Customers.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

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
                        //db.Customers.FirstOrDefault(u => u.Email == model.Email);
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
                            Telephone = model.Skype,
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