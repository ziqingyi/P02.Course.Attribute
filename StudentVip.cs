using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.Course.Attribute
{
    [Custom(123,Remark = "VIP", Description = "VIP student")]
    [Serializable]
    public class StudentVip : Student
    {
        [Custom(123, Remark = "VIP", Description = "VIP student")]
        public string VipGroup { get; set; }

        [Custom(123, Remark = "VIP", Description = "VIP student")]
        public void Homework()
        {

        }

    }
}
