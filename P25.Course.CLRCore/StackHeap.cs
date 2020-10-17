using System;
using System.Collections.Generic;
using System.Linq;
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
