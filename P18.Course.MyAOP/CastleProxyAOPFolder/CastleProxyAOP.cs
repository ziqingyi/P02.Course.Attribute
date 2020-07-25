using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace P18.Course.MyAOP.CastleProxyAOPFolder
{
    public class CastleProxyAOP
    {
        public static void Show()
        {
            User user = new User()
            {
                Id = 6,
                Name = "user6",
                Password = "24314kh2l1hl"
            };

            ProxyGenerator generator = new ProxyGenerator();
            MyInterceptor interceptor = new MyInterceptor();
            CastleProxyUserProcessor userProcessor = generator.CreateClassProxy<CastleProxyUserProcessor>(interceptor);
            userProcessor.RegUser(user);
            userProcessor.intro();

        }




    }
}
