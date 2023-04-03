using ITSupport.Core.Contract;
using ITSupport.Core.Models;
using ITSupport.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ITSupport.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private ILoginService _loginService;
        public AccountController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        // GET: Account
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                User user = _loginService.Login(model);
                if (user != null)
                {
                    Session["UserName"] = user.UserName.ToString();
                    Session["UserId"] = user.Id.ToString();

                    return RedirectToAction("Index", "Admin");

                }
                else
                {
                    //ViewBag.Message ="Invalid Login Attempt";
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                    return View();

                }
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, change to shouldLockout: true
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}