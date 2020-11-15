using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P28.Course.RedisBackService
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ServiceStackProcessor.Show();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.Read();
            }


        }
    }
}
