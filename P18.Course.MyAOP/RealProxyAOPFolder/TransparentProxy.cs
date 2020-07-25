using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P18.Course.MyAOP.RealProxyAOPFolder
{
    public static class TransparentProxy
    {
        //actually base class Real Proxy will help create derived(child) class object of T 
        //it will also implement IUserProcessor.
        public static T Create<T>()
        {
            T instance = Activator.CreateInstance<T>();
            MyRealProxy<T> realProxy = new MyRealProxy<T>(instance);
            T transparentProxy = (T) realProxy.GetTransparentProxy();
            return transparentProxy;
        }

    }
}
