using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P27.Course.DataStructure
{
    class CollectionDemo
    {
        public static void Show()
        {
            #region Array   multiple variables of the same type, fix length, fast read but update slow.
            {
                int[] intArray = new int[3];
                intArray[0] = 123;
                string[] stringArray = new string[] { "123", "234" };
            }
            #endregion

            #region ArrayList    Not use ArrayList class for new development. use the generic List<T> class
            {
                //size is dynamically increased as required. memory location in sequence so fast read but update slow.
                // values are boxed into the object type

                ArrayList arrayList = new ArrayList();
                arrayList.Add("element1");
                arrayList.Add(new int[]{1,2,3});
                arrayList.Add(234);

                arrayList.RemoveAt(2);
                arrayList.Remove(234);

            }
            #endregion

            #region List<T>
            {
                //a strongly typed list of objects that can be accessed by index. Provides methods to search, sort, and manipulate lists.
                //Generic List is strongly typed, that is, it can store objects of the same type. There's no boxing, so it's more efficient.
                //objects are listed in sequence
                List<int> intList = new List<int>(){1,2,3,4};
                intList.Add(123);
                intList.Add(234);
                intList[0] = 777;
            }
            #endregion

            #region LinkedList 
            //every element has address for pre and post element. element can duplicate.
            //elements are not in sequence in memory, so take time to search.

            LinkedList<int> linkedList = new LinkedList<int>();
            linkedList.AddFirst(123);
            linkedList.AddLast(456);

            bool isContain = linkedList.Contains(123);
            LinkedListNode<int> node123 = linkedList.Find(123); // find the node
            linkedList.AddBefore(node123, 111);
            linkedList.AddAfter(node123, 222);

            linkedList.Remove(456);
            linkedList.Remove(node123);
            linkedList.RemoveFirst();
            linkedList.RemoveLast();
            linkedList.Clear();

            #endregion

            #region Queue  first in first out, log tasks can be put in queue.
            Queue<string> Queuenumbers = new Queue<string>();
            Queuenumbers.Enqueue("one");
            Queuenumbers.Enqueue("one");
            Queuenumbers.Enqueue("two");
            Queuenumbers.Enqueue("three");
            Queuenumbers.Enqueue("four");
            Queuenumbers.Enqueue("four");
            Queuenumbers.Enqueue("five");

            foreach (string num in Queuenumbers)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine($"Dequeuing '{Queuenumbers.Dequeue()}'");
            Console.WriteLine($"Peek at next item to dequeue:{Queuenumbers.Peek()} ");
            Console.WriteLine($"Dequeuing '{Queuenumbers.Dequeue()}'");

            Queue<string> queueCopy = new Queue<string>(Queuenumbers);

            Console.WriteLine($"queueCopy.Contains(\"four\") = {queueCopy.Contains("four")}");

            queueCopy.Clear();

            Console.WriteLine($"queueCopy.Count = {queueCopy.Count}");

            #endregion

            #region Stack    first in last out, used in Expression tree
            Stack<string> stackNums = new Stack<string>();
            stackNums.Push("one" );
            stackNums.Push("two" );
            stackNums.Push("three");
            stackNums.Push("four");
            stackNums.Push("five");

            Console.WriteLine($"Pop '{stackNums.Pop()}'");
            Console.WriteLine($"Peek at next item to dequeue: {stackNums.Peek()}");//获取不移除
            Console.WriteLine($"Pop '{stackNums.Pop()}'");

            Stack<string> stackCopy = new Stack<string>(stackNums);
            Console.WriteLine($"stackCopy.Contains(\"four\") = {stackCopy.Contains("four")}");
            stackCopy.Clear();
            Console.WriteLine($"stackCopy.Count = {stackCopy.Count}");



            #endregion













        }

    }
}
