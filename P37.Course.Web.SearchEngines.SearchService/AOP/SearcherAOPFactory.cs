using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Interception;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;

namespace P37.Course.Web.SearchEngines.SearchService.AOP
{
    public class SearcherAOPFactory
    {
        private static IUnityContainer container = null;
        static SearcherAOPFactory()
        {
            container = new UnityContainer();
            container.RegisterType<ISearcherAOP, SearcherAOP>();//declare UnityContainer and register IUserProcessor
            container.AddNewExtension<Interception>().Configure<Interception>().SetInterceptorFor<ISearcherAOP>(new InterfaceInterceptor());
        }

        public static ISearcherAOP CreateInstance()
        {
            return container.Resolve<ISearcherAOP>();
        }
    }
}
