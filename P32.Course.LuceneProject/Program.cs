using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P32.Course.LuceneProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*************Lucene InitIndex*********************");
            LuceneTest.InitIndex();

            Console.WriteLine("*************Lucene Show*********************");
            LuceneTest.Show();


        }
    }
}
