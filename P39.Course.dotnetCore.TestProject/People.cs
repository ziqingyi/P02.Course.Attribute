using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P39.Course.dotnetCore.TestProject
{
    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static async Task Get()
        {
            await Task.Run(() =>
            {

                Thread.Sleep(5000);
                Console.WriteLine("People.async.Get");
            });
            Console.WriteLine("People.async.Get after");
        }
    }
}
