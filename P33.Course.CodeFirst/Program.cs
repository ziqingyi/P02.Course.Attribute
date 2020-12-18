using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P33.Course.CodeFirst
{
    class Program
    {
        //code first from business logic
        //it will create new database with tables based on the classes. 
        static void Main(string[] args)
        {
            try
            {
                using (CodeFirstModel context = new CodeFirstModel())
                {
                    JDCommodity001 commodity001 = context.JD_Commodity_001.Find(5);



                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
