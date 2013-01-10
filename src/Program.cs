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
               Application.EnableVisualStyles();
               Application.SetCompatibleTextRenderingDefault(false);

               var t = new Thread(STAMain);
               t.SetApartmentState(ApartmentState.STA);
               t.Start();
          }
//-------------------------------------------------------------------------------------------
          private static void STAMain()
          {
               Application.Run(new TestingHarness());
          }
//-------------------------------------------------------------------------------------------
     }
}