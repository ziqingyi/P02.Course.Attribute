using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Unity;

namespace P31.Course.SOA.WebAPI.Utility
{
    public class UnityDependencyResolver: IDependencyResolver
    {
        private IUnityContainer _unityContainer = null;

        public UnityDependencyResolver(IUnityContainer container)
        {
            _unityContainer = container;
        }

        public IDependencyScope BeginScope()// scope
        {
            //every scope have a child container(will not read config again).you can also use same container.

            return new UnityDependencyResolver(this._unityContainer.CreateChildContainer());

        }

        public object GetService(Type serviceType)
        {
            try
            {
                object o = ContainerFactory.Container.Resolve(serviceType);
                return o;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            var res = ContainerFactory.Container.ResolveAll(serviceType);
            return res;
        }

        public void Dispose()
        {
            this._unityContainer.Dispose();
        }

    }
}