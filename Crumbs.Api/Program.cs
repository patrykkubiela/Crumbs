using System;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Crumbs.Api
{
    public class Program
    {
        private static readonly NLog.ILogger Logger;

        static Program()
        {
            Logger = NLog.LogManager.GetCurrentClassLogger();

            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;

            Console.OutputEncoding = System.Text.Encoding.Unicode;
        }

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .ConfigureAppConfiguration(ConfigConfiguration)
                        .UseStartup<Startup>();
                });

        static void ConfigConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder config)
        {
            config.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{ctx.HostingEnvironment.EnvironmentName}.json", optional: true,
                    reloadOnChange: true)
                .AddEnvironmentVariables();
        }

        [SecurityCritical]
        [HandleProcessCorruptedStateExceptions]
        private static void OnUnhandledException(object eventSender, UnhandledExceptionEventArgs exceptionEventArgs)
        {
            Logger.Fatal(exceptionEventArgs.ExceptionObject as Exception);

            NLog.LogManager.Shutdown();

            Environment.Exit(1);
        }

        [SecurityCritical]
        [HandleProcessCorruptedStateExceptions]
        private static void OnUnobservedTaskException(object eventSender,
            UnobservedTaskExceptionEventArgs exceptionEventArgs)
        {
            Logger.Fatal(exceptionEventArgs.Exception);

            NLog.LogManager.Shutdown();

            Environment.Exit(1);
        }
    }
}