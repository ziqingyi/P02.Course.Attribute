using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P23.Course.IOC.Framework.DIOC
{
    public interface IXContainer
    {
        void RegisterType<TFrom, TTo>();
        T Resolve<T>();
    }

}
