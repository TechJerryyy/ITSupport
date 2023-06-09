using ITSupport.Core.Interfaces;
using ITSupport.Core.Models;
using ITSupport.Services.Services;
using ITSupport.SQL.Repository;
using System;

using Unity;

namespace ITSupport.WebUI
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private readonly static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<ILoginService, LoginService>();
            container.RegisterType<ILoginRepository, LoginRepository>();

            container.RegisterType<IRoleRepository, RoleRepository>();
            container.RegisterType<IRoleService, RoleService>();

            container.RegisterType<IPermissionRepository, PermissionRepository>();
            container.RegisterType<IPermissionService, PermissionService>();

            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IUserService, UserService>();

            container.RegisterType<ICommonLookupService, CommonLookupService>();

            container.RegisterType<IFormMstRepository, FormMstRepository>();
            container.RegisterType<IFormMstService, FormMstService>();

            container.RegisterType<ITicketRepository, TicketRepository>();
            container.RegisterType<ITicketService, TicketService>();

            container.RegisterType<IRepository<Role>, SQLRepository<Role>>();
            container.RegisterType<IRepository<User>, SQLRepository<User>>();
            container.RegisterType<IRepository<UserRole>, SQLRepository<UserRole>>();
            container.RegisterType<IRepository<CommonLookup>, SQLRepository<CommonLookup>>();
            container.RegisterType<IRepository<FormMst>, SQLRepository<FormMst>>();
            container.RegisterType<IRepository<Ticket>, SQLRepository<Ticket>>();
            container.RegisterType<IRepository<TicketAttachment>, SQLRepository<TicketAttachment>>();
            container.RegisterType<IRepository<TicketComment>, SQLRepository<TicketComment>>();
            container.RegisterType<IRepository<TicketStatusHistory>, SQLRepository<TicketStatusHistory>>();

            container.RegisterType<IAuditLogRepository, AuditLogRepository>();
            container.RegisterType<IAuditLogService, AuditLogService>();
        }
    }
}