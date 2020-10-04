using P23.Course.IOC.BLL;
using P23.Course.IOC.DAL;
using P23.Course.IOC.Framework.DIOC;
using P23.Course.IOC.IBLL;
using P23.Course.IOC.IDAL;
using P23.Course.IOC.Service;
using P23.Course.IOC.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Unity;

namespace P23.Course.IOC.Project
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Inversion of Control (IoC), Dependency Inversion Principle (DIP), Dependency Injection (DI)
                {
                    #region create type using reflection
                    Console.WriteLine("---------------------Object Factory----------------------------");
                    //do not need to refer Service project, just refer ServiceInterface is enough
                    //just update App.Config, then any class in new DLL which implement the ServiceInterface can be used.

                    Itelephone phone = ObjectFactory.CreatePhone(); //use IPhoneX with parameterless constructor
                    #endregion
                }

                {
                    #region create instance with container
                    Console.WriteLine("---------------------different ways of registering----------------------------");

                    IUnityContainer container = new UnityContainer();// 1 initialise container
                    container.RegisterType<Itelephone, AndroidPhone>(); //2 must register interface and class, must have parameterless ctor.
                    Itelephone androidPhone = container.Resolve<Itelephone>(); //3 get the class's instance 

                    container.RegisterType<AbstractPad, ApplePad>(); //2.1 register abstract class and root class
                    AbstractPad padabs1 = container.Resolve<AbstractPad>();//create instance ApplePad

                    container.RegisterType<AbstractPad, ApplePadChild>(); //2.2 register abstract class and sub class
                    container.RegisterType<ApplePad, ApplePadChild>();// 2.3 register root class and sub-class

                    AbstractPad padabs2 = container.Resolve<AbstractPad>(); // create instance ApplePadChild
                    ApplePad pad = container.Resolve<ApplePad>();   //create instance ApplePadChild


                    container.RegisterInstance<AbstractPad>(new ApplePad()); // 3 register abstract class to Instance
                    AbstractPad applePad = container.Resolve<AbstractPad>(); //create instance ApplePad

                    #endregion
                }
                {
                    #region create IPhone without parameterless constructor, so must register interfaces

                    Console.WriteLine("---------------------create IPhone----------------------------");
                    IUnityContainer container = new UnityContainer();
                    container.RegisterType<Itelephone, IPhone>();
                    container.RegisterType<IHeadphone, Headphone>();
                    container.RegisterType<IMicrophone, Microphone>();
                    container.RegisterType<IPower, Power>();
                    container.RegisterType<IBaseBll, BaseBll>();
                    container.RegisterType<IBaseDAL, BaseDAL>();

                    Itelephone Iphone = container.Resolve<Itelephone>();

                    #endregion
                }
                {
                    #region 
                    Console.WriteLine("---------------------create AndroidPad with abstract/interface----------------------------");
                    IXContainer container = new XContainer();

                    //register and create instance with reflection with constructor, with abstract/interface param,
                    //one param, and param don't have other abstraction/
                    //AndroidPad have two ctors with one labeled attr
                    container.RegisterType<AbstractPad, AndroidPad>();
                    container.RegisterType<IPower,AndroidPower>();
                    AbstractPad adnroidPad = container.Resolve<AbstractPad>();

                    #endregion
                }
                {
                    #region
                    Console.WriteLine("---------------------create AndroidPad with abstract/interface----------------------------");
                    //no attribute label, so will pick up the ctor with max of params
                    //multi params and some param variable need param to be created. 
                    IXContainer container = new XContainer();
                    container.RegisterType<Itelephone,IPhone>();
                    //then register all related params in the constructor's method
                    container.RegisterType<IHeadphone, Headphone>();
                    container.RegisterType<IMicrophone, Microphone>();
                    container.RegisterType<IPower, Power>();
                    container.RegisterType<IBaseBll, BaseBll>();
                    container.RegisterType<IBaseDAL, BaseDAL>();
                    container.RegisterType<IDisplay, AppleDisplay>();
                    //container.RegisterInstance<String>("AU");
                    Itelephone iphone = container.Resolve<Itelephone>();

                    #endregion
                }



                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
         
        }
    }
}
