﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P02.Course.Attribute.EnumExtend;

namespace P02.Course.Attribute
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------Attribute --------------");

            Student s = new Student()
            {
                Id = 123,
                Name = ""
            };
            s.Study();
            s.Answer(" Tom ");

            #region MyRegion

            UserState userState = UserState.Frozen;


            #endregion

        }
    }
}
