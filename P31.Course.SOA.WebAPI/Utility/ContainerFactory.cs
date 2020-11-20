using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using Unity;

namespace P31.Course.SOA.WebAPI.Utility
{
    //using Unity; is used for UnityContainer class. 
    //Unity Interception Configuration is essential if you use config file for AOP extension. 

    public class ContainerFactory
    {
        private static IUnityContainer _container = null;

        static ContainerFactory()
        {
            #region container with config, remove all instance initialization details in main program
            Console.WriteLine("---------------------container with config------------");
            /* 1 one interface/abstract can map to multiple class, using alias to distinguish
             *
             * 2 resolution of parameter with specific value, eg.string, int32.
             *
             * 3 generic, the interface and class should have `
             *
             * 4 normally use one container and config file and shared by whole project, rather than config many times.
             *   eg.mvc is in global.
             */

            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "CfgFiles\\Unity.Config");
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            ConfigurationSection cs = configuration.GetSection(UnityConfigurationSection.SectionName);
            UnityConfigurationSection section = (UnityConfigurationSection)cs;
            
            _container = new UnityContainer();
            section.Configure(_container, "WebApiContainer");

            //Itelephone iphone = container.Resolve<Itelephone>();
            //iphone.Call();

            #endregion
        }

        public static IUnityContainer Container
        {
            get { return _container; }
            //no set
        }

    }
}