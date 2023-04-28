using ITSupport.Core.Interfaces;
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
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;
        public PermissionService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }
        public List<PermissionViewModel> GetPermission(Guid RoleId)
        {      
            return _permissionRepository.GetPermission(RoleId).ToList();
        }
        public void UpdatePermission(List<Permission> permissions)
        {
            _permissionRepository.InsertRange(permissions);
        }
    }
    public interface IPermissionService
    {
        List<PermissionViewModel> GetPermission(Guid RoleId);
        void UpdatePermission(List<Permission> permissions);
    }
}
