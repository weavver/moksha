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
     public static class TestingContext
     {
          public static CommandLineArguments Arguments = null;
          public static List<System_Tests> Tests = new List<System_Tests>();

          public static int BuildNumber = 179;
          public static WebBrowserStreamWriter Logger;

          public static Assembly TestAssembly = null;

          public static long Revision
          {
               get
               {
                    string localPath = @"C:\Weavver\Main";
                    var workingCopyClient = new SvnWorkingCopyClient();
                    SvnWorkingCopyVersion version;
                    workingCopyClient.GetVersion(localPath, out version);
                    long localRev = version.End;
                    return localRev;
               }
          }

          public static string BuildLabel
          {
               get
               {
                    return "Build " + TestingContext.BuildNumber.ToString() + " SVN " + Revision.ToString();
               }
          }
     }
}