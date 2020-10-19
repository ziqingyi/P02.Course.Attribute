using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace P25.Course.CLRCore
{
    public class StackHeap
    {
        /*
           value types: bool,byte,char,,double,enum,float,int,long,sbyte,,struct,uint,ulong,ushort

           Reference types: class, interface, delegate, object, string




          Stack: most of value types are allocated on the stack.We can only use what's in the top box on the stack.
                            If the value type was declared as a variable inside a method then it's stored on the stack.
                            If the value type was declared as a method parameter then it's stored on the stack.
                            If the value type was declared as a member of a class then it's stored on the heap, along with its parent.
                            If the value type was declared as a member of a struct then it's stored wherever that struct is stored.

                stack is responsible for keeping track of where each thread is during the execution of our code 
                (or what's been called). You can think of stack as a thread "state" and each thread has its own stack.  
                thread use stack to store variables.  
                


          Heap: (no matter whether obj is in value type or not)all objects are allocated on the heap can be accessed from anywhere.
                 heap space is unique in program and shared by threads.
               
            value type's size is small and decided, so it can be in stack or heap. while reference type's size is undetermined, so
            it must be in heap. ref type may be free up so it cannot save its value type member to stack. 





             */

        public static void Show()
        {
            {
                // value type

                ValuePoint valuePoint;
                valuePoint.x = 123;
                Console.WriteLine(valuePoint.x);

                ValuePoint point = new ValuePoint();
            }

            {
                //reference type

                ReferencePoint refpoint = new ReferencePoint(123);
                // 1 new will allocate space in stack, create instance in heap.
                // 2 pass the reference to the constructor.
                // 3 execute constructor.
                // 4 return reference.



                Console.WriteLine(refpoint.x);

            }
            {
                //boxing and unboxing
                int i = 3;
                object oValue = i;
                int k = (int)oValue;
            }
            {
                //string memory 
                string s1 = "ss";
                string s2 = "tt";

                s2 = "ss";

                bool result1 = object.ReferenceEquals(s1,s2);//true, share same space

                s2 = "ss2";//allocate new space for s2, s1 will not be changed. 
                Console.WriteLine(s1);//still ss

                //string combined by StringBuilder
                string s3 = string.Format("s{0}", "s");
                bool result3 = object.ReferenceEquals(s1, s3); //false

                string half = "s";
                string s4 = "s" + half;
                bool result4 = object.ReferenceEquals(s1, s4);//false, store first then calculation. 


                string s5 = "s" + "s";
                bool result5 = object.ReferenceEquals(s1, s5);//true




                //the String Is Immutable,is read-only.
                //the space size of string is determined when creating it. (not like int, the size is fixed.)
                /*
                    Reason 1 - Array Data structure
                    Since array is used to store string values, CLR needs to create new array each and every time when string is changed due to array fixed size limitations.

                    Reason 2 - Security

                    Many parameters are represented as String in network connections, database connection, URLs, usernames/passwords etc. 
                    If string is immutable, these will be altered and may leads to serious issues.

                    Reason 3 - Synchronization and concurrency

                    Making String immutable automatically makes them thread safe thereby solving the synchronization issues.

                    Reason 4 - Caching

                    When Compiler optimizes your String objects, there are two objects having same value (x="Siva", and y="Siva") and 
                    you need only one string object (for both x and y, these two will point to the same object). We call this concept as string interning.

                    Reason 5 - Class loading

                    String is used as argument for class loading. If mutable, it could result in the wrong class being loaded.
                 */



            }
            {
                //Garbage Collection 

                /* Managed objects and UnManaged objects.

                Managed objects are created, managed and under scope of CLR, pure .NET code managed by runtime, 
                Anything that lies within .NET scope and under .NET framework classes such as string, int, bool variables are referred to as managed code.
                eg. reference types.

                UnManaged objects are created outside the control of .NET libraries and are not managed by CLR, 
                example of such unmanaged code is COM objects, file streams, connection objects, Interop objects. (Basically, third party libraries that are referred in .NET code.)
                eg. using(SqlConnection conn), the resource is disposed manually, which means the objects are unManaged. 
                */

                /* reachable and unreachable objects. unreachable ones will be free up. 

                When the garbage collector performs a collection, it releases the memory for objects that are no longer being used by the application.
                 
                It determines which objects are no longer being used by examining the application's roots. 
                
                An application's roots include static fields, local variables and parameters on a thread's stack, and CPU registers. 
                
                Each root either refers to an object on the managed heap or is set to null. 
                
                The garbage collector has access to the list of active roots that the just-in-time (JIT) compiler and the runtime maintain. 
                
                Using this list, the garbage collector creates a graph that contains all the objects that are reachable from the roots.
                
                Objects that are not in the graph are unreachable from the application's roots. 
                
                The garbage collector considers unreachable objects garbage and releases the memory allocated for them. 
                
                */

            }

            {
                //objects on heap: Memory allocation

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
            }

            



        }
    }


    public struct ValuePoint  // : System.ValueType   implicitly inherit from ValueType, cannot inherit other parent class
    {
        public int x;
        public string Text; // in value type, there is a field with reference type, the object is located on heap. 

        public ValuePoint(int xx)
        {
            this.x = xx;
            this.Text = "1234";
        }
    }

    public class ReferencePoint
    {
        public int x;

        public ReferencePoint(int xx)
        {
            this.x = xx;
        }
    }












}
