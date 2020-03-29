using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace P02.Course.Attribute
{
    [Custom]
    [Custom()]
    [Custom(Remark = "123")]
    [Custom(Remark = "123", Description = "456")]
    [Custom(0)]
    [Custom(0, Remark = "123")]
    [Custom(0, Remark = "123", Description = "456")]
    public class Student
    {
        [Custom]
        public int Id { get; set; }
        public string Name { get; set; }
        [Custom]
        public void Study()
        {
            Console.WriteLine($"--------------Name: {this.Name}-----------------");
        }

        [return: Custom, Custom, Custom(), Custom(0, Remark = "123", Description = "456")]
        [Custom(0)]
        [Custom(0, Remark = "123")]
        [Custom(0, Remark = "123", Description = "456")]
        public string Answer([Custom]string name)
        {
            Console.WriteLine($"This is {name}");
            return $"This is {name}";
        }
    }
}
