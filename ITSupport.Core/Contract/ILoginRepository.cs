using ITSupport.Core.Models;
using ITSupport.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSupport.Core.Contract
{
    public interface ILoginRepository
    {

        User Login(LoginViewModel model);
    }
}
