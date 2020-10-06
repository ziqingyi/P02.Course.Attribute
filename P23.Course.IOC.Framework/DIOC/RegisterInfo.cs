using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P23.Course.IOC.Framework.DIOC
{
    public class RegisterInfo
    {
        public Type TargetType { get; set; }
        public LifeTimeType LifeTime { get; set; }
    }

    public enum LifeTimeType
    {
        Transient,
        Singletone,
        PerThread
    }


}
