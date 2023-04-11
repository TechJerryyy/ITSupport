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
    public class FormMstController : Controller
    {
        private readonly IFormMstService _formService;
        public FormMstController(IFormMstService formService)
        {
            _formService = formService;
        }
        // GET: FormMst
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
            if (form != null)
            {
                ViewBag.message = form;
                model.FormDropDowns = _formService.GetForms().Where(x=>x.Id!=model.Id).Select(x => new FormDropDown() { ParentFormId = x.Id, ParentFormName = x.Name }).ToList();
                return View(model);
            }
            return RedirectToAction("Index", "FormMst");
        }
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
            return RedirectToAction("Index", "FormMst");
        }
    }
}