﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P21.Course.Lottery.Common
{
    public class RandomHelper
    {
        public int GetRandomNumDelay(int min, int max)
        {
            //Thread.Sleep(this.GetRandomNumber(500,1000));//if wait different time, may not check at same time.
            Thread.Sleep(100);// test duplicates if there is no lock. try to make threads check at same time. 
            //if different thread generate same number and check existing nums at same time, it will have duplicates. 
            return this.GetRandomNumber(min, max);
        }

        public int GetRandomNumber(int min, int max)
        {
            Guid guid = Guid.NewGuid();
            Guid g2 = new Guid();
            
            String sGuid = guid.ToString();

            int seed = DateTime.Now.Millisecond;

            for (int i = 0; i < sGuid.Length; i++)
            {
                switch (sGuid[i])
                {
                    case 'a':
                    case 'b':
                    case 'c':
                    case 'd':
                    case 'e':
                    case 'f':
                    case 'g':
                        seed += 1;
                        break;
                    case 'h':
                    case 'i':
                    case 'j':
                    case 'k':
                    case 'l':
                    case 'm':
                    case 'n':
                        seed = seed + 2;
                        break;
                    case 'o':
                    case 'p':
                    case 'q':
                    case 'r':
                    case 's':
                    case 't':
                        seed = seed + 3;
                        break;
                    case 'u':
                    case 'v':
                    case 'w':
                    case 'x':
                    case 'y':
                    case 'z':
                        seed += 3;
                        break;
                    default:
                        seed = seed + 4;
                        break;
                }
            } 
            //if multithreads run at same time, it will use same time as seed, so it may generate same random num.
            // so we create new seed.
            Random random = new Random(seed);
            // The inclusive lower bound of the random number returned.
            // The exclusive upper bound of the random number returned.
            int result = random.Next(min, max);
            
            return result;

        }

    }
}
