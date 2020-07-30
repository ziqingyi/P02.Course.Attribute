using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P18.Course.MyAOP.UnityAOPFolder
{
    public class StringLengthAttribute:AbstractValidateAttribute
    {
         private int _min = 0;
         private int _max = 0;

         public StringLengthAttribute(int min, int max)
         {
             this._min = min;
             this._max = max;
         }

         public override bool Validate(Object oValue)
         {

             return oValue != null
                    && oValue.ToString().Length > this._min
                    && oValue.ToString().Length < this._max;
         }

    }
}
