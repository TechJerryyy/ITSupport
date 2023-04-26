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
    public class UserRepository : IUserRepository
    {
        internal DataContext context;
        internal DbSet<User> dbSet;
        internal DbSet<UserRole> urdbSet;
        public UserRepository(DataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<User>();
            this.urdbSet = context.Set<UserRole>();
        }
        public IQueryable<User> Collection()
        {
            return dbSet;
        }
        public void Commit()
        {
            context.SaveChanges();
        }
        public User Find(Guid Id)
        {
            return dbSet.Find(Id);
        }
        public void Insert(User user)
        {
            dbSet.Add(user);
        }
        public void Delete(Guid Id)
        {
            var user = Find(Id);
            if (context.Entry(user).State == EntityState.Detached)
                dbSet.Attach(user);
            dbSet.Remove(user);

        }
        public void Update(User user)
        {
            dbSet.Attach(user);
            context.Entry(user).State = EntityState.Modified;

        }
        public void UpdateUserRole(UserRole userRole)
        {
            urdbSet.Attach(userRole);
            context.Entry(userRole).State = EntityState.Modified;
        }
        public UserViewModel GetUserById(Guid Id)
        {
            var users = (from u in context.Users
                         join ur in context.UserRoles on u.Id equals ur.UserId
                         join r in context.Roles on ur.RoleId equals r.Id
                         where !u.IsDeleted && !ur.IsDeleted && !r.IsDeleted && u.Id == Id
                         select new UserViewModel
                         {
                             Id = u.Id,
                             Name = u.Name,
                             UserName = u.UserName,
                             Email = u.Email,
                             Password = u.Password,
                             Gender = u.Gender,
                             MobileNumber = u.MobileNumber,
                             RoleId = ur.RoleId,
                             RoleName = r.Name

                         }).FirstOrDefault();
            return users;
        }
        public List<UserViewModel> GetUsers()
        {
            var users = (from u in context.Users
                         join ur in context.UserRoles on u.Id equals ur.UserId
                         join r in context.Roles on ur.RoleId equals r.Id
                         where !u.IsDeleted && !ur.IsDeleted && !r.IsDeleted
                         orderby u.CreatedOn descending
                         select new UserViewModel
                         {
                             Id = u.Id,
                             RoleId = r.Id,
                             Name = u.Name,
                             UserName = u.UserName,
                             RoleName = r.Name,
                             Gender = u.Gender,
                             MobileNumber = u.MobileNumber,
                             Email = u.Email,
                             Password = u.Password
                         }).ToList();
            return users;
        }
    }
}
public interface IUserRepository
{
    IQueryable<User> Collection();
    void Insert(User user);
    void Commit();
    User Find(Guid Id);
    void Update(User user);
    void UpdateUserRole(UserRole userRole);
    void Delete(Guid Id);
    List<UserViewModel> GetUsers();
    UserViewModel GetUserById(Guid Id);
}
