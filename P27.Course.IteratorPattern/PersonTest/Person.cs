using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P27.Course.IteratorPattern.PersonTest
{
    public class Person
    {
        public Person(string fName, string lName)
        {
            FirstName = fName;
            LastName = lName;
        }

        public string FirstName;
        public string LastName;
    }
}
