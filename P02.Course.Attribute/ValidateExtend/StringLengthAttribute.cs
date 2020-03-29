using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.Course.Attribute.ValidateExtend
{
    public class StringLengthAttribute:AbstractValidateAttribute
    {
        private int _Min = 0;
        private int _Max = 0;

        public StringLengthAttribute(int min, int max)
        {
            this._Min = min;
            this._Max = max;
        }

        public override bool Validate(object oValue)
        {
            return oValue != null
                   && oValue.ToString().Length >= this._Min
                   && oValue.ToString().Length <= this._Max;
        }
    }
}
