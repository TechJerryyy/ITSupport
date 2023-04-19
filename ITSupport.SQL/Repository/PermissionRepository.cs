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
    public interface IPermissionRepository
    {
        IQueryable<Permission> Collection();
        void Commit();
        Permission Find(Guid RoleId);
        void InsertRange(List<Permission> model);
        void Delete(Guid RoleId);
        List<PermissionViewModel> GetPermission(Guid RoleId);
    }

    public class PermissionRepository : IPermissionRepository
    {
        internal DataContext context;
        internal DbSet<Permission> dbSet;
        public PermissionRepository(DataContext context)
        {
            this.context = context;
            dbSet = context.Set<Permission>();
        }
        public IQueryable<Permission> Collection()
        {
            return dbSet;
        }
        public void Commit()
        {
            context.SaveChanges();
        }
        public Permission Find(Guid RoleId)
        {
            return dbSet.Find(RoleId);
        }
        public void Delete(Guid RoleId)
        {
            var per = Find(RoleId);
            if (context.Entry(per).State == EntityState.Detached)
            {
                dbSet.Attach(per);
            }
            dbSet.Remove(per);
        }
        public void InsertRange(List<Permission> model)
        {
            var recordstoDelete = Collection().ToList().Where(x => x.RoleId == model.FirstOrDefault().RoleId);
            dbSet.RemoveRange(recordstoDelete);
            Commit();
            dbSet.AddRange(model);
            Commit();
        }
        public List<PermissionViewModel> GetPermission(Guid RoleId)
        {
                var allPermissions = (from f in context.Forms
                                      join p in context.Permissions.Where(x => x.RoleId == RoleId) on
                                      f.Id equals p.FormId into fp
                                      from fPer in fp.DefaultIfEmpty()
                                      where !f.IsDeleted
                                      select new PermissionViewModel
                                      {
                                          FormId = f.Id,
                                          FormName = f.Name,
                                          RoleId = RoleId,
                                          View = fPer != null ? fPer.View : false,
                                          Insert = fPer != null ? fPer.Insert : false,
                                          Update = fPer != null ? fPer.Update : false,
                                          Delete = fPer != null ? fPer.Delete : false
                                      }).ToList();
                return allPermissions;
        }
    }
}
