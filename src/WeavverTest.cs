﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Net.Mail;
using OpenQA.Selenium.Support.UI;
using System.Drawing.Imaging;
using System.Diagnostics;
using OpenQA.Selenium.Chrome;
using System.Threading;
using Weavver.Testing.Attributes;

namespace Weavver.Testing
{
     public class WeavverTest
     {
//-------------------------------------------------------------------------------------------
          public IWebDriver webDriver
          {
               get
               {
                    return Helper.webDriver;
               }
               set
               {
                    Helper.webDriver = value;
               }
          }
//-------------------------------------------------------------------------------------------
          public string BaseURL
          {
               get
               {
                    return Helper.GetAppSetting("weavver_url");
               }
          }
//-------------------------------------------------------------------------------------------
          [TestFixtureSetUp]
          public void TestFixtureSetUp()
          {
               //foreach (Process chromeDriver in Process.GetProcessesByName("chromedriver"))
               //{
               //     chromeDriver.Kill();
               //}

               string browser = Helper.GetAppSetting("browser");
               string driver = Helper.GetAppSetting("driver");
               if (driver == "remotewebdriver")
               {
                    Uri seleniumServer = new Uri("http://" + Helper.GetAppSetting("selenium_server") + ":" + Int32.Parse(Helper.GetAppSetting("selenium_port") + "/wd/hub"));
                    DesiredCapabilities capabilities = DesiredCapabilities.Chrome();
                    switch (browser)
                    {
                         case "chrome":
                              capabilities = DesiredCapabilities.Chrome();
                              var switches = new List<string>{"--start-maximized"};
                              capabilities.SetCapability("chrome.switches", switches);
                              break;

                         case "firefox": capabilities = DesiredCapabilities.Firefox(); break;
                         case "internetexplorer": DesiredCapabilities.InternetExplorer(); break;
                         case "htmlunit": capabilities = DesiredCapabilities.HtmlUnit(); break;
                    }
                    capabilities.IsJavaScriptEnabled = false; // setting this to false first is supposed to be a hack for forcing htmlunit to work with js
                    capabilities.IsJavaScriptEnabled = true;
                    webDriver = new RemoteWebDriver(seleniumServer, capabilities);
               }
               else
               {
                    switch (browser)
                    {
                         case "chrome":
                              ChromeOptions capabilities = new ChromeOptions();
                              //var switches = new List<string>{"--start-maximized"};

                              //"--start-maximized"
                              capabilities.AddArgument("--start-maximized");
                              //capabilities.SetCapability("webdriver.chrome.bin", @"C:\Weavver\Main\Projects\3rd Party\Testing\chromedriver.exe");
                              webDriver = new OpenQA.Selenium.Chrome.ChromeDriver(@"C:\Weavver\Main\Projects\3rd Party\Testing\", capabilities);
                              break;

                         case "firefox": webDriver = new OpenQA.Selenium.Firefox.FirefoxDriver(); break;
                         case "internetexplorer": webDriver = new OpenQA.Selenium.IE.InternetExplorerDriver(); break;
                    }
               }
               webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
               webDriver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(5));
               Helper.builder = new Actions(webDriver);

               Helper.js = webDriver as IJavaScriptExecutor;
          }
//-------------------------------------------------------------------------------------------
          [TestFixtureTearDown]
          public void TestFixtureTearDown()
          {
#if WINDOWS
               ITakesScreenshot t = (ITakesScreenshot) webDriver;
               string sspath = Path.Combine(Path.GetTempPath(), "out.png");

               //t.GetScreenshot().SaveAsFile(sspath, ImageFormat.Png);
               //if (File.Exists(sspath))
               //{
               //     try
               //     {
               //          MailMessage mm = new MailMessage("testing@weavver.com", "mitchel@weavver.com", "Test ScreenShot", "");
               //          mm.Attachments.Add(new Attachment(sspath));
               //          SmtpClient client = new SmtpClient(Helper.GetAppSetting("smtp_server"), Int32.Parse(Helper.GetAppSetting("smtp_port")));
               //          client.Send(mm);

               //          mm.Dispose();
               //          File.Delete(sspath);
               //     }
               //     catch { }
               //}
#endif
               webDriver.Close();
               webDriver.Quit();
               webDriver.Dispose();
          }
//-------------------------------------------------------------------------------------------
          public void SelectDDLOption(By target, string optionText)
          {
               IWebElement targetObj = (IWebElement) webDriver.FindElement(target);
               SelectElement se = new SelectElement(targetObj);
               var option = (from x in se.Options
                             where x.Text == optionText
                             select x).FirstOrDefault();

               Assert.IsNotNull(option, "Option text: " + option + " does not exist.");
               se.SelectByText(optionText);
               WaitForPageLoad();
               System.Threading.Thread.Sleep(1000);
          }
//-------------------------------------------------------------------------------------------
          public void ClickButton(By target)
          {
               int y = webDriver.FindElement(target).Location.Y;
               if (y > 100)
                    y = y - 100;
               ((IJavaScriptExecutor)webDriver).ExecuteScript("window.scrollBy(0," + y + ");");

               webDriver.FindElement(target).Click();
          }
//-------------------------------------------------------------------------------------------
          public void SetControlValue(By locator, string newValue)
          {
               FindElement(locator).Clear();
               FindElement(locator).SendKeys(newValue);
          }
//-------------------------------------------------------------------------------------------
          public IWebElement FindElement(By locator)
          {
               Console.WriteLine("Looking for web element '" + locator.ToString() + "'..");
               Stopwatch sw = new Stopwatch();
               sw.Start();
               while (sw.Elapsed.Seconds < 10)
               {
                    var obj = webDriver.FindElement(locator);
                    if (obj != null)
                    {
                         return obj;
                    }
                    Thread.Sleep(500);
               }
               return null;
          }
//-------------------------------------------------------------------------------------------
          public bool WaitForTextExists(By locator, string text)
          {
               Stopwatch sw = new Stopwatch();
               sw.Start();
               while (sw.Elapsed.Seconds < 30)
               {
                    IWebElement foundElement = webDriver.FindElement(locator);
                    if (foundElement.Text.Contains(text))
                    {
                         return true;
                    }
                    Thread.Sleep(500);
               }
               return false;
          }
//-------------------------------------------------------------------------------------------
          public bool WaitForTextExists2(string jquerySelector, string text)
          {
               Stopwatch sw = new Stopwatch();
               sw.Start();
               while (sw.Elapsed.Seconds < 30)
               {
                    String statusText = ((IJavaScriptExecutor)webDriver).ExecuteScript("return $('" + jquerySelector + "').text()").ToString();
                    if (statusText.Contains(text))
                    {
                         return true;
                    }
                    Thread.Sleep(500);
               }
               return false;
          }
          
//-------------------------------------------------------------------------------------------
          public void LogIn()
          {
               Assert.AreEqual("Weavver :: Abre Los Ojos.", webDriver.Title);
               webDriver.FindElement(By.Id("MasterHeader1_LoginView1_SignInLink")).Click();
               webDriver.FindElement(By.Id("MasterHeader1_LogIn_Login1_UserName")).Click();
               webDriver.FindElement(By.Id("MasterHeader1_LogIn_Login1_UserName")).SendKeys(Helper.GetAppSetting("username"));
               webDriver.FindElement(By.Id("MasterHeader1_LogIn_Login1_Password")).SendKeys(Helper.GetAppSetting("password"));
               webDriver.FindElement(By.Id("MasterHeader1_LogIn_Login1_LoginButton")).Click();
               WaitForPageLoad();
          }
//-------------------------------------------------------------------------------------------
          public void LogOut()
          {
               webDriver.FindElement(By.LinkText("Sign Out")).Click();
               WaitForPageLoad();
               Assert.AreEqual("Thank you, please come again!", webDriver.Title);
               Assert.IsTrue(webDriver.PageSource.Contains("Thank you for using using our services."), "Thank you message is missing");
          }
//-------------------------------------------------------------------------------------------
          [DebuggerNonUserCode]
          public void WaitForPageLoad()
          {
               WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
               wait.Until<bool>((d) =>
               {
                    IJavaScriptExecutor js = webDriver as IJavaScriptExecutor;
                    bool loaded = !(bool)js.ExecuteScript("return pageloading;");

                    if (loaded)
                    {
                         CheckThatImagesLoaded();
                    }
                    return loaded;
               });
          }
//-------------------------------------------------------------------------------------------
          private void CheckThatImagesLoaded()
          {
               IJavaScriptExecutor js = webDriver as IJavaScriptExecutor;
               Stopwatch sw = new Stopwatch();
               sw.Start();
               while (true)
               {
                    // Check for failed images
                    string failedImageCountJS = "return $('img').filter(function() { return $(this)[0].naturalWidth == 0; }).length;";
                    long failedImageCount = (long)js.ExecuteScript(failedImageCountJS);
                    if (failedImageCount > 0)
                    {
                         string failedImagesJS = "var imgs = $('img').filter(function() { return $(this)[0].naturalWidth == 0; });\r\n"
                                               + "var cImgs = imgs.clone();\r\n"
                                               + "var html = $('<div>').append(cImgs).html();\r\n"
                                               + "return html;";
                         string failedImages = (string)js.ExecuteScript(failedImagesJS);
                         if (sw.Elapsed.Seconds > 30)
                         {
                              Assert.Fail("The following images failed to load: " + failedImages);
                         }
                         else
                         {
                              System.Threading.Thread.Sleep(1000);
                              continue;
                         }
                    }
                    else
                    {
                         break;
                    }
               }
          }
//-------------------------------------------------------------------------------------------
          public void Pause(int seconds) // because it's too annoying to type Thread.Sleep every time
          {
               System.Threading.Thread.Sleep(TimeSpan.FromSeconds(seconds));
          }
//-------------------------------------------------------------------------------------------
     }
}