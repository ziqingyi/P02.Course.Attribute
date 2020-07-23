using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P18.Course.MyAOP.RealProxyAOPFolder
{
    class RealProxyUserProcessor:MarshalByRefObject, IUserProcessor
    {
        public void RegUser(User user)
        {
            Console.WriteLine("user {0}--{1} is being registered with password: {2}", 
                user.Id, user.Name, user.Password);
        }
    }
}
