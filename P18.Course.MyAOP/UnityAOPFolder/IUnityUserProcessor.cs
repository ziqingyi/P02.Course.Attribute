using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P18.Course.MyAOP.UnityAOPFolder
{
    public interface IUnityUserProcessor
    {
        
        void RegUser(User user);
        User GetUser(User user);

        [MethodFilter("Method need to caching....")]
        string GetUserPass(User user);

    }
}
