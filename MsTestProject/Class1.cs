using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsTestProject
{
    
    public  class Class1
    {

        [AssemblyInitialize]
        public static void BeforeAssembly(TestContext tc)
        {
            Console.WriteLine("This is before assembly");
        }
        [AssemblyCleanup]
        public static void AfterAssembly()
        {
            Console.WriteLine("This is after assembly");
        }
    }
}
