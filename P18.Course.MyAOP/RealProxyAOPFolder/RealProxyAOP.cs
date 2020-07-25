using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P18.Course.MyAOP.RealProxyAOPFolder
{
    public class RealProxyAOP
    {
        public static void Show()
        {
            User user = new User()
            {
                Id = 3,
                Name = "user3",
                Password = "a34123afda"
            };
            Console.WriteLine("--------------Normal user processor--------");
            UserProcessor processor = new UserProcessor();
            processor.RegUser(user);

            Console.WriteLine("-------------Real Proxy AOP--------------------");
            IUserProcessor realProxyUserProcessor = TransparentProxy.Create<RealProxyUserProcessor>();
            realProxyUserProcessor.RegUser(user);
            // all the method being called with be transfer to RealProxy's Invoke method, adding extra logic.
            RealProxyUserProcessor testOtherMethod = (RealProxyUserProcessor) realProxyUserProcessor;
            testOtherMethod.ShowInfo();
        }


    }
}
