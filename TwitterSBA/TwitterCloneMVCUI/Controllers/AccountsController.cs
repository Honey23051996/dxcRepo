using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterCloneMVCUI.Models;
using DataAccess;
using System.Web.Security;

namespace TwitterCloneMVCUI.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken, ValidateInput(true)]
        public ActionResult Register(RegistrationViewModel obj)
        {
            if (ModelState.IsValid)
            {
                Person objP = new Person();
                objP.userid = obj.UserID;
                objP.password = obj.Password;
                objP.full_name = obj.FullName;
                objP.Email_Address = obj.Email;
                objP.joined = DateTime.Now;
                objP.active = true;

                var repository = new UserRepository();
                repository.AddUser(objP);

                ViewBag.Message = "Registration Successful..";

            }
            return View(obj);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken, ValidateInput(true)]
        public ActionResult Login(LoginViewModel obj)
        {
            if (ModelState.IsValid)
            {
                UserRepository objUser = new UserRepository();
                var IsVerified= objUser.VerifyUser(obj.UserID, obj.Password);
                if(IsVerified == false)
                {
                    ViewBag.msg = "Incorrect username/password";
                    return View(obj);
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(obj.UserID, obj.RememberMe);
                    return RedirectToAction("Home", "Twitter");
                }
            }
            return View(obj);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Accounts");
        }
    }
}