using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.Course.Attribute.ValidateExtend
{
    [AttributeUsage(AttributeTargets.Property)]
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
            var val = long.TryParse(oValue.ToString(), out long lValue);
            bool test2 = lValue >= this._Min;
            bool test3 = lValue <= this._Max;

            return test1 && test2 && test3;
        }



    }
}
