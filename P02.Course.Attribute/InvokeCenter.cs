using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.Course.Attribute
{
    public class InvokeCenter //<L> where L:Student
    {
        public static void ManagerStudent<T>(T student) where T : Student
        {
            Console.WriteLine($"{student.Id}____{student.Name}");
            student.Study();
            student.Answer("123");

            Type type = student.GetType();
            if(type.IsDefined(typeof(CustomAttribute), true))
            {
               object[] oAttributeArray =  type.GetCustomAttributes(typeof(CustomAttribute), true);
               foreach (CustomAttribute attribute in oAttributeArray)
               {
                   attribute.Show();
               }

               foreach (var prop in type.GetProperties())
               {
                   if (prop.IsDefined(typeof(CustomAttribute), true))
                   {
                       object[] oAttributeArrayProp = prop.GetCustomAttributes(typeof(CustomAttribute), true);
                       foreach (CustomAttribute attribute in oAttributeArrayProp)
                       {
                           attribute.Show();
                       }
                   }
               }

               foreach (var method in type.GetMethods())
               {
                   if (method.IsDefined(typeof(CustomAttribute), true))
                   {
                       object[] oAttributeArrayMethod = method.GetCustomAttributes(typeof(CustomAttribute), true);
                       foreach (CustomAttribute attribute in oAttributeArrayMethod)
                       {
                           attribute.Show();
                       }

                   }
               }
            }
        }

    }
}
