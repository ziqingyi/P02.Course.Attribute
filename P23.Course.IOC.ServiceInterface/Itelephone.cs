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

        IMicrophone iMicrophone { get; set; }

        IHeadphone iHeadphone { get; set; }

        IPower iPower { get; set; }
    }
}
