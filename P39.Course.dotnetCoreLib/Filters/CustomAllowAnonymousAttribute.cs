using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace P39.Course.dotnetCoreLib.Filters
{
    public class CustomAllowAnonymousAttribute :Attribute, IAllowAnonymous
    {


    }
}
