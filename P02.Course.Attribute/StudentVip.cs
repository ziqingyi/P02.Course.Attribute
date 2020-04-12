using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P02.Course.Attribute.ValidateExtend;

namespace P02.Course.Attribute
{
    [Custom(123,Remark = "VIP", Description = "VIP student")]
    [Serializable]
    public class StudentVip : Student
    {
        [Custom(123, Remark = "VIP", Description = "VIP student")]
        [StringLength(4,10)]
        public string VipGroup { get; set; }


        [Long(10000,100000)]
        public long QQ { get; set; }

        [Long(200_000,1_000_000)]
        [Required]
        public long Salary { get; set; }

        public new void Study()
        {
            Console.WriteLine($"--------vip------Name: {this.Name}-----------------");
        }

        [Custom(123, Remark = "VIP", Description = "VIP student")]
        public void Homework()
        {

        }
    }
}
