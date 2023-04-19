﻿using ITSupport.Core.ViewModels;
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
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        public UserController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }
        public ActionResult Index([DataSourceRequest] DataSourceRequest request)
        {
            List<UserViewModel> user = _userService.GetUsers().ToList();
            return PartialView("_UserIndexPartial", user.ToDataSourceResult(request));
        }
        public ActionResult GetAllUsers([DataSourceRequest] DataSourceRequest request)
        {
            List<UserViewModel> user = _userService.GetUsers().Select(x => new UserViewModel() { Id = x.Id, Name = x.Name, UserName = x.UserName, Email = x.Email, Password = x.Password, Gender = x.Gender, MobileNumber = x.MobileNumber, RoleId = x.RoleId, RoleName = x.RoleName }).ToList();
            return Json(user.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {
            UserViewModel user = new UserViewModel
            {
                DropDowns = _roleService.GetRoleList().Select(x => new DropDown() { Id = x.Id, Name = x.Name }).ToList()
            };
            return View(user);
        }
        [HttpPost]
        public ActionResult Create(UserViewModel model)
        {
            var user = _userService.CreateUser(model);
            if (user != null)
            {
                ViewBag.message = user;
                model.DropDowns = _roleService.GetRoleList().Select(x => new DropDown() { Id = x.Id, Name = x.Name }).ToList();
                return View(model);
            }
            else
            {
                TempData["PageSelected"] = "UserManagement";
                return RedirectToAction("Index", "Admin");
            }
        }
        public ActionResult Edit(Guid Id)
        {
            UserViewModel user = _userService.GetUser(Id);
            user.DropDowns = _roleService.GetRoleList().Select(x => new DropDown() { Id = x.Id, Name = x.Name }).ToList();
            return View(user);

        }

        [HttpPost]
        public ActionResult Edit(UserViewModel model)
        {
            var user = _userService.EditUser(model);
            if (user != null)
            {
                ViewBag.message = user;
                model.DropDowns = _roleService.GetRoleList().Select(x => new DropDown() { Id = x.Id, Name = x.Name }).ToList();
                return View(model);
            }
            else
            {
                TempData["PageSelected"] = "UserManagement";
                return RedirectToAction("Index", "Admin");
            }
        }
        public ActionResult Delete(Guid Id)
        {
            UserViewModel user = _userService.GetUser(Id);
            if (user == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(user);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(Guid Id)
        {
            _userService.DeleteUser(Id);
            TempData["PageSelected"] = "UserManagement";
            return RedirectToAction("Index", "Admin");
        }
    }
}