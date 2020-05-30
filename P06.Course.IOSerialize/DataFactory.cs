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
        private string Language { get; set; }
        public string Description { get; set; }
    }
    public class DataFactory
    {
        public static List<Programmer> BuildProgrammerList()
        {
            List<Programmer> list = new List<Programmer>();
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "advanced class",
                Name = "s1",
                Sex = "male"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "advanced class",
                Name = "s2",
                Sex = "male"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "advanced class",
                Name = "s3",
                Sex = "male"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "advanced class",
                Name = "s4",
                Sex = "male"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "advanced class",
                Name = "s5",
                Sex = "male"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "advanced class",
                Name = "s6",
                Sex = "male"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "advanced class",
                Name = "s7",
                Sex = "male"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "advanced class",
                Name = "s8",
                Sex = "male"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "advanced class",
                Name = "s9",
                Sex = "female"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "advanced class",
                Name = "s10",
                Sex = "female"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "advanced class",
                Name = "s11",
                Sex = "male"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "advanced class",
                Name = "s12",
                Sex = "male"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "advanced class",
                Name = "s13",
                Sex = "male"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "advanced class",
                Name = "s14",
                Sex = "female"
            });

            return list;
        }



    }
}
