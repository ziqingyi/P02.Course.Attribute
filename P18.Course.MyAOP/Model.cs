using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P18.Course.MyAOP.UnityAOPFolder;

namespace P18.Course.MyAOP
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [StringLength(5,10)]
        public string Password { get; set; }
    }
}
