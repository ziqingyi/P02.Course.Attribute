using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.Course.Attribute
{
    public class InvokeCenter
    {
        public static void ManagerStudent<T>(T student) where T : Student
        {
            Console.WriteLine($"{student.Id}____{student.Name}");
            student.Study();
            student.Answer("123");

            Type type = student.GetType();
            if(type.IsDefined(typeof(CustomAttribute), true))
            {
               object[] oAttributeZArray =  type.GetCustomAttributes(typeof(CustomAttribute), true);
               foreach (CustomAttribute attribute in oAttributeZArray)
               {
                   attribute.Show();
               }




            }
        }



    }
}
