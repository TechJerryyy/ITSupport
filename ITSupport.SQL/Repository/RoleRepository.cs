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
    public interface IRoleRepository
    {
        IQueryable<Role> Collection();
        void Commit();
        void Insert(Role role);
        Role Find(Guid Id);
        void Update(Role role);
        void Delete(Guid Id);
    }
    public class RoleRepository : IRoleRepository
    {
        internal DataContext context;
        internal DbSet<Role> dbSet;
        public RoleRepository(DataContext context)
        {
            this.context = context;
            dbSet = context.Set<Role>();
        }
        public IQueryable<Role> Collection()
        {
            return dbSet;
        }
        public void Commit()
        {
            context.SaveChanges();
        }
        public void Insert(Role role)
        {
            dbSet.Add(role);
        }
        public Role Find(Guid Id)
        {
            return dbSet.Find(Id);
        }
        public void Update(Role role)
        {
            dbSet.Attach(role);
            context.Entry(role).State = EntityState.Modified;
        }
        public void Delete(Guid Id)
        {
            var role = Find(Id);
            if (context.Entry(role).State == EntityState.Detached)
            {
                dbSet.Attach(role);
            }
            dbSet.Remove(role);
        }   
    }
}
