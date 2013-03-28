using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Weavver.Testing
{
     public class LinqTestHelpers
     {    
//-------------------------------------------------------------------------------------------
          public static IEnumerable<MethodInfo> GetMethodsForAttribute(Type searchThis, Type matchThis)
          {
               var SetUpMethod = searchThis.GetMethods().Where(x => x.GetCustomAttributes(matchThis, true).Count() > 0);
               return SetUpMethod;
          }
//-------------------------------------------------------------------------------------------
          public static bool HasAttribute(Type attributeType, Type x)
          {
               var methods = x.GetMethods();

               var matchedMethods = (from y in methods
                                     where y.GetCustomAttributes(attributeType, true).Count() > 0
                                     select y);

               return (matchedMethods.Count() > 0);
          }
//-------------------------------------------------------------------------------------------
     }
}
