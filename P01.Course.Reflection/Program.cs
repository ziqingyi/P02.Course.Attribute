﻿using P01.Course.DB.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using P01.Course.DB.MySql;
using P01.Course.DB.SqlServer;
using P01.Course.Model;


namespace P01.Course.Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Console.WriteLine("------------reflection------read the metadata of the dll or exe--------------");
                // reflection is to read the metadata of the dll or exe
                // pdb program debug base : used for debug 
                //reference is to copy the project when debug. but you need to copy all project referred by the project. 
                //{
                //    Console.WriteLine("---------common--------------");
                //    IDBHelper iDbHelper = new MySqlHelper();
                //    iDbHelper.Query();
                //}
                //{
                //    Console.WriteLine("------------reflection 1--------------------");
                //    Assembly a1 =   Assembly.Load("P01.Course.DB.MySql");//just dll name, find dll first then exe
                //   Assembly a2 = Assembly.LoadFile(
                //       @"C:\Users\adrian_sun\Source\Repos\ziqingyi\P02.Course.Attribute\P01.Course.Reflection\bin\Debug\P01.Course.DB.MySql.dll");
                //   // full path

                //   // load from current folder 
                //   Assembly a3 = Assembly.LoadFrom("P01.Course.DB.SqlServer.dll"); 
                //   Assembly a4 = Assembly.LoadFrom(
                //       @"C:\Users\adrian_sun\Source\Repos\ziqingyi\P02.Course.Attribute\P01.Course.Reflection\bin\Debug\P01.Course.DB.SqlServer.dll");
                //   foreach (var type in a1.GetTypes())
                //   {
                //       Console.WriteLine(type.Name);
                //       type.IsGenericType()// check whether it is generic type
                //       foreach (var method in type.GetMethods())
                //       {
                //           Console.WriteLine(method.Name);
                //       }
                //   }
                //}
                //{
                //    Console.WriteLine("------------reflection with create object--------------------");
                //    Assembly a1 = Assembly.Load("P01.Course.DB.MySql"); // 1 load with Assembly
                //    Type t = a1.GetType("P01.Course.DB.MySql.MySqlHelper"); // 2 get type

                //    // create the object by the type, then three ways to call the query method. 

                //    object o = Activator.CreateInstance(t);  // 3 createInstance
                //    //((MySqlHelper2)o).Query();               //4 transfer and call method
                //    ////() if o is not that class, it will through error: Unable to cast object  

                //    dynamic odInstance = Activator.CreateInstance(t);  // 3 create Instance
                //    odInstance.Query(); // bypass the compiler's check  // 4 call method

                //    object oo= Activator.CreateInstance(t);    // 3 createInstance
                //    IDBHelper iDbHelper = oo as MySqlHelper;  //4 transfer and call method
                //    iDbHelper.Query();
                //    // as will return null if not available.
                //}
                //{
                //    Console.WriteLine("--------------Encapsulation----reflection + factory + config----------------");

                //    IDBHelper iDbHelper =SimpleFactory.CreateInstance();
                //    iDbHelper.Query();
                //}
                //{
                //    Console.WriteLine(
                //        "--------------------create instance with different parameters---------------------");
                //    Assembly a1 = Assembly.Load("P01.Course.DB.SqlServerHelper");
                //    object test = a1.CreateInstance("SqlServerHelper"); //just test
                //    Type t = a1.GetType("P01.Course.DB.SqlServerHelper.ReflectionTest");

                //    foreach (ConstructorInfo ctor in t.GetConstructors())
                //    {
                //        Console.WriteLine(ctor.Name);
                //        foreach (var param in ctor.GetParameters())
                //        {
                //            Console.WriteLine(param.Name + " " + param.ParameterType);
                //        }
                //    }
                //    object o1 = Activator.CreateInstance(t);
                //    object o2 = Activator.CreateInstance(t, "name1");
                //    object o3 = Activator.CreateInstance(t, new object[] {123});
                //}
                //{
                //    Console.WriteLine("--------------create singleton, only one object--------------------");
                //    Singleton s1 = Singleton.GetInstance();
                //    Singleton s2 = Singleton.GetInstance();
                //    Console.WriteLine(object.ReferenceEquals(s1, s2));
                //}
                //{
                //    Console.WriteLine("------reflection to use private constructor-----------------");
                //    Assembly a1 = Assembly.Load("P01.Course.DB.SqlServer");
                //    Type t = a1.GetType("P01.Course.DB.SqlServer.Singleton");
                //    Singleton s1 =  Activator.CreateInstance(t,true) as Singleton;//will call two times of private constructor

                //    Singleton s2 = Activator.CreateInstance(t, true) as Singleton;// call private constructor once 
                //}
                //{
                //    Console.WriteLine("------------reflection with create generic class object--------------");
                //    Assembly a1 = Assembly.Load("P01.Course.DB.SqlServer");
                //    Type t = a1.GetType("P01.Course.DB.SqlServer.GenericClass`3");
                //    //must notice `3
                //    Type typeMake = t.MakeGenericType(new Type[]{typeof(String), typeof(int),typeof(DateTime)});
                //    // make generic type first, then you can create object.
                //    object oGeneric = Activator.CreateInstance(typeMake);
                //}
                //{
                //    Console.WriteLine(
                //        "--------reflection create method, just call method without convert----------");
                //    // dll name --> type name --> create instance --> method name --> then we can call method

                //    /*eg1. MVC http://localhost:9090/home/index    router--> HomeController--> Index
                //         server will use reflection to know the type name and method name
                //         MVC will scan all dll and save all controller, it will use request's controller name, find dll and type,
                //         then create type and invoke method

                //      drawback: overload of method. if index method have many overloads. 
                //      if Action have overload, MVC has to distinguish with HttpMethod + httpget/httppost method.
                //      so the Action can be overloaded, but the get/post attribute must be different 
                //    */
                //    /*
                //      eg2.
                //       AOP: easy to add some more logic if you call the method using reflection, 
                //            means do something before invoke or after invoke. 
                //     */
                //    Assembly a1 = Assembly.Load("P01.Course.DB.SqlServer");
                //    Type t = a1.GetType("P01.Course.DB.SqlServer.ReflectionTest");
                //    object oTest = Activator.CreateInstance(t);

                //    // loop all method
                //    foreach (var typemethod in t.GetMethods())
                //    {
                //        Console.WriteLine(typemethod.Name);
                //        foreach (var param in typemethod.GetParameters())
                //        {
                //            Console.WriteLine($"          parameter:  {param.Name}, type is {param.ParameterType}");
                //        }
                //    }
                //    {  
                //        //call method
                //        MethodInfo method = t.GetMethod("Show1"); 
                //        method.Invoke(oTest,null);

                //        //call method with param
                //        MethodInfo m2 = t.GetMethod("Show2");
                //        m2.Invoke(oTest, new object[] {222});

                //        //call method with overload, nominate the params
                //        MethodInfo m3 = t.GetMethod("Show3", new Type[] { typeof(int)});
                //        m3.Invoke(oTest, new object[] {333});
                //        MethodInfo m4 = t.GetMethod("Show3", new Type[] { typeof(string) });
                //        m4.Invoke(oTest, new object[]{"tom"});
                //        MethodInfo m5 = t.GetMethod("Show3", new Type[] {typeof(int), typeof(string) });
                //        m5.Invoke(oTest, new object[]{555,"jack"});
                //        MethodInfo m6 = t.GetMethod("Show3", new Type[] {typeof(string),typeof(int) });
                //        m6.Invoke(oTest, new object[] { "Lily",666});

                //        //call static method 
                //        MethodInfo m7 = t.GetMethod("Show5");
                //        m7.Invoke(oTest, new object[] { "staticName"});
                //        MethodInfo m8 = t.GetMethod("Show5");
                //        m8.Invoke(null, new object[] { "staticName2" });// instance is not necessary

                //    }
                //    {
                //        ReflectionTest refl = new ReflectionTest();
                //        refl.Show1();
                //    }
                //    {
                //        Console.WriteLine("--------------reflection to call private method-------------------");
                //        // when test private method, don't need to change original method.
                //        object oTestforPrivate = Activator.CreateInstance(t);
                //        var method = t.GetMethod("Show4",BindingFlags.Instance|BindingFlags.NonPublic);
                //        method.Invoke(oTestforPrivate, new object[] {"name for private method"});

                //    }
                //    {
                //        Console.WriteLine("--------------------reflection to call generic method---------");
                //        Assembly a2 = Assembly.Load("P01.Course.DB.SqlServer");
                //        Type t2 = a2.GetType("P01.Course.DB.SqlServer.GenericMethod");

                //        object ogeric = Activator.CreateInstance(t2);
                //        foreach (var m in t2.GetMethods())
                //        {
                //            Console.WriteLine(m.Name);
                //        }


                //        MethodInfo method = t2.GetMethod("Show");
                //        MethodInfo methodnew = method.MakeGenericMethod(new Type[] { typeof(int), typeof(string), typeof(DateTime)});
                //        methodnew.Invoke(ogeric,new object[]{ 123,"kevin", DateTime.Now});
                //    }
                //    {
                //        Console.WriteLine("--------------------reflection to call generic class and method---------");
                //        Assembly a3 = Assembly.Load("P01.Course.DB.SqlServer");

                //        //remember to make generic type
                //        Type t3 = a1.GetType("P01.Course.DB.SqlServer.GenericDouble`1");
                //        Type t33 = t3.MakeGenericType(typeof(string));

                //        MethodInfo m1 = t33.GetMethod("Show");
                //        MethodInfo m1new = m1.MakeGenericMethod(typeof(int), typeof(DateTime));

                //        // remember m1 is metadata, you need to bind with object
                //        object o3 = Activator.CreateInstance(t33);
                //        m1new.Invoke(o3, new object[]{"tom", 777,DateTime.Now.AddDays(2)});
                //    }
                //}
                {
                    Console.WriteLine("**********reflection to set class's attribute*********************");
                    Type t = typeof(People);
                    object oPeople = Activator.CreateInstance(t);
                    foreach (var prop in t.GetProperties())
                    {
                        if (prop.Name == "Id")
                        { 
                            prop.SetValue(oPeople,111);
                        }
                        else if (prop.Name.Equals("Name"))
                        {
                            prop.SetValue(oPeople,"Jack");
                        }
                        Console.WriteLine($" {t.Name}.{prop.Name} = {prop.GetValue(oPeople)}");
                    }
                    foreach (var field in t.GetFields())
                    {
                        if (field.Name == "Description")
                        {
                            field.SetValue(oPeople, "this is the description set by reflection");
                        }
                        Console.WriteLine($" {t.Name}.{field.Name} = {field.GetValue(oPeople)}");
                    }

                }
                {
                    Console.WriteLine("**********reflection with SqlServerHelper*********************");
                    SqlServerHelper s = new SqlServerHelper();
                    object o = s.Find(1);

                }
                {
                    Console.WriteLine("*******************Monitor*******************");
                    Monitor.Show();
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            Console.ReadKey();
        }
    }
}
