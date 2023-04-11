using ITSupport.Core.Contract;
using ITSupport.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSupport.Services.Services
{
    public class CommonLookupService : ICommonLookupService
    {
        private readonly IRepository<CommonLookup> _commonLookupRepository;
        public CommonLookupService(IRepository<CommonLookup> commonLookupRepository)
        {
            _commonLookupRepository = commonLookupRepository;
        }


        public CommonLookup GetCommonLookup(Guid Id)
        {
            var commonLookup = _commonLookupRepository.Find(Id);
            return commonLookup;
        }

        public CommonLookup Create(CommonLookup model)
        {
            var commonLookupData = _commonLookupRepository.Collection().Where(x => x.ConfigName == model.ConfigName && x.ConfigKey == model.ConfigKey && !x.IsDeleted).FirstOrDefault();
            if (commonLookupData == null)
            {

                CommonLookup commonLookup = new CommonLookup
                {
                    ConfigKey = model.ConfigKey,
                    ConfigName = model.ConfigName,
                    ConfigValue = model.ConfigValue,
                    Description = model.Description,
                    DisplayOrder = model.DisplayOrder,
                    IsActive = model.IsActive
                };


                _commonLookupRepository.Insert(commonLookup);
                _commonLookupRepository.Commit();
                return commonLookup;
            }
            else
            {
                return null;
            }
        }

        public void Delete(CommonLookup model)
        {
            var commonLookup = _commonLookupRepository.Collection().Where(x => x.Id == model.Id).FirstOrDefault();
            commonLookup.IsDeleted = true;

            _commonLookupRepository.Update(commonLookup);
            _commonLookupRepository.Commit();
        }

        public CommonLookup Edit(CommonLookup model)
        {

            var commonLookupData = _commonLookupRepository.Collection().Where(x => x.Id != model.Id && x.ConfigName == model.ConfigName && x.ConfigKey == model.ConfigKey && !x.IsDeleted).Any();

            if (!commonLookupData)
            {
                var commonLookup = _commonLookupRepository.Collection().Where(x => x.Id == model.Id).FirstOrDefault();

                commonLookup.ConfigKey = model.ConfigKey;
                commonLookup.ConfigName = model.ConfigName;
                commonLookup.ConfigValue = model.ConfigValue;
                commonLookup.Description = model.Description;
                commonLookup.DisplayOrder = model.DisplayOrder;
                commonLookup.IsActive = model.IsActive;
                commonLookup.UpdatedOn = DateTime.Now;

                _commonLookupRepository.Update(commonLookup);
                _commonLookupRepository.Commit();
                return commonLookup;
            }
            else
            {
                return null;
            }
        }

        public List<CommonLookup> GetCommonLookups()
        {
            return _commonLookupRepository.Collection().Where(x => !x.IsDeleted).OrderByDescending(x => x.CreatedOn).ToList();
        }
    }
}