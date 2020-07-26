using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P18.Course.MyAOP.UnityAOPFolder
{
    interface IUnityUserProcessor
    {
        [MethodFilterAttr("Method need to caching....")]
        void RegUser(User user);
        User GetUser(User user);
    }
}
