using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P25.Course.CLRCore
{
    //Garbage Collection 
    #region Managed objects and UnManaged objects,  reachable and unreachable objects
    /* 
       Managed objects are created, managed and under scope of CLR, pure .NET code managed by runtime, 
       Anything that lies within .NET scope and under .NET framework classes such as string, int, bool variables are referred to as managed code.
       eg. reference types.

       UnManaged objects are created outside the control of .NET libraries and are not managed by CLR, 
       example of such unmanaged code is COM objects, file streams, connection objects, Interop objects. (Basically, third party libraries that are referred in .NET code.)
       eg. using(SqlConnection conn), the resource is disposed manually, which means the objects are unManaged. 
       */


    /*
         reachable and unreachable objects. unreachable ones will be free up. 
     
        When the garbage collector performs a collection, it releases the memory for objects that are no longer being used by the application.

        It determines which objects are no longer being used by examining the application's roots. 

        An application's roots include static fields, local variables and parameters on a thread's stack, and CPU registers. 

        Each root either refers to an object on the managed heap or is set to null. 

        The garbage collector has access to the list of active roots that the just-in-time (JIT) compiler and the runtime maintain. 

        Using this list, the garbage collector creates a graph that contains all the objects that are reachable from the roots.

        Objects that are not in the graph are unreachable from the application's roots. 

        The garbage collector considers unreachable objects garbage and releases the memory allocated for them. 

    */

    #endregion





    #region objects on heap: Memory allocation

    /*
    When you initialize a new process, the runtime reserves a contiguous region of address space for the process. 

    This reserved address space is called the managed heap. The managed heap maintains a pointer to the address where the next object in the heap will be allocated. 

    Initially, this pointer is set to the managed heap's base address. 

    All reference types are allocated on the managed heap. 

    When an application creates the first reference type, memory is allocated for the type at the base address of the managed heap. 

    When the application creates the next object, the garbage collector allocates memory for it in the address space immediately following the first object. 

    As long as address space is available, the garbage collector continues to allocate space for new objects in this manner.

    Allocating memory from the managed heap is faster than unmanaged memory allocation.

    Because the runtime allocates memory for an object by adding a value to a pointer, it's almost as fast as allocating memory from the stack. 

    In addition, because new objects that are allocated consecutively are stored contiguously in the managed heap, an application can access the objects quickly.

    */

    #endregion

    #region when GC is executed



    #endregion

    #region How GC works


    #endregion


    #region GC Strategy 


    #endregion


    public class GCDemo
    {

















    }
}
