using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace P02.Course.Attribute
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true,Inherited = true)]
    public class CustomAttribute : System.Attribute
    {
        public CustomAttribute()
        {
            Console.WriteLine($"{this.GetType().Name}  no param construct");
        }

        public CustomAttribute(int id)
        {
            this._Id = id;
            Console.WriteLine($"{this.GetType().Name} int param construct");
        }

        public CustomAttribute(string name)
        {
            this._Name = name;
            Console.WriteLine($"{this.GetType().Name} string param contruct");
        }

        private int _Id = 0;
        private string _Name = null;

        public string Remark;
        public string Description { get; set; }

        public void Show()
        {
            Console.WriteLine($"{this._Id} _ {this._Name} _ {this.Remark} _ {this.Description}");
        }


    }

    public class CustomAttributeChild : CustomAttribute
    {
        public CustomAttributeChild() : base(123)
        { }
    }



}
