using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Interception;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;

namespace P18.Course.MyAOP.UnityAOPFolder2
{
    public class UnityAOP
    {
        public static void Show()
        {
            User user = new User()
            {
                Id = 7,
                Name = "user7",
                Password = "afdr34354yt"
            };

            IUnityContainer container = new UnityContainer();// a container
            container.RegisterType<IUnityUserProcessor2, UnityUserProcessor2>();
            IUnityUserProcessor2 processor2 = container.Resolve<IUnityUserProcessor2>();
            processor2.RegUser(user);

            container.AddNewExtension<Interception>();
            container.RegisterType<IUnityUserProcessor2, UnityUserProcessor2>()
                .Configure<Interception>()
                .SetInterceptorFor<IUnityUserProcessor2>(new InterfaceInterceptor());

            IUnityUserProcessor2 userProcessor2 = new UnityUserProcessor2();
            IUnityUserProcessor2 userProcessor22 = container.Resolve<IUnityUserProcessor2>();
            userProcessor2.RegUser(user);
            User u = userProcessor2.GetUser(user);

            Console.WriteLine(u.Name);
        }


    }
}
