using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P18.Course.MyAOP
{
    public class UserProcessorDecorator:IUserProcessor
    {
        private IUserProcessor _userProcessor { get; set; }

        public UserProcessorDecorator(IUserProcessor userProcessor)
        {
            this._userProcessor = userProcessor;
        }

        public void RegUser(User user)
        {
            BeforeProcess();
            this._userProcessor.RegUser(user);
            AfterProcess();
        }

        public void BeforeProcess()
        {
            Console.WriteLine("Before Registering user....");
        }

        public void AfterProcess()
        {
            Console.WriteLine("After Registering user....");
        }
    }
}
