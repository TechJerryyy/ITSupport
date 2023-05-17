using ITSupport.Core.Models;
using ITSupport.Core.ViewModels;
using ITSupport.Services.Services;
using ITSupport.WebUI.ActionFilters;
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
        private readonly IRoleService _roleService;
        private readonly IPermissionService _permissionService;
        public RoleController(IRoleService roleService, IPermissionService permissionService)
        {
            _roleService = roleService;
            _permissionService = permissionService;
        }
        public ActionResult Index([DataSourceRequest] DataSourceRequest request)
        {
            List<Role> roles = _roleService.GetRoleList().ToList();
            TempData["PageSelected"] = "RoleManagement";
            TempData.Keep();
            return PartialView("_RoleIndexPartial", roles.ToDataSourceResult(request));
        }
        public ActionResult GetAllRolesJson([DataSourceRequest] DataSourceRequest request)
        {
            List<RoleViewModel> userRoleViewModels = _roleService.GetRoleList().Select(x => new RoleViewModel() { Id = x.Id, Name = x.Name, Code = x.Code }).ToList();
            TempData["PageSelected"] = "RoleManagement";
            TempData.Keep();
            return Json(userRoleViewModels.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {
            TempData["PageSelected"] = "RoleManagement";
            return View();
        }
        [HttpPost]
        public ActionResult Create(RoleViewModel model)
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
        public ActionResult Edit(Guid Id)
        {
            RoleViewModel role = _roleService.GetRole(Id);
            TempData["PageSelected"] = "RoleManagement";
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
            TempData["PageSelected"] = "RoleManagement";
            return View(role);
        }
        [HttpPost]
        public ActionResult Delete(RoleViewModel model)
        {
            _roleService.DeleteRole(model);
            TempData["PageSelected"] = "RoleManagement";
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult ManagePermission(Guid Id)
        {
            List<PermissionViewModel> permision = _permissionService.GetPermission(Id).ToList();
            ViewBag.RoleId = Id;
            TempData["PageSelected"] = "RoleManagement";
            return View(permision);
        }
        public ActionResult GetAllPermissionJson([DataSourceRequest] DataSourceRequest request, Guid Id)
        {
            List<PermissionViewModel> permissionViewModels = _permissionService.GetPermission(Id).ToList();
            TempData["PageSelected"] = "RoleManagement";
            return Json(permissionViewModels.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UpdatePermission(List<Permission> model)
        {
            TempData["PageSelected"] = "RoleManagement";
            _permissionService.UpdatePermission(model);
            var permissions = _permissionService.GetPermission((Guid)Session["RoleId"]).ToList();
            Session["permissions"] = permissions;
            return RedirectToAction("Index", "Admin");
        }
    }
}