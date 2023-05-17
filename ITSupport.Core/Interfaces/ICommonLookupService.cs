using ITSupport.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSupport.Core.Interfaces
{
    public interface ICommonLookupService
    {
        List<CommonLookup> GetCommonLookups();
        CommonLookup GetCommonLookup(Guid Id);
        CommonLookup Create(CommonLookup model);
        CommonLookup Edit(CommonLookup model);
        void Delete(CommonLookup model);
        List<CommonLookup> GetCommonLookupsByName(string configName);
    }
}
