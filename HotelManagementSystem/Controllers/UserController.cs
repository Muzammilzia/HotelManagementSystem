using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            User user = new User();
            return View(user);
        }

        [HttpPost]
        public ActionResult AddOrEdit(User user)
        {
            using (UserDbModels userDbModel = new UserDbModels())
            {
                if(userDbModel.Users.Any(x => x.Username == user.Username))
                {
                    ViewBag.DuplicateMessage = "Username already exist.";
                    return View("AddOrEdit", user);
                }
                userDbModel.Users.Add(user);
                userDbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Succesful.";
            return View("AddOrEdit", new User());
        }
    }
}