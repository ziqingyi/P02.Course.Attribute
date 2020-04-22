using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Course.Generic.Extend
{

    public class variantTest
    {
        public static void Show()
        {
            {
                Bird bird1 = new Bird();
                Bird bird2 = new Sparrow();
                Sparrow sparrow1 = new Sparrow();
                //Sparrow sparrow2 = new Bird();
            }


            {
                List<Bird> birdList1 = new List<Bird>();
                //List<Bird> birdList2 = new List<Sparrow>();

                List<Bird> birdList3 = new List<Sparrow>().Select(c => (Bird)c).ToList();
            }



            {//
                IEnumerable<Bird> birdList1 = new List<Bird>();
                IEnumerable<Bird> birdList2 = new List<Sparrow>();

                Func<Bird> func = new Func<Sparrow>(() => null);

                ICustomerListOut<Bird> customerList1 = new CustomerListOut<Bird>();
                ICustomerListOut<Bird> customerList2 = new CustomerListOut<Sparrow>();
            }



            {//
                ICustomerListIn<Sparrow> customerList2 = new CustomerListIn<Sparrow>();
                ICustomerListIn<Sparrow> customerList1 = new CustomerListIn<Bird>();
                customerList1.Show(new Sparrow());
                //customerList1.Show(new Bird());//error

                ICustomerListIn<Bird> birdList1 = new CustomerListIn<Bird>();
                birdList1.Show(new Sparrow());
                birdList1.Show(new Bird());

                Action<Sparrow> act = new Action<Bird>((Bird i) => { });
            }


            {
                IMyList<Sparrow, Bird> myList1 = new MyList<Sparrow, Bird>();
                IMyList<Sparrow, Bird> myList2 = new MyList<Sparrow, Sparrow>();//
                IMyList<Sparrow, Bird> myList3 = new MyList<Bird, Bird>();//
                IMyList<Sparrow, Bird> myList4 = new MyList<Bird, Sparrow>();//
            }
        }
    }

    public class Bird
    {
        public int Id { get; set; }
    }
    public class Sparrow : Bird
    {
        public string Name { get; set; }
    }

    public interface ICustomerListIn<in T>
    {
        //T Get();

        void Show(T t);
    }

    public class CustomerListIn<T> : ICustomerListIn<T>
    {
        //public T Get()
        //{
        //    return default(T);
        //}

        public void Show(T t)
        {
        }
    }

    /// <summary>
    /// out
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICustomerListOut<out T>
    {
        T Get();

        //void Show(T t);
    }

    public class CustomerListOut<T> : ICustomerListOut<T>
    {
        public T Get()
        {
            return default(T);
        }

        public void printS()
        {
            Console.WriteLine("print s ");
        }

        //public void Show(T t)
        //{

        //}
    }





    public interface IMyList<in inT, out outT>
    {
        void Show(inT t);
        outT Get();
        outT Do(inT t);

        ////out 
        //void Show1(outT t);
        //inT Get1();

    }

    public class MyList<T1, T2> : IMyList<T1, T2>
    {

        public void Show(T1 t)
        {
            Console.WriteLine(t.GetType().Name);
        }

        public T2 Get()
        {
            Console.WriteLine(typeof(T2).Name);
            return default(T2);
        }

        public T2 Do(T1 t)
        {
            Console.WriteLine(t.GetType().Name);
            Console.WriteLine(typeof(T2).Name);
            return default(T2);
        }
    }

}
