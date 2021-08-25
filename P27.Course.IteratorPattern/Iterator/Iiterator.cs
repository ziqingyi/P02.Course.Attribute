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


    /*
     //
    // Summary:
    //     Supports a simple iteration over a non-generic collection.
    [ComVisible(true)]
    [Guid("496B0ABF-CDEE-11d3-88E8-00902754C43A")]
    public interface IEnumerator
    {
        //
        // Summary:
        //     Gets the element in the collection at the current position of the enumerator.
        //
        // Returns:
        //     The element in the collection at the current position of the enumerator.
        object Current { get; }

        //
        // Summary:
        //     Advances the enumerator to the next element of the collection.
        //
        // Returns:
        //     true if the enumerator was successfully advanced to the next element; false if
        //     the enumerator has passed the end of the collection.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     The collection was modified after the enumerator was created.
        bool MoveNext();
        //
        // Summary:
        //     Sets the enumerator to its initial position, which is before the first element
        //     in the collection.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     The collection was modified after the enumerator was created.
        void Reset();
    }
     *
     */

}
