using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P18.Course.MyAOP.CastleProxyAOPFolder
{
    public class CastleProxyUserProcessor:IUserProcessor
    {
        // must be virtual
        public virtual void RegUser(User user)
        { 
            Console.WriteLine("user {0}--{1} is being registered with password: {2}",
                user.Id, user.Name, user.Password);
        }

        public virtual void intro()
        {
            Console.WriteLine("this is : {0} ", typeof(CastleProxyUserProcessor));
        }
    }
}
