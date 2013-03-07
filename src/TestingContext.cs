using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weavver.Data;

namespace Weavver.Testing
{
     public static class TestingContext
     {
          public static string[] Arguments;
          public static List<System_Tests> Tests = new List<System_Tests>();

          public static int BuildNumber = 179;
          public static WebBrowserStreamWriter Logger;
     }
}
