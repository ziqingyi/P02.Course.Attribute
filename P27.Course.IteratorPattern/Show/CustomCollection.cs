using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P27.Course.IteratorPattern.Show
{
    public class CustomCollection
    {
        private int Get()
        {
            Thread.Sleep(500);
            return DateTime.Now.Second;
        }


        public List<int> GetData()
        {
            List<int> intList = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                intList.Add(this.Get());
            }

            return intList;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return Get();
            }
        }






    }
}
