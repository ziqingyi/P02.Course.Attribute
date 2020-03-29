using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.Course.Delegate
{
    public class MyDelegate
    {
        public delegate void NoReturnNoPara();

        public delegate void NoReturnWIthPara(int x, int y);

        public delegate int WithReturnNoPara();

        public delegate MyDelegate WithReturnWIthPara();

        public void Show()
        {

        }
    }
}
