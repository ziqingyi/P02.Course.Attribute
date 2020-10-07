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
using P19.Course.ConsoleWriterProj;
using Unity;
using Unity.Lifetime;

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
                    #region create type using factory and reflection
                    Console.WriteLine("---------------------Object Factory----------------------------");
                    //do not need to refer Service project, just refer ServiceInterface is enough
                    //just update App.Config, then any class in new DLL which implement the ServiceInterface can be used.

                    Itelephone phone = ObjectFactory.CreatePhone(); //use IPhoneX with parameterless constructor
                    #endregion
                }

                {
                    #region IUnityContainer create some instances with container
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
                    #region IUnityContainer create IPhone with constructor having parameters, so must register interfaces

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
                    #region XContainer test:  create AndroidPad with one param
                    Console.WriteLine("---------------------XContainer test:  create AndroidPad with one param using abstract/interface----------------------------");
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
                    #region XContainer test: create IPhone with all related parameter
                    Console.WriteLine("---------------------create AndroidPad with XContainer  with all related parameter using abstract/interface----------------------------");
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
                {
                    #region  IUnityContainer create ApplePad instance setting lifetime manager. 

                    Console.WriteLine("---------------------create ApplePad with IUnityContainer setting lifetime manager----------------------------");
                    IUnityContainer container = new UnityContainer();
                    //life cycle 1: transient lifetime manager
                                   //Creates a new object of the requested type every time you call the Resolve or ResolveAll method.
                    container.RegisterType<AbstractPad, ApplePad>(new TransientLifetimeManager());//default

                    AbstractPad pad11 = container.Resolve<AbstractPad>();
                    AbstractPad pad12 = container.Resolve<AbstractPad>();

                    bool ObjSame1 = object.ReferenceEquals(pad11, pad12);// false  create new instance every time.

                    
                    //life cycle 2: Singleton Lifetime Manager global.
                    //it's better to create singleton through container than create singleton by yourself. 
                    //Singleton lifetime creates globally unique singleton.
                    //Any Unity container tree (parent and all the children) is guaranteed to have only one global singleton for the registered type.
                    container.RegisterType<AbstractPad, ApplePad>(new SingletonLifetimeManager());

                    AbstractPad pad21 = container.Resolve<AbstractPad>();
                    AbstractPad pad22 = container.Resolve<AbstractPad>();

                    bool ObjSame2 = object.ReferenceEquals(pad21, pad22);// true  using singleton instance 


                            //if create new container, it will still create new instance. 
                    IUnityContainer container2 = new UnityContainer();
                    container2.RegisterType<AbstractPad, ApplePad>(new SingletonLifetimeManager());
                    AbstractPad pad23 = container2.Resolve<AbstractPad>();
                    bool ObjSame3 = object.ReferenceEquals(pad23, pad22);// false  create new instance 


                    //life cycle 3: Singleton in different thread, in ORM, different thread need to have diff DBContext.same thread have same.
                    ManualResetEvent mre = new ManualResetEvent(false);
                    IUnityContainer container3 = new UnityContainer();
                    container3.RegisterType<AbstractPad, ApplePad>(new PerThreadLifetimeManager());
                    AbstractPad pad31=null;
                    AbstractPad pad32=null;
                    AbstractPad pad33;
                                    //create first instance
                    Action act1 = () =>
                    {
                        pad31 = container3.Resolve<AbstractPad>();
                        ConsoleWriter.WriteLineYellow($"pad31 is created by Thread id = {Thread.CurrentThread.ManagedThreadId}");//id=3
                    };
                    IAsyncResult result1 = act1.BeginInvoke(null, null);

                                   //create second instance
                    Action act2 = () =>
                    {
                        pad32 = container3.Resolve<AbstractPad>();
                        ConsoleWriter.WriteLineYellow($"pad32 is created by Thread id = {Thread.CurrentThread.ManagedThreadId}");//id=4
                    };
                                  //callback create third instance
                    IAsyncResult result2 = act2.BeginInvoke(t =>
                    {
                        pad33 = container3.Resolve<AbstractPad>();
                        ConsoleWriter.WriteLineGreen($"action2 BeginInvoke() with {t.AsyncState}");
                        ConsoleWriter.WriteLineGreen($"pad33 is created by Thread id = {Thread.CurrentThread.ManagedThreadId}");
                        ConsoleWriter.WriteLineGreen($"object.ReferenceEquals(pad32, pad33)={object.ReferenceEquals(pad32,pad33)}");//true
                        mre.Set();
                    }, "action2 finished state");//callback id =4

                    act1.EndInvoke(result1);
                    act2.EndInvoke(result2);//EndInvoke wait for return value of the delegate(not IAsyncResult),  not wait for callback, so print below first. 
                    ConsoleWriter.WriteLine($"object.ReferenceEquals(pad31, pad32)={object.ReferenceEquals(pad31, pad32)}");//false

                    Console.WriteLine("mre is set? " + mre.WaitOne());
                    #endregion
                }

                {
                    #region XxContainer test: create parameterless ApplePad with lifetime
                    Console.WriteLine("---------------------create ApplePad with XxContainer using abstract/interface, have lifetime------------");

                    //no attribute label, so will pick up the ctor with max of params
                    //multi params and some param variable need param to be created. 
                    IXxContainer xxcontainer1 = new XxContainer();
                    xxcontainer1.RegisterType<AbstractPad,ApplePad>(LifeTimeType.Transient);
                    AbstractPad applePad1 = xxcontainer1.Resolve<AbstractPad>();
                    AbstractPad applePad2 = xxcontainer1.Resolve<AbstractPad>();
                    Console.WriteLine("applePad1 and applePad2 are same?  "+object.ReferenceEquals(applePad1,applePad2));

                    IXxContainer xxcontainer2 = new XxContainer();
                    xxcontainer2.RegisterType<AbstractPad, ApplePad>(LifeTimeType.Singletone);
                    AbstractPad applePad3 = xxcontainer2.Resolve<AbstractPad>();
                    AbstractPad applePad4 = xxcontainer2.Resolve<AbstractPad>();
                    Console.WriteLine("applePad3 and applePad4 are same?  " + object.ReferenceEquals(applePad3, applePad4));

                    // test creating three instances in different threads
                    ManualResetEvent mre = new ManualResetEvent(false);

                    IXxContainer xxcontainer3 = new XxContainer();
                    xxcontainer3.RegisterType<AbstractPad, ApplePad>(LifeTimeType.PerThread);
                    AbstractPad applePad5 = null;
                    AbstractPad applePad6 = null;
                    AbstractPad applePad7 = null;
                    
                    Action act1 = () =>
                    {
                        applePad5 = xxcontainer3.Resolve<AbstractPad>();
                        ConsoleWriter.WriteLineYellow($"applePad5 is created by thread id = {Thread.CurrentThread.ManagedThreadId}");
                    };
                    IAsyncResult res1 = act1.BeginInvoke(null, null);

                    Action act2 = () =>
                    {
                        applePad6 = xxcontainer3.Resolve<AbstractPad>();
                        ConsoleWriter.WriteLine(
                            $"applePad6 is created by thread id = {Thread.CurrentThread.ManagedThreadId}");
                    };
                    AsyncCallback actCallback = t =>
                    {
                        applePad7 = xxcontainer3.Resolve<AbstractPad>();
                        ConsoleWriter.WriteLineGreen($"applePad7 is created by thread id = {Thread.CurrentThread.ManagedThreadId} with t ={t.AsyncState}");
                        ConsoleWriter.WriteLineGreen("applePad6 and applePad7 are same?  " + object.ReferenceEquals(applePad6, applePad7));
                        mre.Set();
                    };

                    IAsyncResult res2 = act2.BeginInvoke(actCallback, "action2 finished, will call callback");

                    act1.EndInvoke(res1);//wait act1 finish 
                    act2.EndInvoke(res2);//wait act2 finish, not wait for callback, so print below before callback 
                    Console.WriteLine("applePad5 and applePad6 are same?  " + object.ReferenceEquals(applePad5, applePad6));

                    Console.WriteLine("mre is set? "+ mre.WaitOne());
                    #endregion
                }
                {
                    #region XxContainer test: create  IPhone with parameters with lifetime: PerThread
                    Console.WriteLine("---------------------XxContainer test: create  IPhone with parameters with lifetime: PerThread------------");
                    IXxContainer xxcontainer = new XxContainer();

                    xxcontainer.RegisterType<Itelephone, IPhone>(LifeTimeType.PerThread);
                    //then register all related params in the constructor's method
                    xxcontainer.RegisterType<IHeadphone, Headphone>(LifeTimeType.Transient);
                    xxcontainer.RegisterType<IMicrophone, Microphone>(LifeTimeType.Singletone);
                    xxcontainer.RegisterType<IPower, Power>(LifeTimeType.Singletone);
                    xxcontainer.RegisterType<IBaseBll, BaseBll>();//since power is singleton, so bll and dal will not be created twice. 
                    xxcontainer.RegisterType<IBaseDAL, BaseDAL>();//since power is singleton, so bll and dal will not be created twice. 
                    xxcontainer.RegisterType<IDisplay, AppleDisplay>();

                    // test creating three instances in different threads
                    ManualResetEvent mre = new ManualResetEvent(false);

                    Itelephone iphone1 = null;
                    Itelephone iphone2 = null;
                    Itelephone iphone3 = null;

                    Action act1 = () =>
                    {
                        iphone1 = xxcontainer.Resolve<Itelephone>();
                        ConsoleWriter.WriteLineYellow($"iphone1 is created by thread id = {Thread.CurrentThread.ManagedThreadId}");
                    };
                    IAsyncResult res1 = act1.BeginInvoke(null, null);

                    Action act2 = () =>
                    {
                        iphone2 = xxcontainer.Resolve<Itelephone>();
                        ConsoleWriter.WriteLine(
                            $"iphone2 is created by thread id = {Thread.CurrentThread.ManagedThreadId}");
                    };
                    AsyncCallback actCallback = t =>
                    {
                        iphone3 = xxcontainer.Resolve<Itelephone>();
                        ConsoleWriter.WriteLineGreen($"iphone3 is created by thread id = {Thread.CurrentThread.ManagedThreadId} with t ={t.AsyncState}");
                        ConsoleWriter.WriteLineGreen("iphone2 and iphone3 are same?  " + object.ReferenceEquals(iphone2, iphone3));
                        mre.Set();
                    };

                    IAsyncResult res2 = act2.BeginInvoke(actCallback, "action2 finished, called callback");

                    act1.EndInvoke(res1);//wait act1 finish 
                    act2.EndInvoke(res2);//wait act2 finish, not wait for callback, so print below before callback 
                    Console.WriteLine("iphone1 and iphone2 are same?  " + object.ReferenceEquals(iphone1, iphone2));

                    Console.WriteLine("mre is set? " + mre.WaitOne());

                    #endregion
                }
                {
                 
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
