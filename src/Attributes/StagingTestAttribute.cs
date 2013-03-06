using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weavver.Testing
{
     [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
     public sealed class StagingTest : Attribute
     {
     }
}
