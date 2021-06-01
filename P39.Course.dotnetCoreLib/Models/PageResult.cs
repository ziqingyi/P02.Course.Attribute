﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P39.Course.dotnetCoreLib.Models
{
    public class PageResult<T>
    {
        public int TotalCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public List<T> DataList { get; set; }
    }
}

