using ITSupport.Core.Contract;
using ITSupport.Core.Models;
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
    public class CommonLookupController : Controller
    {
        private readonly ICommonLookupService _commonLookupService;
        public CommonLookupController(ICommonLookupService commonLookupService)
        {
            _commonLookupService = commonLookupService;
        }
        [AllowAnonymous]
        public ActionResult Index([DataSourceRequest] DataSourceRequest request)
        {
            List<CommonLookup> CommonLookups = _commonLookupService.GetCommonLookups().ToList();
            return PartialView("_CommonLookupPartial",CommonLookups.ToDataSourceResult(request));
        }
        public ActionResult GetCommonLookups([DataSourceRequest] DataSourceRequest request)
        {
            List<CommonLookup> CommonLookups = _commonLookupService.GetCommonLookups().Select(x => new CommonLookup() { Id = x.Id, ConfigName = x.ConfigName, ConfigKey = x.ConfigKey, ConfigValue = x.ConfigValue, Description = x.Description, DisplayOrder = x.DisplayOrder, IsActive = x.IsActive, IsEdit = x.IsEdit }).ToList();
            return Json(CommonLookups.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
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
        }
        [HttpPost]
        public ActionResult Create(CommonLookup model)
        {
                var commonLookupData = _commonLookupService.Create(model);
                TempData["PageSelected"] = "CommonLookupManagement";
                if (commonLookupData != null)
                {
                    return Content("True");
                }
                else
                {
                    return Content("False");
                }           
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
        }
        [HttpPost]

        public ActionResult Delete(Guid Id)
        {
            CommonLookup commonLookup = _commonLookupService.GetCommonLookup(Id);
            TempData["PageSelected"] = "CommonLookupManagement";
            _commonLookupService.Delete(commonLookup);            
            return PartialView("_CommonLookupPartial");
        }
    }
}