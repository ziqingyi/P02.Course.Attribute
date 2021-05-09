using System;
using System.Collections.Generic;
using System.Text;
using static System.Math; //import static class

namespace P39.Course.dotnetCore.TestProject
{
    public class CSharp6
    {
        public string Name { get; set; } = "summit";
        public int Age { get; set; } = 22;
        public DateTime Birthday { get; set; } = DateTime.Now.AddYears(-20);
        public IList<int> AgeList { get; set; }=new List<int>() { 10, 20, 30, 40, 50 };

        public void Show(People peopleTest)
        {
            #region string interpolation

            string a1 = $"Age: {this.Age} Birthday:{this.Birthday.ToString("yyyy-MM-dd")}";
            string a2 = $"Age: {{this.Age}} Birthday:{{{this.Birthday.ToString("yyyy-MM-dd")}}}";

            var a3 = $"{(this.Age <= 20? "below 20":"over 20")}";

            Console.WriteLine(a1);
            Console.WriteLine(a2);
            Console.WriteLine(a3);
            #endregion


            #region Using Static Class

            Console.WriteLine($"use original way : {Math.Pow(4,2)}");
            Console.WriteLine($"use static class without mention class name: {Pow(4,2)}");

            #endregion

            #region Null-conditional operators

            int? iValue = null;
            Console.WriteLine(iValue.ToString());//no error 

            string name = null;
            Console.WriteLine(name?.ToString());//if null,will not execute ToString() method. name.ToString() will cause error.

            #endregion



            #region Index Initializers

            IDictionary<int,string> dictOld = new Dictionary<int, string>()
            {
                {1,"first"},
                {2,"second" }
            };

            IDictionary<int,string> dicNew = new Dictionary<int, string>()
            {
                [4] = "fourth",
                [5] ="second"
            };

            #endregion



            #region Exception Filters

            int exceptionValue = 10;
            try
            {
                Int32.Parse("s");
            }
            catch (Exception e) when (exceptionValue > 1)
            {
                Console.WriteLine(e);
                //throw;
            }

            #endregion



            #region  name of expression

            Console.WriteLine(nameof(peopleTest));// return just the name of variable "peopleTest"

            #endregion






        }




    }
}
