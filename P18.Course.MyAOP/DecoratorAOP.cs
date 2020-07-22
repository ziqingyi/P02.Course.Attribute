using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace P18.Course.MyAOP
{
    public class DecoratorAOP
    {
        public static void Show()
        {
            User user = new User()
            {
                Id = 1,
                Password = "231123",
                Name = "User1"
            };
            Console.WriteLine("--------------Normal user processor--------");
            IUserProcessor processor = new UserProcessor();
            processor.RegUser(user);

            Console.WriteLine("-------------Decorator--------------------");
            processor = new UserProcessorDecorator(processor);
            processor.RegUser(user);

        }


    }
}
