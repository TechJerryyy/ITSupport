﻿using ITSupport.Core.Contract;
using ITSupport.Core.Models;
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
    public class CommonLookupController : Controller
    {
        ICommonLookupService _commonLookupService;
        public CommonLookupController(ICommonLookupService commonLookupService)
        {
            _commonLookupService = commonLookupService;
        }
        [AllowAnonymous]
        // GET: CommonLookup
        public ActionResult Index([DataSourceRequest] DataSourceRequest request)
        {
            List<CommonLookup> commonLookups = _commonLookupService.GetCommonLookups().ToList();
            //ViewBag.CommonLookups = commonLookups.ToDataSourceResult(request);
            return PartialView("_CommonLookupPartial",commonLookups.ToDataSourceResult(request));
        }
        public ActionResult GetCommonLookups([DataSourceRequest] DataSourceRequest request)
        {
            List<CommonLookup> commonLookups = _commonLookupService.GetCommonLookups().Select(x => new CommonLookup() { Id = x.Id, ConfigName = x.ConfigName, ConfigKey = x.ConfigKey, ConfigValue = x.ConfigValue, Description = x.Description, DisplayOrder = x.DisplayOrder, IsActive = x.IsActive, IsEdit = x.IsEdit }).ToList();
            return Json(commonLookups.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create(Guid? Id = null)
        {
            CommonLookup commonLookup = new CommonLookup();
            if (Id == null)
            {
                commonLookup.IsEdit = false;
                return PartialView("_CLPartial", commonLookup);
            }
            else
            {
                commonLookup = _commonLookupService.GetCommonLookup(Id.Value);
                commonLookup.IsEdit = true;
                return PartialView("_CLPartial", commonLookup);
            }
            //return View();
        }
        [HttpPost]
        public ActionResult Create(CommonLookup model)
        {
                var commonLookupData = _commonLookupService.Create(model);
                if (commonLookupData != null)
                {
                    return Content("True");
                }
                else
                {
                    TempData["PageSelected"] = "CommonLookupManagement";
                    return Content("False");
                }           

            //return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(CommonLookup model)
        {
                var commonLookupData = _commonLookupService.Edit(model);
                TempData["PageSelected"] = "CommonLookupManagement";
                if (commonLookupData != null)
                {
                    return Content("True");
                }
                else
                {

                    return Content("False");
                }
                //return RedirectToAction("Index");
        }
        //public ActionResult Delete(Guid Id)
        //{
        //    CommonLookup commonLookup = _commonLookupService.GetCommonLookup(Id);
        //    return View(commonLookup);
        //}
        [HttpPost]

        public ActionResult Delete(Guid Id)
        {
            CommonLookup commonLookup = _commonLookupService.GetCommonLookup(Id);
            TempData["PageSelected"] = "CommonLookupManagement";
            _commonLookupService.Delete(commonLookup);            
            //return RedirectToAction("Index", "Admin");
            return PartialView("_CommonLookupPartial");
        }
    }
}