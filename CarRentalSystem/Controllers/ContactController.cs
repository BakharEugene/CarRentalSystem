using CarRentalSystem.DAL.Models.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRentalSystem.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index(EmailModel model)
        {
            if (model == null)
                model=new EmailModel();
            return View(model);
        }
    }
}