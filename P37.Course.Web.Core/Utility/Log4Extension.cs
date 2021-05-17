using System;
using Microsoft.Extensions.Logging;


namespace P37.Course.Web.Core.Utility
{
    public static class Log4Extension
    {

        ////try build extend method for IWebHostBuilder
        //public static void InitLog4Net(this IWebHostBuilder webHost)
        //{
        //    return webHost.ConfigureLogging((ContextBoundObject, loggingBuilder) =>
        //    {
        //        loggingBuilder.AddFilter("System", LogLevel.Warning); //remove low level system and Microsoft logging 
        //        loggingBuilder.AddFilter("Microsoft", LogLevel.Warning);
        //        loggingBuilder.AddLog4Net("CfgFiles\\log4net.config");
        //    });

        //}
        ////try action
        //public static Action<WebHostBuilderContext, ILoggingBuilder> InitLog4()
        //{
        //    return (ContextBoundObject, loggingBuilder) =>
        //    {
        //        loggingBuilder.AddFilter("System", LogLevel.Warning); //remove low level system and Microsoft logging 
        //        loggingBuilder.AddFilter("Microsoft", LogLevel.Warning);
        //        loggingBuilder.AddLog4Net("CfgFiles\\log4net.config");
        //    };
        //}
        ////try action extension
        //public static Action<ILoggingBuilder> InitLog4(this WebHostBuilderContext context)
        //{
        //    return (ContextBoundObject, loggingBuilder) =>
        //    {
        //        loggingBuilder.AddFilter("System", LogLevel.Warning); //remove low level system and Microsoft logging 
        //        loggingBuilder.AddFilter("Microsoft", LogLevel.Warning);
        //        loggingBuilder.AddLog4Net("CfgFiles\\log4net.config");
        //    };
        //}
        ////try action extension
        //public static Action<ILoggingBuilder> InitLog4()
        //{
        //    return ( loggingBuilder) =>
        //    {
        //        loggingBuilder.AddFilter("System", LogLevel.Warning); //remove low level system and Microsoft logging 
        //        loggingBuilder.AddFilter("Microsoft", LogLevel.Warning);
        //        loggingBuilder.AddLog4Net("CfgFiles\\log4net.config");
        //    };
        //}

        ////just config logging builder
        public static void InitLog4(ILoggingBuilder loggingBuilder)
        {
            loggingBuilder.AddFilter("System", LogLevel.Warning);//remove low level system and Microsoft logging 
            loggingBuilder.AddFilter("Microsoft", LogLevel.Warning);
            loggingBuilder.AddLog4Net("CfgFiles\\log4net.config");
        }

    }
}
