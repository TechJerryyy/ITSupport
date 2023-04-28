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
    public class FormMstController : Controller
    {
        private readonly IFormMstService _formService;
        private readonly IPermissionService _permissionService;
        public FormMstController(IFormMstService formService, IPermissionService permissionService)
        {
            _formService = formService;
            _permissionService = permissionService;
        }
        // GET: FormMst
        [PermissionActionFilter("FM", CheckRights.PermissionOrder.IsView)]
        public ActionResult Index([DataSourceRequest] DataSourceRequest request)
        {
            List<FormMstViewModel> forms = _formService.GetForms().ToList();
            return View(forms.ToDataSourceResult(request));
        }
        public ActionResult GetAllForms([DataSourceRequest] DataSourceRequest request)
        {
            List<FormMstViewModel> forms = _formService.GetForms().ToList();
            return Json(forms.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        [PermissionActionFilter("FM", CheckRights.PermissionOrder.IsInsert)]
        public ActionResult Create()
        {
            FormMstViewModel forms = new FormMstViewModel
            {
                FormDropDowns = _formService.GetForms().Select(x => new FormDropDown() { ParentFormId = x.Id, ParentFormName = x.Name }).ToList()
            };
            return View(forms);
        }
        [HttpPost]
        public ActionResult Create(FormMstViewModel model)
        {
            var form = _formService.CreateForm(model);
            if (form != null)
            {
                ViewBag.message = form;
                model.FormDropDowns = _formService.GetForms().Select(x => new FormDropDown() { ParentFormId = x.Id, ParentFormName = x.Name }).ToList();
                return View(model);
            }
            return RedirectToAction("Index", "FormMst");
        }
        [PermissionActionFilter("FM", CheckRights.PermissionOrder.IsUpdate)]
        public ActionResult Edit(Guid Id)
        {
            FormMstViewModel form = _formService.GetForm(Id);
            form.FormDropDowns = _formService.GetForms().Where(x => x.Id != Id).Select(x => new FormDropDown() { ParentFormId = x.Id, ParentFormName = x.Name }).ToList();
            return View(form);

        }
        [HttpPost]
        public ActionResult Edit(FormMstViewModel model)
        {
            var form = _formService.EditForm(model);
            var permission = _permissionService.GetPermission((Guid)Session["RoleId"]).ToList();
            Session["permissions"] = permission;
            if (form != null)
            {
                ViewBag.message = form;
                model.FormDropDowns = _formService.GetForms().Where(x=>x.Id!=model.Id).Select(x => new FormDropDown() { ParentFormId = x.Id, ParentFormName = x.Name }).ToList();
                return View(model);
            }
            return RedirectToAction("Index", "FormMst");
        }
        [PermissionActionFilter("FM", CheckRights.PermissionOrder.IsDelete)]
        public ActionResult Delete(Guid Id)
        {
            FormMstViewModel form = _formService.GetForm(Id);
            if (form == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(form);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(Guid Id)
        {
            _formService.DeleteForm(Id);
            var permission = _permissionService.GetPermission((Guid)Session["RoleId"]).ToList();
            Session["permissions"] = permission;
            return RedirectToAction("Index", "FormMst");
        }
    }
}