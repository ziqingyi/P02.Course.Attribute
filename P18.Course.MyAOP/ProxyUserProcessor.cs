using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P18.Course.MyAOP
{
    public class ProxyUserProcessor:IUserProcessor
    {
        private IUserProcessor _userProcessor = new UserProcessor();

        public void RegUser(User user)
        {
            BeforeProcess();
            this._userProcessor.RegUser(user);
            AfterProcess();
        }

        private void BeforeProcess()
        {
            Console.WriteLine("Before Registering user....");
        }

        private void AfterProcess()
        {
            Console.WriteLine("After Registering user....");
        }

    }
}
