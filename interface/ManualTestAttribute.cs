using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weavver.Testing
{
     /// <summary>
     /// Manual tests have to be run by double clicking them in the test runner. They do not run at the same time as other tests.
     /// </summary>
     [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
     public sealed class ManualTest : Attribute
     {
     }
}