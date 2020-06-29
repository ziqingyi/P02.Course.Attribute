using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P16.Course.DesignPattern.TemplateMethod
{
    public class ClientVIP:AbstractClient
    {

        public override double CalculateInterest(double balance)
        {
            return balance * 0.005;
        }
        // Override virtual method 
        public override void Show(string name, double balance, double interest)
        {
            Console.WriteLine("VIP:  {0}  ，balance is ：{1}，interest is : {2}",
                name, balance, interest);
        }


    }
}
