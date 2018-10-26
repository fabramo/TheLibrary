using FrontEnd.Models;
using System;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class UserController : Controller
    {
        private LibraryDBContext db = new LibraryDBContext();

        [HttpGet]
        public ActionResult Login()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            ViewBag.Message = "Your application description page.";

            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind(Include = "Email,Name,Surname,DateOfBirth,Password,ConfirmPassword")] UserRegistration model)
        {
            if (ModelState.IsValid)
            {
                var user = MapUserRegistrationToUser(model);
                db.Users.Add(user);
                db.SaveChanges();
            }

            return RedirectToAction("Login");
        }

        private User MapUserRegistrationToUser(UserRegistration model)
        {
            return new User()
            {
                Email = model.Email,
                Name = model.Name,
                Surname = model.Surname,
                DateOfBirth = model.DateOfBirth,
                Password = model.Password
            };
        }
    }
}