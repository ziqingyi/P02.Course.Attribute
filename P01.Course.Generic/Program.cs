﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P01.Course.Generic.ArrayExpandable;
using P01.Course.Generic.Extend;

namespace P01.Course.Generic
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("---------TestArrayExpandableObject-----------");
            ArrayExpandableTest.TestArrayExpandableObject();


            Console.WriteLine("---------test generic cache-----------");
            //GenericCacheTest.Show();
            variantTest.Show();
            Console.WriteLine("--------test end--------------");



        }
}
}
