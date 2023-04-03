using ITSupport.Core.Contract;
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
    public class LoginRepository : ILoginRepository
    {

        internal DataContext context;
        internal DbSet dbSet;

        public LoginRepository(DataContext context)
        {
            this.context = context;
        }

        public User Login(LoginViewModel model)
        {
            var user = context.Users.Where(x => x.Email == model.Email && !x.IsDeleted).FirstOrDefault();
            return user;
        }


    }
}
