using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P23.Course.IOC.ServiceInterface
{
    public interface Itelephone
    {
        void Call();

        IMicrophone IMicrophone { get; set; }

        IHeadphone IHeadphone { get; set; }

        IPower IPower { get; set; }
    }
}
