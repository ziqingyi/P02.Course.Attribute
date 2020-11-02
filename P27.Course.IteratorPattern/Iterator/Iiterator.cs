using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P27.Course.IteratorPattern.Iterator
{
    public interface Iiterator<T>
    {
        //current object
        T Current { get; }


        //Move to next object
        bool MoveNext();


        //reset
        void Reset();

    }
}
