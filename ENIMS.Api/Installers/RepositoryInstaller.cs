using ENIMS.DataObjects.Models.MasterData;
using ENIMS.Core;
using ENIMS.DataObjects;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ENIMS.DataObjects.Models.MasterData;
using CargoProrationAPI.DataObjects.Models.MasterData;


namespace ENIMS.Api
{
    public class RepositoryInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            #region master data
            services.AddScoped(typeof(IRepositoryBase<CostCenter>), typeof(RepositoryBase<CostCenter>));
            services.AddScoped(typeof(IRepositoryBase<Person>), typeof(RepositoryBase<Person>));





            #endregion

            #region Operational

            #endregion

            #region report

            #endregion

            #region user managment
            services.AddScoped(typeof(IRepositoryBase<User>), typeof(RepositoryBase<User>));
            services.AddScoped(typeof(IRepositoryBase<UserToken>), typeof(RepositoryBase<UserToken>));
            services.AddScoped(typeof(IRepositoryBase<Privilege>), typeof(RepositoryBase<Privilege>));
            services.AddScoped(typeof(IRepositoryBase<RolePrivilege>), typeof(RepositoryBase<RolePrivilege>));
            services.AddScoped(typeof(IRepositoryBase<Role>), typeof(RepositoryBase<Role>));
            services.AddScoped(typeof(IRepositoryBase<ClientUser>), typeof(RepositoryBase<ClientUser>));
            services.AddScoped(typeof(IRepositoryBase<ClientUserToken>), typeof(RepositoryBase<ClientUserToken>));
            services.AddScoped(typeof(IRepositoryBase<ClientPrivilege>), typeof(RepositoryBase<ClientPrivilege>));
            services.AddScoped(typeof(IRepositoryBase<ClientRolePrivilege>), typeof(RepositoryBase<ClientRolePrivilege>));
            services.AddScoped(typeof(IRepositoryBase<ClientRole>), typeof(RepositoryBase<ClientRole>));
            services.AddScoped(typeof(IRepositoryBase<Menus>), typeof(RepositoryBase<Menus>));

            //
            services.AddScoped(typeof(IRepositoryBase<UserRole>), typeof(RepositoryBase<UserRole>));
            services.AddScoped(typeof(IRepositoryBase<Menu>), typeof(RepositoryBase<Menu>));

            //services.AddScoped(typeof(IRepositoryBase<User>), typeof(RepositoryBaseWork<User>));
            //services.AddScoped(typeof(IRepositoryBase<UserToken>), typeof(RepositoryBaseWork<UserToken>));
            //services.AddScoped(typeof(IRepositoryBase<Privilege>), typeof(RepositoryBaseWork<Privilege>));
            //services.AddScoped(typeof(IRepositoryBase<RolePrivilege>), typeof(RepositoryBaseWork<RolePrivilege>));
            //services.AddScoped(typeof(IRepositoryBase<Role>), typeof(RepositoryBaseWork<Role>));
            //services.AddScoped(typeof(IRepositoryBase<UserRole>), typeof(RepositoryBaseWork<UserRole>));
            //services.AddScoped(typeof(IRepositoryBase<Menu>), typeof(RepositoryBaseWork<Menu>));
            //services.AddScoped(typeof(IRepositoryBase<PasswordRecovery>), typeof(RepositoryBaseWork<PasswordRecovery>));
            //services.AddScoped(typeof(IRepositoryBase<EmailTemplate>), typeof(RepositoryBaseWork<EmailTemplate>));

            #endregion

            #region common
            services.AddScoped(typeof(IRepositoryBase<AccountSubscription>), typeof(RepositoryBase<AccountSubscription>));
            services.AddScoped(typeof(IRepositoryBase<PasswordService>), typeof(RepositoryBase<PasswordService>));
            services.AddScoped(typeof(IRepositoryBase<EmailTemplate>), typeof(RepositoryBase<EmailTemplate>));
            services.AddScoped(typeof(IRepositoryBase<MasterDataTransactionalHistory>), typeof(RepositoryBase<MasterDataTransactionalHistory>));
            #endregion

            #region subscription
            services.AddScoped(typeof(IRepositoryBase<AccountSubscription>), typeof(RepositoryBase<AccountSubscription>));
            //services.AddScoped(typeof(IRepositoryBase<AccountSubscriptionUser>), typeof(MasterRepositoryBase<AccountSubscriptionUser>));
            services.AddScoped(typeof(IRepositoryBase<PasswordRecovery>), typeof(RepositoryBase<PasswordRecovery>));
            #endregion

        }
    }
}