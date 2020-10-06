using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P23.Course.IOC.Framework.DIOC
{
    public interface IXxContainer
    {
        void RegisterType<TFrom, TTo>(LifeTimeType lifeTimeType = LifeTimeType.Transient);
        T Resolve<T>();
    }
}
