using System;
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
                Password = "afdr34354yt"
            };
            IUnityContainer container = new UnityContainer();
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "CfgFiles\\Unity.Config");
            Configuration configuration =
                ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            UnityConfigurationSection configSection =
                (UnityConfigurationSection) configuration.GetSection(UnityConfigurationSection.SectionName);
            configSection.Configure(container, "aopContainer");

            IUnityUserProcessor uprocessor = container.Resolve<IUnityUserProcessor>();
            uprocessor.RegUser(user);
            uprocessor.GetUser(user);

        }




    }
}
