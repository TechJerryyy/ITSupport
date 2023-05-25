using ITSupport.Core.Interfaces;
using ITSupport.Core.Models;
using ITSupport.Core.ViewModels;
using ITSupport.Services.Services;
using ITSupport.WebUI.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ITSupport.WebUI.Controllers
{
    [AuditLog()]
    public class AccountController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly IRepository<UserRole> _userRoleManager;
        private readonly IRepository<Role> _RoleManager;
        private readonly IFormMstService _formService;
        private readonly IPermissionService _permissionService;
        public AccountController(ILoginService loginService, IRepository<UserRole> userRoleManager, IPermissionService permissionService, IFormMstService formService, IRepository<Role> RoleManager)
        {
            _loginService = loginService;
            _userRoleManager = userRoleManager;
            _permissionService = permissionService;
            _formService = formService;
            _RoleManager = RoleManager;
        }
        // GET: Account
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
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
                    Session["UserId"] = user.Id;
                    Guid roleId = _userRoleManager.Collection().Where(x => x.UserId == user.Id).Select(x => x.RoleId).FirstOrDefault();
                    Session["RoleId"] = roleId;
                    var rolecode = _RoleManager.Collection().Where(x => x.Id == roleId).Select(x => x.Code).FirstOrDefault();
                    Session["RoleCode"] = rolecode;
                    var permission = _permissionService.GetPermission(roleId).ToList();
                    Session["permissions"] = permission;
                    return RedirectToAction("Index", "Home");
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
        //public ActionResult Error404()
        //{
        //    return View();
        //}
    }
}