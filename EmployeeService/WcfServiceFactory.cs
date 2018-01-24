using Microsoft.Practices.Unity;
using Unity.Wcf;

namespace EmployeeService
{
    public class WcfServiceFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
            // register all your components with the container here
            container
               .RegisterType<IEmployeeService, EmployeeService>()
               .RegisterType<IRepository, EmployeeRepository>();
        }
    }
}