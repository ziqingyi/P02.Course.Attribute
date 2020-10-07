using P23.Course.IOC.DAL;
using P23.Course.IOC.IBLL;
using P23.Course.IOC.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P23.Course.IOC.BLL
{
    public class BaseBll : IBaseBll
    {
        private IBaseDAL _baseDal = null;
        public BaseBll(IBaseDAL baseDal)
        {
            Console.WriteLine($"{nameof(BaseBll)} is being constructed...in thread : " + Thread.CurrentThread.ManagedThreadId);
            this._baseDal = baseDal;
        }
        public void DoSomething()
        {
            this._baseDal.Add();
            this._baseDal.Update();
            this._baseDal.Find();
            this._baseDal.Delete();
        }



    }
}
