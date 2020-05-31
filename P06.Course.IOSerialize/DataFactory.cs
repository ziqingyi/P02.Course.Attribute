using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06.Course.IOSerialize
{
    [Serializable]//must have this attribute for serialized class 
    public class Person
    {
        [NonSerialized]
        public int Id = 1;
        public string Name { get; set; }
        public string Sex { get; set; }
    }
    [Serializable]
    public class Programmer : Person
    {
        private string _language;

        public string Language
        {
            get
            {
                return "Can develop with: "+ _language;
            }
            set
            {
                _language = value;
            }
        }
        public string Description { get; set; }
    }
    public class DataFactory
    {
        public static List<Programmer> list = new List<Programmer>();
        static DataFactory()
        {
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "advanced class",
                Language ="Java",
                Name = "s1",
                Sex = "male"
            });
            list.Add(new Programmer()
            {
                Id = 2,
                Description = "advanced class",
                Language = "Java",
                Name = "s2",
                Sex = "male"
            });
            list.Add(new Programmer()
            {
                Id = 3,
                Description = "advanced class",
                Language = "C#",
                Name = "s3",
                Sex = "male"
            });
            list.Add(new Programmer()
            {
                Id = 4,
                Description = "middle class",
                Language = "C",
                Name = "s4",
                Sex = "male"
            });
            list.Add(new Programmer()
            {
                Id = 5,
                Description = "advanced class",
                Language = "Go",
                Name = "s5",
                Sex = "male"
            });
            list.Add(new Programmer()
            {
                Id = 6,
                Description = "advanced class",
                Language = "Perl",
                Name = "s6",
                Sex = "male"
            });
            list.Add(new Programmer()
            {
                Id = 7,
                Description = "middle class",
                Language = "C#",
                Name = "s7",
                Sex = "male"
            });
            list.Add(new Programmer()
            {
                Id = 8,
                Description = "advanced class",
                Language = "C#",
                Name = "s8",
                Sex = "male"
            });
            list.Add(new Programmer()
            {
                Id = 9,
                Description = "advanced class",
                Language = "Python",
                Name = "s9",
                Sex = "female"
            });
            list.Add(new Programmer()
            {
                Id = 10,
                Description = "advanced class",
                Language = "C#",
                Name = "s10",
                Sex = "female"
            });
            list.Add(new Programmer()
            {
                Id = 11,
                Description = "middle class",
                Language = "C#",
                Name = "s11",
                Sex = "male"
            });
            list.Add(new Programmer()
            {
                Id = 12,
                Description = "advanced class",
                Language = "SQL",
                Name = "s12",
                Sex = "male"
            });
            list.Add(new Programmer()
            {
                Id = 13,
                Description = "advanced class",
                Language = "Java",
                Name = "s13",
                Sex = "male"
            });
            list.Add(new Programmer()
            {
                Id = 14,
                Description = "advanced class",
                Language = "C#",
                Name = "s14",
                Sex = "female"
            });
            list.Add(new Programmer()
            {
                Id = 15,
                Description = "advanced class",
                Language = "C++",
                Name = "s15",
                Sex = "male"
            });
        }



    }
}
