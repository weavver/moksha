using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;
using System.Collections.Specialized;

namespace Weavver.Testing
{
     public static partial class MokshaInterfaceContext
     {
          public static StringDictionary Arguments = new StringDictionary();

          public static int BuildNumber = 179;

          public static Assembly TestAssembly = null;

          public static long Revision
          {
               get
               {
                    //string localPath = @"C:\Weavver\Main";
                    //var workingCopyClient = new SvnWorkingCopyClient();
                    //SvnWorkingCopyVersion version;
                    //workingCopyClient.GetVersion(localPath, out version);
                    //long localRev = version.End;
                    //return localRev;
                    return 0; // not implemented
               }
          }

          public static string BuildLabel
          {
               get
               {
                    return "Build " + MokshaInterfaceContext.BuildNumber.ToString() + " SVN " + Revision.ToString();
               }
          }
     }
}