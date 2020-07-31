﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity.Configuration;
using Unity;

namespace P18.Course.MyAOP.UnityAOPFolder
{
    public class UnityConfigAOP
    {
        public static void Show()
        {
            User user = new User(){
                Id=7,
                Name = "user7",
                Password = "afdr34354y"
            };
            {
                Console.WriteLine("******************Normal Container*******************");
                IUnityContainer container = new UnityContainer();
                container.RegisterType<IUnityUserProcessor, UnityUserProcessor>();
                //resolve and return a instance of UnityUserProcessor
                IUnityUserProcessor processor = container.Resolve<IUnityUserProcessor>();
                processor.RegUser(user);
                processor.GetUser(user);
                
            }

            {
                Console.WriteLine("***************Container with AOP*********************");
                IUnityContainer container = new UnityContainer();
                ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "CfgFiles\\Unity.Config");
                Configuration configuration =
                    ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

                UnityConfigurationSection configSection =
                    (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);
                configSection.Configure(container, "aopContainer");
                //config the container with the aopContainer in file
                //interface map to the type, then container can resolve and provide a instance.
                //not a instance of IUnityUserProcessor, type is:DynamicModule.ns.Wrapped_IUnityUserProcessor_413....
                IUnityUserProcessor uprocessor = container.Resolve<IUnityUserProcessor>();
                uprocessor.RegUser(user);
                uprocessor.GetUser(user);
            }

        }




    }
}
