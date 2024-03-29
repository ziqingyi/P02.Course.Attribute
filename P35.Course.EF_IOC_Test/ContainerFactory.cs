﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity.Configuration;
using Unity;

namespace P35.Course.EF_IOC_Test
{
    public class ContainerFactory
    {
        private static IUnityContainer container = null;
        static ContainerFactory()
        {
            /* 1 one interface/abstract can map to multiple class, using alias to distinguish
             *
             * 2 resolution of parameter with specific value, eg.string, int32.
             *
             * 3 generic, the interface and class should have `
             *
             * 4 normally use one container and config file and shared by whole project, rather than config many times.
             *   eg.mvc is in global.
             *   (1) IOC + Config files
             *   (2) controller should be updated to use container
             *   (3) create UnityDependencyResolver and use it in the webapi by assign it to config.DependencyResolver
             */
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "CfgFiles\\Unity.Config");
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);
            container = new UnityContainer();
            section.Configure(container, "myContainer");
        }

        public static IUnityContainer GetContainer()
        {
            return container;
        }
    }
}
