using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarRentalSystem.DAL.EF;
using CarRentalSystem.DAL.Models.Car;
using CarRentalSystem.DAL.Models.Pictures;
using CarRentalSystem.DAL.Models;
using CarRentalSystem.DAL.Models.Order_History;

namespace CarRentalSystem.Controllers
{
    public class CarsController : Controller
    {
        //l

        UnitOfWork unit = new UnitOfWork();
        // GET: Cars
        public ActionResult Index()
        {
            List<Car> Cars = unit.Cars.GetAll().ToList();// db.Cars.ToList();
            return View(Cars);
        }
        public ActionResult ConfirmOrder(int? id)
        {
            ViewBag.CarName = unit.Cars.GetById(id).Mark.MarkType+" "+ unit.Cars.GetById(id).Model ;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmOrder(OrderHistory order)
        {
            unit.OrderHistories.Create(order);
            unit.Save();
            return RedirectToAction("Index");
        }
        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = unit.Cars.GetById(id);// db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {

            SelectList Marks = new SelectList(unit.Marks.GetAll(), "Id", "MarkType");//(.Marks, "Id", "MarkType");
            SelectList Bodies = new SelectList(unit.Bodies.GetAll(), "Id", "Name");
            SelectList Transmissions = new SelectList(unit.Transmissions.GetAll(), "Id", "Name");
            SelectList DriveUnits = new SelectList(unit.DriveUnits.GetAll(), "Id", "Name");
            SelectList Fuels = new SelectList(unit.Fuels.GetAll(), "Id", "Name");


            ViewBag.Fuels = Fuels;
            ViewBag.DriveUnits = DriveUnits;
            ViewBag.Bodies = Bodies;
            ViewBag.Transmissions = Transmissions;
            ViewBag.Marks = Marks;
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(Car car)
        {
            car.Mark = unit.Marks.GetById(car.IdMark);
            car.Body = unit.Bodies.GetById(car.IdBody);
            car.DriveUnit = unit.DriveUnits.GetById(car.IdDriveUnit);
            car.Fuel = unit.Fuels.GetById(car.IdFuel);
            car.Transmission = unit.Transmissions.GetById(car.IdTransmission);

            unit.Cars.Create(car);
            unit.Save();
            //db.SaveChanges();
            // перенаправляем на главную страницу
            return RedirectToAction("Index");
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = unit.Cars.GetById(id);//db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            SelectList Marks = new SelectList(unit.Marks.GetAll(), "Id", "MarkType");//(.Marks, "Id", "MarkType");
            ViewBag.Marks = Marks;
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Model,Volume,Price,Description,IdMark,IdFuel,IdTransmission,IdBody,IdDriveUnit,Mark,Mileage")] Car car)
        {
            if (ModelState.IsValid)
            {
                
                unit.Cars.Update(car);
                unit.Save();
                
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = unit.Cars.GetById(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }
        [HttpPost]
        public ActionResult Upload(IEnumerable<HttpPostedFileBase> uploads, Car car)
        {
            car.Body = unit.Bodies.GetById(car.IdBody);
            car.Mark = unit.Marks.GetById(car.IdMark);
            car.DriveUnit = unit.DriveUnits.GetById(car.IdDriveUnit);
            car.Fuel = unit.Fuels.GetById(car.IdFuel);
            car.Transmission = unit.Transmissions.GetById(car.IdTransmission);
            if (uploads != null)
            {
                foreach (var file in uploads)
                {
                    if (file != null)
                    {
                        // получаем имя файла
                        string fileName = System.IO.Path.GetFileName(file.FileName);
                        // сохраняем файл в папку Files в проекте
                        file.SaveAs(Server.MapPath("~/Files/" + fileName));
                        unit.CarsPictures.Create(new CarPictures("/Images/" + fileName, car));

                    }
                }
            }

            unit.Cars.Create(car);
            unit.Save();
          
            return RedirectToAction("Index");
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = unit.Cars.GetById(id);
            var g = "";
            car.Pictures.Clear();
            unit.Cars.Delete(car.Id);
            foreach (var pict in unit.CarsPictures.GetAll())
            {
                if (pict.CarId == null)
                {
                    unit.CarsPictures.Delete(pict.Id);
                }
            }
            unit.Save();
            
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unit.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
