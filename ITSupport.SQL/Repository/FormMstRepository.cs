using ITSupport.Core.Models;
using ITSupport.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSupport.SQL.Repository
{
    public class FormMstRepository : IFormMstRepository
    {
        internal DataContext context;
        internal DbSet<FormMst> dbSet;
        public FormMstRepository(DataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<FormMst>();
        }
        public IQueryable<FormMst> Collection()
        {
            return dbSet;
        }
        public void Commit()
        {
            context.SaveChanges();
        }
        public FormMst Find(Guid Id)
        {
            return dbSet.Find(Id);
        }
        public void Insert(FormMst form)
        {
            dbSet.Add(form);
        }
        public void Delete(Guid Id)
        {
            var form = Find(Id);
            if (context.Entry(form).State == EntityState.Detached)
                dbSet.Attach(form);
            dbSet.Remove(form);
        }
        public void Update(FormMst form)
        {
            dbSet.Attach(form);
            context.Entry(form).State = EntityState.Modified;
        }
        public FormMstViewModel GetFormById(Guid Id)
        {
            var form = (from f in context.Forms
                        join m in context.Forms on f.ParentFormID equals m.Id
                        into fdata
                        from mf in fdata.DefaultIfEmpty()
                        where !f.IsDeleted && f.Id==Id
                        select new FormMstViewModel
                        {
                            Id = f.Id,
                            ParentFormId= f.ParentFormID,
                            ParentFormName= mf.Name,
                            Name = f.Name,
                            NavigateURL = f.NavigateURL,
                            FormAccessCode = f.FormAccessCode.ToUpper().Trim(),
                            DisplayIndex = f.DisplayIndex,
                            IsActive = f.IsActive,
                        }).FirstOrDefault();
            return form;
        }
        public List<FormMstViewModel> GetForms()
        {
            var forms = (from f in context.Forms.Where(x => !x.IsDeleted).AsEnumerable()
                         join m in context.Forms on f.ParentFormID equals m.Id into fdata
                         orderby f.DisplayIndex ascending
                         from mf in fdata.DefaultIfEmpty()
                         select new FormMstViewModel
                         {
                             Id = f.Id,
                             ParentFormId = mf?.ParentFormID,
                             ParentFormName = mf?.Name,
                             Name = f.Name,
                             NavigateURL = f.NavigateURL,
                             FormAccessCode = f.FormAccessCode.ToUpper().Trim(),
                             DisplayIndex = f.DisplayIndex,
                             IsActive = f.IsActive,
                         }).Distinct()
                         .ToList();
            return forms;
        }
    }
    public interface IFormMstRepository
    {
        IQueryable<FormMst> Collection();
        void Commit();
        FormMst Find(Guid Id);
        void Insert(FormMst form);
        void Delete(Guid Id);
        void Update(FormMst form);
        FormMstViewModel GetFormById(Guid Id);
        List<FormMstViewModel> GetForms();
    }
}
