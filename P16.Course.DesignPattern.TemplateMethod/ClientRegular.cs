using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P16.Course.DesignPattern.TemplateMethod
{
    public class ClientRegular : AbstractClient
    {
        public override double CalculateInterest(double balance)
        {
            return balance * 0.003;
        }
    }
}
