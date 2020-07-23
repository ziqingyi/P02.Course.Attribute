using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P18.Course.MyAOP.ProxyAOPFolder
{
    public class ProxyAOP
    {
        public static void Show()
        {
            User user = new User()
            {
                Id = 2,
                Name = "User2",
                Password = "23125342"
            };

            Console.WriteLine("--------------Normal user processor--------");
            IUserProcessor processor = new UserProcessor();
            processor.RegUser(user);

            Console.WriteLine("-------------Proxy--------------------");
            processor = new ProxyUserProcessor();
            processor.RegUser(user);








        }
    }
}
