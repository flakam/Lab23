using Microsoft.AspNetCore.Mvc;
using New23Try2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace New23Try2.Controllers
{
    public class LoginController : Controller
    {
        ShoppContext db = new ShoppContext();
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string userName, string password, decimal money)
        {
            if (ModelState.IsValid)
            {
                var inputs = new Users { UserName = userName, Password = password, Money = money };
                db.Add(inputs);
                db.SaveChanges();
                ViewData["Message"] = "Thanks For Register. Please Login!";
                return View();
            }
            else
            {
                ViewData["Message"] = "Saved";
                return View();
            }
            //  return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Name, string Password)
        {
            List<Users> users = db.Users.ToList();

            for (int i = 0; i < users.Count; i++)
            {
                Users u = users[i];
                if (u.UserName == Name && u.Password == Password)
                {
                    //Log in the user
                    TempData["User"] = u;
                }
            }

            ViewBag.Error = "Incorrect User name or password, please register or try again";
            return RedirectToAction("Index", "Home");
        }
    }
}
