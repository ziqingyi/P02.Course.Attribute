using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace P27.Course.DataStructure
{
    class CollectionDemo
    {
        public static void Show()
        {
            #region Array   multiple variables of the same type, fix length, fast read but update slow.

            Console.WriteLine("****************Array*******************");
            {
                int[] intArray = new int[3];
                intArray[0] = 123;
                string[] stringArray = new string[] { "123", "234" };
            }
            #endregion

            #region ArrayList    Not use ArrayList class for new development. use the generic List<T> class
            Console.WriteLine("*****************ArrayList******************");
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
            Console.WriteLine("****************List<T>*******************");
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
            Console.WriteLine("******************LinkedList*****************");
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
            Console.WriteLine("*****************Queue******************");
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
            Console.WriteLine("****************Stack*******************");
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

            #region Set    no index, unique, efficient in removing duplicates 
            Console.WriteLine("****************Set*******************");

            HashSet<string> hashSet = new HashSet<string>();
            hashSet.Add("123");
            hashSet.Add("325");
            hashSet.Add("23");
            hashSet.Add("23");
            Console.WriteLine(hashSet.Contains("23"));
            
            HashSet<string> hashset1 = new HashSet<string>();
            hashset1.Add("123");
            hashset1.Add("999");
            hashset1.Add("78");
            hashset1.Add("78");
            Console.WriteLine(hashset1.Contains("9"));

            hashSet.SymmetricExceptWith(hashset1);//325,23,   999,78 , used for recommendation for friends.

            hashSet.UnionWith(hashset1); // all five
            hashSet.ExceptWith(hashset1);//325,23    //Removes all elements in the specified collection from the current
            hashSet.ExceptWith(hashset1);//325,23
            hashSet.IntersectWith(hashset1);//0

            hashset1.ToList();
            hashset1.Clear();

            #endregion

            #region SortedSet
            Console.WriteLine("**************SortedSet*********************");

            SortedSet<string> sortedSet = new SortedSet<string>();
            sortedSet.Add("123");
            sortedSet.Add("666");
            sortedSet.Add("999");
            sortedSet.Add("666");
            sortedSet.Add("555");
            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(sortedSet.Contains("123"));

            SortedSet<string> sortedSet1 = new SortedSet<string>();
            sortedSet1.Add("123");
            sortedSet1.Add("689");
            sortedSet1.Add("232");
            sortedSet1.Add("111");
            sortedSet1.Add("000");

            sortedSet1.SymmetricExceptWith(sortedSet1);
            sortedSet1.UnionWith(sortedSet);
            sortedSet1.ExceptWith(sortedSet);
            sortedSet1.IntersectWith(sortedSet);

            #endregion

            #region key-value
            Console.WriteLine("**************key-value*********************");


            {
                Console.WriteLine("**************Hashtable*********************");
                //fast read, fast add/delete, if there are many collision, efficiency drop sharply.
                //all params are objects, so some boxing and unboxing. 
                Hashtable htable = new Hashtable();
                htable.Add("123","456");
                htable[234] = 456;
                htable[234] = 567;

                htable[1] = "456";

                foreach (DictionaryEntry entry in htable)
                {
                    Console.WriteLine("entry key: "+ entry.Key.ToString() +"entry value: " + entry.Value.ToString());
                }

                //thread safety, Returns a synchronized (thread-safe) wrapper for the Hashtable.
                Hashtable ht =  Hashtable.Synchronized(htable);

            }

            {
                Console.WriteLine("**************Dictionary*********************");


            }



            #endregion








        }

    }
}
