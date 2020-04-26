using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Course.Model
{
    public class People
    {
        public People()
        {
            Console.WriteLine("{0} is being created.", this.GetType().FullName);
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public string Description;
    }
}
