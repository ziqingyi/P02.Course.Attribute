using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P27.Course.IteratorPattern.PersonTest;

namespace P27.Course.IteratorPattern.Show
{
    public class PersonShow
    {

        public static void Show()
        {
            Person[] personArray =
            {
                new Person("John", "Smith"), 
                new Person("Jim", "Johnson"), 
                new Person("Sue", "Rabon")
            };

            People peopleList = new People(personArray);

            Console.WriteLine("Test foreach");
            foreach (Person p in peopleList)
            {
                Console.WriteLine(p.FirstName + " " + p.LastName);
            }


            Console.WriteLine("Test while");

            var p2 = peopleList.GetEnumerator();
            while (p2.MoveNext())
            {
                var p3 = (Person)p2.Current;
                Console.WriteLine(p3.FirstName + " " + p3.LastName);
            }


            Console.WriteLine("Test Yield");

            PeopleYield peopleListYield = new PeopleYield(personArray);
            foreach (Person p in peopleListYield)
            {
                Console.WriteLine(p.FirstName + " " + p.LastName);
            }







            Console.ReadKey();



        }








    }
}
