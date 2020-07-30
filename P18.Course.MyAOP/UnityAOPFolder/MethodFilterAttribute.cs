using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P18.Course.MyAOP.UnityAOPFolder
{
    [AttributeUsage(AttributeTargets.All)]
    public class MethodFilterAttribute : Attribute
    {
        public MethodFilterAttribute(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
