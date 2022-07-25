using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        public bool admin;
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(Login loginUser)
        {
            using (UserDbModels userDbModel = new UserDbModels())
            {
                var userDetails = userDbModel.Users.Where(x => x.Username == loginUser.Username && x.Password == loginUser.Password && x.IsAdmin == loginUser.IsAdmin).FirstOrDefault();
                if(userDetails == null)
                {
                    loginUser.ErrorMessage = "Wrong username or password.";
                    return View("Index",loginUser);
                }
                else
                {
                    Session["userID"] = userDetails.UserID;
                    Session["isAdmin"] = userDetails.IsAdmin ? "1" : "0" ;
                    return RedirectToAction("Index","Home");
                }
            }
        }
    }
}