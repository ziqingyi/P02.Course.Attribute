using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P22.Course.IOC.DAL
{
    public class BaseDAL
    {
        public BaseDAL()
        {
            Console.WriteLine($"{nameof(BaseDAL)} is being constructed. ");
        }

        public void Add()
        {
            Console.WriteLine($"public method {nameof(Add)} ");
        }

        public void Delete()
        {
            Console.WriteLine($"public method {nameof(Delete)} ");
        }

        public void Find()
        {
            Console.WriteLine($"public method {nameof(Find)} ");
        }

        public void Update()
        {
            Console.WriteLine($"public method {nameof(Update)} ");
        }
    }
}
