using System;

namespace P39.Course.dotnetCore.TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**************Text C# 6************************"); ;
            CSharp6 six = new CSharp6();
            People peopleSix = new People()
            {
                Id=505,
                Name = "Test6"
            };
            six.Show(peopleSix);

            Console.WriteLine("**************Text C# 7************************"); ;

            CSharp7 seven = new CSharp7();
            seven.Show();


        }
    }
}
