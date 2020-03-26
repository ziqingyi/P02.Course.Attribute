using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.Course.Attribute.ValidateExtend
{

    public class LongAttribute: AbstractValidateAttribute
    {
        private long _Min = 0;
        private long _Max = 0;

        public LongAttribute(long min, long max)
        {
            this._Min = min;
            this._Max = max;
        }

        public override bool Validate(object oValue)
        {
            bool test1 = oValue != null;

            bool test2 = oValue.ToString().Length > this._Min;
            bool test3 = oValue.ToString().Length > this._Max;

            return test1 && test2 && test3;

        }



    }
}
