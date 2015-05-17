using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System.IO;

namespace Weavver.Testing
{
     public class Helper
     {
//-------------------------------------------------------------------------------------------
          public static IWebDriver webDriver;
          public static IJavaScriptExecutor js;
          public static Actions builder;
//-------------------------------------------------------------------------------------------
          public static string GetAppSetting(string settingname)
          {
               string callingAssemblyFolderPath = Path.GetDirectoryName(System.Reflection.Assembly.GetCallingAssembly().Location);

               Console.WriteLine("Calling assembly path: " + callingAssemblyFolderPath);

               // It's useful to make changes directly to the App.config listed in Solution explorer while testing/debugging
#if DEBUG
               string srcFolder = Directory.GetParent(callingAssemblyFolderPath).Parent.FullName;
#else
               string srcFolder = callingAssemblyFolderPath;
#endif

               string configPath = Path.Combine(srcFolder, "app.config");

               if (!String.IsNullOrEmpty(MokshaInterfaceContext.Arguments["config"]))
                    configPath = MokshaInterfaceContext.Arguments["config"];

               Assert.IsTrue(File.Exists(configPath), "The config was not found at: " + configPath);

               Console.WriteLine("Loading config from: " + configPath);

               ExeConfigurationFileMap map = new ExeConfigurationFileMap();
               map.ExeConfigFilename = configPath;
               Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
               Assert.IsNotNull(config, "Could not find the config at: " + configPath);

               KeyValueConfigurationElement kvCE = config.AppSettings.Settings[settingname];
               Assert.IsNotNull(kvCE, "Could not find the config setting: " + settingname);

               string val = kvCE.Value;
               Assert.IsNotNullOrEmpty(val, "Could not find the config setting: " + settingname);
               return val;
          }
//-------------------------------------------------------------------------------------------
     }
}
