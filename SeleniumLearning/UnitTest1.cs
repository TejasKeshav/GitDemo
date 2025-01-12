namespace SeleniumLearning
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            TestContext.Progress.WriteLine("");
        }

        [Test]
        public void Test1()
        {
            TestContext.Progress.WriteLine("I am Test1 method");
                Assert.Pass();
        }
        [Test]
        public void Test2() {
            TestContext.Progress.WriteLine("I am Test2 method");
        }
        [TearDown]
        public void TearDown()
        {
            TestContext.Progress.WriteLine("TearDown method");
        }
    }
}