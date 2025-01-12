namespace WebServiceAutomation
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //To create HttpClient
            HttpClient httpClient = new HttpClient();
            String url = "http://localhost:8080/laptop-bag/webapi/api/all";
            //To close the request and resource and connection
            httpClient.Dispose();

        }
    }
}