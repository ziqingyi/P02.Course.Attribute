﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06.Course.IOSerialize
{
    public class Constant
    {
        //get absolute path
        public static string LogPath = ConfigurationManager.AppSettings["LogPath"];
        public static string LogMovePath = ConfigurationManager.AppSettings["LogMovePath"];

        //get serialized data path
        public static string SerializeDataPath = ConfigurationManager.AppSettings["SerializeDataPath"];

    }
}
