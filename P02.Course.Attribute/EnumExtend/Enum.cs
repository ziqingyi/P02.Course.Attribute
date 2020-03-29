using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.Course.Attribute.EnumExtend
{
    
    public enum UserState
    {
        //normal state user
        [Remark("Normal......")]
        Normal=0,

        [Remark("Freeze........")]
        Frozen =1,

        [Remark("Delete........")]
        Deleted = 2 

    }
}
