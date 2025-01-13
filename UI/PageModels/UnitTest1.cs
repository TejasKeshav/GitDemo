namespace MsTestBase
{
    [TestClass]
    public class UnitTest1
        {

        [ClassInitialize]
        public static void BeforeAnyTest(TestContext tc)
        {
            Console.WriteLine("This is executed only once and before all test methods excution in a class");
        }

        [TestInitialize]
        public void BeforeTest()
        {
            Console.WriteLine("This method exeuted before every test method ");
        }
        
        [TestCleanup]
        public void AfterTest()
        {
            Console.WriteLine("This method exeuted after every test method");
        }

        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine("This is my testMethod 1");
        }
        [TestMethod]
        public void TestMethod2()
        {
            Console.WriteLine("This is my testMethod 2");
        }
        [TestMethod]
        public void TestMethod3()
        {
            Console.WriteLine("This is my testMethod 3");
        }
       
                
        [ClassCleanup]
        public static void AfterAnyTest()
        {
            Console.WriteLine("This executed only once and after all test methods in a class");
        }

    }
}