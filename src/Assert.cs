using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weavver.Testing
{
     public static class Assert
     {
//-------------------------------------------------------------------------------------------
          public static bool IsTrue(bool a, bool b, string message)
          {
               if (a == b)
                    return true;
               else
                    throw new Exception(message);
          }
//-------------------------------------------------------------------------------------------
          public static void IsNotNull(object test, string message)
          {
               if (test == null)
                    throw new Exception(message);
          }
//-------------------------------------------------------------------------------------------
          public static void Fail(string message)
          {
               throw new Exception(message);
          }
//-------------------------------------------------------------------------------------------
          public static void IsTrue(bool a, string message)
          {
               if (!a)
                    throw new Exception(message);
          }
//-------------------------------------------------------------------------------------------
          public static void AreEqual(object a, object b)
          {
               if (a == b)
                    throw new Exception(a.ToString() + " is not equal to " + b.ToString());
          }
//-------------------------------------------------------------------------------------------
          public static void AreEqual(object a, object b, string message)
          {
               if (a == b)
                    throw new Exception(message);
          }
          
//-------------------------------------------------------------------------------------------
          public static void IsNotNullOrEmpty(string test, string message)
          {
               if (String.IsNullOrEmpty(test))
                    throw new Exception(message);
          }
          
//-------------------------------------------------------------------------------------------
     }
}
