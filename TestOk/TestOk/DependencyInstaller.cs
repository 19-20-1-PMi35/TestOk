using Castle.Core.Configuration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using BusinessLayer;
using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using Microsoft.CodeAnalysis.Host;

namespace TestOk
{
    public class DependencyInstaller: IWindsorInstaller
    {
        //add your dependencies here:
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ITestService>().ImplementedBy<TestService>());
            container.Register(Component.For<ITestRepository>().ImplementedBy<TestRepository>());
        }
    }
}
