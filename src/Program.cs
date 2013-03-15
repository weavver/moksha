using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;

using System.Data.Linq;
using System.Windows.Forms;
using System.Threading;

namespace Weavver.Testing
{
     class Program
     {
//-------------------------------------------------------------------------------------------
          [STAThread]
          static void Main(string[] arguments)
          {
               AppDomain currentDomain = AppDomain.CurrentDomain;
               currentDomain.AssemblyResolve += new ResolveEventHandler(LoadFromSameFolder);

               TestingContext.Arguments = new Utilities.CommandLineArguments(arguments);

               Application.EnableVisualStyles();
               Application.SetCompatibleTextRenderingDefault(false);

               var t = new Thread(STAMain);
               t.SetApartmentState(ApartmentState.STA);
               t.Start();

               Environment.ExitCode = 1;
          }
//-------------------------------------------------------------------------------------------
          private static void STAMain()
          {
               Application.Run(new TestingHarness());
          }
//-------------------------------------------------------------------------------------------
          static Assembly LoadFromSameFolder(object sender, ResolveEventArgs args)
          {
               string folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
               string assemblyPath = Path.Combine(folderPath, new AssemblyName(args.Name).Name + ".dll");
               if (File.Exists(assemblyPath) == false)
               {
                    assemblyPath = Path.Combine(Path.GetDirectoryName(TestingContext.TestAssembly.Location), new AssemblyName(args.Name).Name + ".dll");
                    if (File.Exists(assemblyPath) == false)  { return null;}
               }
               Assembly assembly = Assembly.LoadFrom(assemblyPath);
               return assembly;
          }
//-------------------------------------------------------------------------------------------
     }
}