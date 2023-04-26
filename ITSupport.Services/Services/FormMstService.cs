using ITSupport.Core.Contract;
using ITSupport.Core.Models;
using ITSupport.Core.ViewModels;
using ITSupport.SQL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ITSupport.Services.Services
{
    public class FormMstService : IFormMstService
    {
        private readonly IFormMstRepository _formMstRepository;
        private readonly IPermissionRepository _PermissionRepository;
        public FormMstService(IFormMstRepository formMstRepository, IPermissionRepository PermissionRepository)
        {
            _formMstRepository = formMstRepository;
            _PermissionRepository = PermissionRepository;
        }
        public string CreateForm(FormMstViewModel model)
        {
            var forms = _formMstRepository.Collection().Where(x => x.FormAccessCode == model.FormAccessCode && !x.IsDeleted).FirstOrDefault();
            if (forms != null)
            {
                return "Form already exists!";
            }
            else
            {
                FormMst formMst = new FormMst();
                FormMst form = formMst;
                form.Name = model.Name;
                form.NavigateURL = model.NavigateURL;
                if (model.ParentFormId != null)
                {
                    form.ParentFormID = model.ParentFormId;
                }
                form.FormAccessCode = model.FormAccessCode.ToUpper().Trim();
                form.DisplayIndex = model.DisplayIndex;
                form.IsActive = model.IsActive;
                _formMstRepository.Insert(form);
                _formMstRepository.Commit();
                return null;
            }
        }
        public string EditForm(FormMstViewModel model)
        {
            var forms = _formMstRepository.Collection().Where(x => x.Id != model.Id && x.FormAccessCode == model.FormAccessCode && !x.IsDeleted).FirstOrDefault();
            if (forms != null)
            {
                return "Form already exists!";
            }
            else
            {
                var form = _formMstRepository.Collection().Where(x => x.Id == model.Id).FirstOrDefault();
                form.Name = model.Name;
                form.NavigateURL = model.NavigateURL;
                form.FormAccessCode = model.FormAccessCode.ToUpper().Trim();
                form.DisplayIndex = model.DisplayIndex;
                form.IsActive = model.IsActive;
                form.UpdatedOn = DateTime.Now;
                form.ParentFormID = model.ParentFormId;
                _formMstRepository.Update(form);
                _formMstRepository.Commit();
                var permission = _PermissionRepository.Collection().Where(x => x.FormId == model.Id).ToList();
                foreach (var item in permission)
                {
                    _PermissionRepository.Update(item);
                    _PermissionRepository.Commit();
                }
                return null;
            }
        }
        public void DeleteForm(Guid Id)
        {
            FormMstViewModel model = new FormMstViewModel();
            var formMst = _formMstRepository.Collection().Where(x => x.Id == Id).FirstOrDefault();
            formMst.IsDeleted = true;
            _formMstRepository.Update(formMst);
            _formMstRepository.Commit();
            var permission = _PermissionRepository.Collection().Where(x => x.FormId == Id).ToList();
            foreach (var item in permission)
            {
                item.IsDeleted = true;
                _PermissionRepository.Update(item);
                _PermissionRepository.Commit();
            }
        }
        public FormMstViewModel GetForm(Guid Id)
        {
            return _formMstRepository.GetFormById(Id);
        }
        public List<FormMstViewModel> GetForms()
        {
            return _formMstRepository.GetForms();
        }
    }
    public interface IFormMstService
    {
        string CreateForm(FormMstViewModel model);
        string EditForm(FormMstViewModel model);
        void DeleteForm(Guid Id);
        FormMstViewModel GetForm(Guid Id);
        List<FormMstViewModel> GetForms();
    }
}
