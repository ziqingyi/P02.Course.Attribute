﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace P02.Course.Attribute.ValidateExtend
{
    public abstract class AbstractValidateAttribute: System.Attribute
    {
        public abstract bool Validate(object oValue);
    }
}
