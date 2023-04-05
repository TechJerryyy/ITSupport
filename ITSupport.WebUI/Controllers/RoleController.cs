using ITSupport.Core.Models;
using ITSupport.Core.ViewModels;
using ITSupport.Services.Services;
using ITSupport.WebUI.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITSupport.WebUI.Controllers
{
    [UserAuth]
    public class RoleController : Controller
    {
        IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [AllowAnonymous]
        public ActionResult Index([DataSourceRequest] DataSourceRequest request)
        {
            List<Role> roles = _roleService.GetRoleList().ToList();
            return View(roles.ToDataSourceResult(request));
        }
        public ActionResult GetAllRolesJson([DataSourceRequest] DataSourceRequest request)
        {
            List<RoleViewModel> userRoleViewModels = _roleService.GetRoleList().Select(x => new RoleViewModel() { Id = x.Id, Name = x.Name, Code = x.Code }).ToList();
            return Json(userRoleViewModels.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RoleViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return View(model);
            }
            else
            {
                var role = _roleService.CreateRole(model);
                if (role != null)
                {
                    ViewBag.message = role;
                    return View(model);
                }
                else
                {
                    TempData["PageSelected"] = "RoleManagement";
                    return RedirectToAction("Index", "Admin");
                }
            }
        }

        public ActionResult Edit(Guid Id)
        {
            RoleViewModel role = _roleService.GetRole(Id);

            return View(role);

        }

        [HttpPost]
        public ActionResult Edit(RoleViewModel model)
        {
            var role = _roleService.EditRole(model);
            if (role != null)
            {
                ViewBag.message = role;
                return View(model);
            }
            else
            {
                TempData["PageSelected"] = "RoleManagement";
                return RedirectToAction("Index", "Admin");
            }
        }
        public ActionResult Delete(Guid Id)
        {
            RoleViewModel role = _roleService.GetRole(Id);
            return View(role);
        }
        [HttpPost]
        public ActionResult Delete(RoleViewModel model)
        {
            _roleService.DeleteRole(model);
            TempData["PageSelected"] = "RoleManagement";
            return RedirectToAction("Index", "Admin");
        }


    }
}