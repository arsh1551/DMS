using RepositoryLayer.Interfaces;
using RepositoryLayer.Repositories;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.Emails;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace DMS
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            //// e.g. container.RegisterType<ITestService, TestService>();
            //container.RegisterType<ITestRepository, TestRepository>();
            //container.RegisterType<ITestService, TestService>();
            container.RegisterType<IMessageFormatter, HtmlMessageFormatter>();
            container.RegisterType<IMessageSender, EmailMessageSender>();
            container.RegisterType<IAccountRepository, AccountRepository>();
            container.RegisterType<IAccountRepository, AccountRepository>();
            container.RegisterType<IClientRepository, ClientRepository>();
            container.RegisterType<IAccountRepository, AccountRepository>();
            container.RegisterType<IConfig, Config>();
            container.RegisterType<IEmailService, ServiceLayer.Services.EmailService>();
            container.RegisterType<IAccountService, AccountService>();
            container.RegisterType<IClientService, ClientService>();
            container.RegisterType<IFirmService, FirmService>();
            container.RegisterType<IFirmRepository, FirmRepository>();
            container.RegisterType<IIndividualRepository, IndividualRepository>();
            container.RegisterType<IIndividualService, IndividualService>();
            container.RegisterType<IEmployeeService, EmployeeService>();
            container.RegisterType<IEmployeesRepository, EmployeesRepository>();
            container.RegisterType<IUsersRoleRepository, UsersRoleRepository>();
            container.RegisterType<IUsersRoleService, UsersRoleService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}