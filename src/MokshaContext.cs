using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpSvn;

using Weavver.Data;
using Weavver.Utilities;
using System.Reflection;

namespace Weavver.Testing
{
     public static partial class MokshaContext
     {
          public static List<System_Tests> Tests = new List<System_Tests>();

          public static WebBrowserStreamWriter Logger;

          public static Assembly TestAssembly = null;
     }
}