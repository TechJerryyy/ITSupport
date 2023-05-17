using ITSupport.Core.Models;
using ITSupport.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITSupport.WebUI.ActionFilters
{
    public class AccessCode
    {
        public static bool CheckAccess(string formAccessCode, string action)
        {
            Guid currentRoleId = (Guid)HttpContext.Current.Session["RoleId"];
            if(currentRoleId!=null)
            {
                using (DataContext dbContext = new DataContext())
                {
                    Guid FormId = dbContext.Forms.Where(x => x.FormAccessCode == formAccessCode).Select(x => x.Id).FirstOrDefault();
                    Permission checkPermission = dbContext.Permissions.Where(x => x.RoleId == currentRoleId && x.FormId == FormId).FirstOrDefault();
                    if (checkPermission != null)
                    {
                        if ((bool)checkPermission.View == true)
                        {
                            CheckRights.View = (bool)checkPermission.View;
                            CheckRights.Insert = (bool)checkPermission.Insert;
                            CheckRights.Update = (bool)checkPermission.Update;
                            CheckRights.Delete = (bool)checkPermission.Delete;
                            if (action == CheckRights.IsView.ToString())
                            {
                                return (bool)checkPermission.View;
                            }
                            if (action == CheckRights.IsInsert.ToString())
                            {
                                return (bool)checkPermission.Insert;
                            }
                            if (action == CheckRights.IsUpdate.ToString())
                            {
                                return (bool)checkPermission.Update;
                            }
                            if (action == CheckRights.IsDelete.ToString())
                            {
                                return (bool)checkPermission.Delete;
                            }
                        }
                        else
                        {
                            CheckRights.View = false;
                            CheckRights.Insert = false;
                            CheckRights.Update = false;
                            CheckRights.Delete = false;
                        }
                        return false;
                    }
                    else
                    {   // when formrolemapping record not found, ( No permissions )
                        CheckRights.View = false;
                        CheckRights.Insert = false;
                        CheckRights.Update = false;
                        CheckRights.Delete = false;
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }
        public class PermissionOrder
        {
        }
    }
}