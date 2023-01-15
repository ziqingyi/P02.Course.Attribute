using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Course.Generic.ArrayExpandable
{
    internal class ArrayExpandableTest
    {

        public static void TestArrayExpandableObject()
        {

            var arrayStr = new ArrayExpandableByObject();
            var strs = new string[] { "ryzen", "reed", "wymen" };
            for (int i = 0; i < strs.Length; i++)
            {
                arrayStr.Add(strs[i]);
                string value = (string)arrayStr[i];//改为int value = (int)arrayStr[i] 运行时报错
                Console.WriteLine(value);
            }
            Console.WriteLine($"Now {nameof(arrayStr)} Capacity:{arrayStr.Capacity}");

            var array = new ArrayExpandableByObject();
            for (int i = 0; i < 5; i++)
            {
                array.Add(i);
                int value = (int)array[i];
                Console.WriteLine(value);
            }
            Console.WriteLine($"Now {nameof(array)} Capacity:{array.Capacity}");
        }



    }
}
