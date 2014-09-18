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
               string srcFolder = Directory.GetParent(callingAssemblyFolderPath).Parent.FullName;
               string configPath = Path.Combine(srcFolder, "app.config");

               Assert.IsTrue(File.Exists(configPath), "The config was not found at: " + configPath);

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
