using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Windsor;

namespace TestOk
{
    public class ContainerWrapper
    {
        private WindsorContainer container;

        private static ContainerWrapper instance;

        private ContainerWrapper()
        {
            container = new WindsorContainer();
            container.Install(new DependencyInstaller());
        }

        public static ContainerWrapper GetInstance()
        {
            return instance ??= new ContainerWrapper();
        }

        public T ResolveDependency<T>()
        {
            return container.Resolve<T>();
        }
    }
}
