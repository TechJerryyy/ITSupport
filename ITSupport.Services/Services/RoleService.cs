using ITSupport.Core.Models;
using ITSupport.Core.ViewModels;
using ITSupport.SQL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSupport.Services.Services
{
    public class RoleService : IRoleService
    {
        IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }


        public List<Role> GetRoleList()
        {
            return _roleRepository.Collection().Where(x => !x.IsDeleted).OrderByDescending(x => x.CreatedOn).ToList();
        }

        public string CreateRole(RoleViewModel model)
        {
            var codeCheck = _roleRepository.Collection().Where(x => x.Code == model.Code && !x.IsDeleted).Any();
            var roleCheck = _roleRepository.Collection().Where(x => x.Name == model.Name && !x.IsDeleted).Any();
            if (codeCheck)
            {
                return "Code already exists.";
            }
            if (roleCheck)
            {
                return "Role already exists.";
            }
            Role role = new Role();
            role.Code = model.Code.ToUpper().Trim();
            role.Name = model.Name;


            _roleRepository.Insert(role);
            _roleRepository.Commit();
            return null;
        }


        public string EditRole(RoleViewModel model)
        {
            var codeCheck = _roleRepository.Collection().Where(x => x.Id != model.Id && x.Code == model.Code && !x.IsDeleted).Any();
            var roleCheck = _roleRepository.Collection().Where(x => x.Id != model.Id && x.Name == model.Name && !x.IsDeleted).Any();
            if (codeCheck)
            {
                return "Code already exists.";
            }
            if (roleCheck)
            {
                return "Role already exists.";
            }
            var role = _roleRepository.Collection().Where(x => x.Id == model.Id).FirstOrDefault();
            role.Name = model.Name;
            role.Code = model.Code.ToUpper().Trim();
            role.UpdatedOn = DateTime.Now;

            _roleRepository.Update(role);
            _roleRepository.Commit();
            return null;
        }

        public RoleViewModel GetRole(Guid Id)
        {
            var role = _roleRepository.Find(Id);

            RoleViewModel model = new RoleViewModel();
            model.Id = role.Id;
            model.Name = role.Name;
            model.Code = role.Code.ToUpper().Trim();
            return model;
        }
        public void DeleteRole(RoleViewModel model)
        {
            var role = _roleRepository.Collection().Where(x => x.Id == model.Id).FirstOrDefault();
            role.IsDeleted = true;
            _roleRepository.Update(role);
            _roleRepository.Commit();
        }
    }

    public interface IRoleService
    {
        List<Role> GetRoleList();
        RoleViewModel GetRole(Guid Id);
        string CreateRole(RoleViewModel model);
        string EditRole(RoleViewModel model);
        void DeleteRole(RoleViewModel model);
    }
}

