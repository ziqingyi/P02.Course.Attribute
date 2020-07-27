using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P18.Course.MyAOP.UnityAOPFolder
{
    public class UnityUserProcessor: IUnityUserProcessor
    {
        public void RegUser(User user)
        {
            Console.WriteLine("User {0} has registered successfully...", user.Name);
        }

        public User GetUser(User user)
        {
            return user;
        }

    }
}
