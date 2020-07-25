using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P18.Course.MyAOP.RealProxyAOPFolder
{
    //must inherit from MarshalByRefObject, it
    //Enables access to objects across application domain boundaries in applications that support remoting.
    //means: RealProxyUserProcessor now Can be serialized to string and pass to remote applications. 
    //       then deserialized to RealProxyUserProcessor. at same time, add some logic before and after. 
    //Remoting is widely used in client side, now often use WebAPI
    class RealProxyUserProcessor :MarshalByRefObject, IUserProcessor
    {
        public void RegUser(User user)
        {
            Console.WriteLine("user {0}--{1} is being registered with password: {2}", 
                user.Id, user.Name, user.Password);
        }

        public void ShowInfo()
        {
            Console.WriteLine(typeof(RealProxyUserProcessor));
        }
    }
}
