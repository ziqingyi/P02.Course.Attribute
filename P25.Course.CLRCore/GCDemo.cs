﻿using System;
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

    /*
     1 new object(): each time you create a new object, the common language runtime allocates memory for the object from the managed heap. 
     When address space is not available in the managed heap,garbage collector perform a Collection in order to free some memory, then the runtime can allocate space for new objects.
     In Collection, it checks for objects in the managed heap that are no longer being used by the application and performs the necessary operations to reclaim their memory.
    
     2 GC.Collect :Forces an immediate garbage collection of all generations.

     3 Program exists. 
         
        GC is global, and all other threads must stop.
        Before a garbage collection starts, all managed threads are suspended except for the thread that triggered the garbage collection.
         
         */
    #endregion

    #region How GC works
    /*

    A garbage collection has the following phases:
    
        Marking : Finds and creates a list of all live objects.
        
        Relocating : Updates the references to the objects that will be compacted.
        
        Compacting : Reclaims the space occupied by the dead objects and compacts the surviving objects. 
                  The compacting phase moves objects that have survived a garbage collection toward the older end of the segment. 
                  (Ordinarily, the large object heap is not compacted, because copying large objects imposes a performance penalty.)

        The GC uses the following information to determine whether objects are live:
        
        Stack roots: Stack variables provided by the just-in-time (JIT) compiler and stack walker.
        Garbage collection handles: Handles that point to managed objects and that can be allocated by user code or by the CLR.
        Static data: Static objects in application domains that could be referencing other objects.

        In addition, there are unmanaged resources like file streams, network/database connections that you need to take special care of. 
        You need to use Finalizer & Dispose in this case. 

     */
    #endregion


    #region GC Strategy 
    /*
    In 1984 David Ungar came up with a generational hypothesis which gave birth to the generational garbage collectors:
    Young objects die young. Therefore reclamation algorithm should not waste time on old objects.
    Copying survivors is cheaper than scanning corpses.
    
        The heap is organized into generations so it can handle long-lived and short-lived objects. There are three generations of objects on the heap:
        
        Generation 0: This is the youngest generation and contains short-lived objects. 
        An example of a short-lived object is a temporary variable. Garbage collection occurs most frequently in this generation.
        Newly allocated objects form a new generation of objects and are implicitly Gen 0 collections unless they are large objects, in which case they go on the large object heap in a Gen 2 collection.
        Most objects are reclaimed for garbage collection in Gen 0 and do not survive to the next generation. Objects that survive a Gen 0 garbage collection are promoted to Gen 1.
        
        Generation 1: This generation contains short-lived objects and acts as a buffer between short-lived objects and long-lived objects. 
                     Objects that survive a Gen 1 garbage collection are promoted to Gen 2.
        Generation 2: This generation contains long-lived objects. 
                      An example of a long-lived object is an object in a server application that contains static data that lives for the duration of the process. 
                      Objects that survive a Gen 2 garbage collection remain in Gen 2.
        
        Collecting a generation means collecting objects in that generation and all its younger generations. 
        A Gen 2 garbage collection is also known as a full garbage collection because it reclaims all objects in all generations.


   */
    #endregion

    #region The large object heap on Windows systems
    /*
    
        If an object is greater than or equal to 85,000 bytes in size, it’s considered a large object. The runtime allocates it on the large object heap.

        The garbage collector is a generational collector. It has three generations: generation 0, generation 1, and generation 2. 
        
        The reason for having 3 generations is that, in a well-tuned app, most objects die in gen0. 
        For example, in a server app, the allocations associated with each request should die after the request is finished. 
        The in-flight allocation requests will make it into gen1 and die there. Essentially, gen1 acts as a buffer between young object areas and long-lived object areas.
        
        Small objects are always allocated in generation 0 and, depending on their lifetime, may be promoted to generation 1 or generation2. 
        Large objects are always allocated in generation 2.
        
        Large objects belong to generation 2 because they are collected only during a generation 2 collection. 
        When a generation is collected, all its younger generation(s) are also collected. 
        For example, when a generation 1 GC happens, both generation 1 and 0 are collected. 
        And when a generation 2 GC happens, the whole heap is collected. For this reason, a generation 2 GC is also called a full GC. 
        This article refers to generation 2 GC instead of full GC, but the terms are interchangeable.

     */


    #endregion

    #region     Destructors and the Dispose Pattern   --book




    #endregion



    public class GCDemo
    {
        private static Student _student = new Student()
        {
            Id = 123,
            Name = "studnet_1"
        };

        public static void Show()
        {
            {
                Student student = _student;
                StuClass cls = new StuClass()
                {
                    ClassId = 1,
                    ClassName = "Advanced Class"
                };
                student.stuclass = cls;
                int i = 3;


            }

            {
                //Forces an immediate garbage collection of all generations.
                GC.Collect();
            }

            {

                Student student = _student;
                StuClass cls = new StuClass()
                {
                    ClassId = 1,
                    ClassName = "Advanced Class"
                };
                student = null;//null will not trigger garbage collection, object is still there. 
                //generally speaking, setting variables to null to help the garbage collector is not recommended.
                //If it is deemed necessary, then an unusual condition exists and it should be carefully documented in the code.


                GC.Collect();

            }



        }


    }

    public class People : IDisposable
    {
        public string Remark { get; set; }

        public virtual void Dispose()
        {
            MyLog.Log($"execute dispose method in {this.GetType().Name}");
        }
    }

    public class StuClass : IDisposable
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }

        ~StuClass()
        {
            MyLog.Log($"execute ~ method in {this.GetType().Name}");
        }

        public void Dispose()
        {
            MyLog.Log($"execute dispose method in {this.GetType().Name}");
        }
    }

    public class Student : People, IDisposable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StuClass stuclass { get; set; }

        public void Study()
        {
            Console.WriteLine("student is studying.....");
        }

        ~Student()
        {
            MyLog.Log($"execute ~ method in {this.GetType().Name}");
        }

        public override void Dispose()
        {
            base.Dispose();
            if (this.stuclass != null)
            {
                this.stuclass.Dispose();
            }

            //Requests that the common language runtime not call the finalizer for the specified object.
            //finalizer must not be executed.
            GC.SuppressFinalize(this);

            MyLog.Log($"execute dispose method in {this.GetType().Name}");
        }


    }





}
