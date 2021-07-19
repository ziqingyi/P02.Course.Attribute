using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace P05.Course.ExpressionSty
{
    public class ExpressionTreeBlockExpression
    {
        public static void Show()
        {
            //Represents a block that contains a sequence of expressions where variables can be defined.

            MethodCallExpression mce = Expression.Call(
                null,
                typeof(Console).GetMethod("Write", new[] {typeof(string)}),
                Expression.Constant("helloWorld!"));

            ConstantExpression ce = Expression.Constant(42);

            BlockExpression blockExpr = Expression.Block(mce, ce);

            var lambdaExp = Expression.Lambda<Func<int>>(blockExpr);

            //two ways to call
            lambdaExp.Compile().Invoke();
            lambdaExp.Compile()();

        }

        //Expression tree and reflection
        public static void Show2()
        {
            var book1 = new Book("C# in Depth", "Jon Skeet", 500);
            var book2 = new Book("CLR via C#", "Jeffery Richter", 800);
            var booklist = new List<Book> {book1, book2};

            SetAllPropertyExp(booklist, "author", "you");

            foreach (var book in booklist)
            {
                Console.WriteLine(book.author);
            }

            Demo();
            Console.ReadKey();

        }

        static void Demo()
        {
            var booklist = new List<Book>();
            for (int i = 0; i < 1000000; i++)
            {
                booklist.Add(new Book("Book1", "author1", i));
            }

            var sw = new Stopwatch();
            sw.Start();
            SetAllPropertyExp(booklist, "pageCount", 200);

            sw.Stop();
            Console.WriteLine("Expression Tree：" + sw.ElapsedMilliseconds);

            sw.Restart();
            SetAllProperty(booklist, "pageCount", 200);
            sw.Stop();
            Console.WriteLine("Use Reflection：" + sw.ElapsedMilliseconds);

        }

        public static void SetAllPropertyExp<T, K>(List<T> data, string propertyName, K propertyValue)
        {
            if (!data.Any()) return;
            var propertyInfo = typeof(T).GetProperty(propertyName);

            if (propertyInfo == null) throw new Exception("Property Not Exists");
            if (!propertyInfo.CanWrite) throw new Exception("Write Operation not supported");

            //propertyValue variable
            var propValExpr = Expression.Parameter(propertyInfo.PropertyType, "propertyValue");

            //d variable
            var invokeObjExpr = Expression.Parameter(typeof(T), "d");
            var methodInfo = propertyInfo.GetSetMethod();

            //main expression
            var setMethodExpr = Expression.Call(invokeObjExpr, methodInfo, propValExpr);

            //Strong typed delegate
            var lambdaExp = Expression.Lambda<Action<T, K>>(setMethodExpr, invokeObjExpr, propValExpr);
            var del = lambdaExp.Compile();

            foreach (var d in data)
            {
                del(d, propertyValue);
            }
        }

        public static void SetAllProperty<T>(List<T> data, string propertyName, object propertyValue)
        {
            if (!data.Any()) return;
            var propertyInfo = typeof(T).GetProperty(propertyName);

            if (propertyInfo == null) throw new Exception("Property Not Exists");
            if (!propertyInfo.CanWrite) throw new Exception("Write Operation not supported");

            foreach (var d in data)
            {
                propertyInfo.SetValue(d, propertyValue, null);
            }
        }





        public class Book
        {
            public string name { get; set; }
            public string author { get; set; }
            public int pageCount { get; set; }

            public Book(string n, string a, int p)
            {
                name = n;
                author = a;
                pageCount = p;
            }
        }

    }

}