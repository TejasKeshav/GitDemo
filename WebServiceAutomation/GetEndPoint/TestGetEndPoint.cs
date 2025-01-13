using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebServiceAutomation.Model;
using WebServiceAutomation.Model.JsonModel;

namespace WebServiceAutomation.GetEndPoint
{
    [TestClass]
    public class TestGetEndPoint
    {
        private String getUrl = "https://rahulshettyacademy2023.atlassian.net";
        [TestMethod]
        public void TestGetAllEndPoints()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.GetAsync(getUrl);
            httpClient.Dispose();


        }

        [TestMethod]
        public void TestGetAllEndPointsWithUri()
        {
            HttpClient httpClient = new HttpClient();
            Uri getUri = new Uri(getUrl);
            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUri);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            //Status Code
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status =>" + statusCode);
            //Integer representation of status code
            Console.WriteLine("Status =>" + (int)statusCode);

            //Response Data
            HttpContent responseContent = httpResponseMessage.Content;
            Task<String> responseData = responseContent.ReadAsStringAsync();
            String data = responseData.Result;
            Console.WriteLine(data);
            httpClient.Dispose();

        }
        [TestMethod]
        public void TestGetAllEndPointswithInvalidUrl()
        {
            HttpClient httpClient = new HttpClient();
            Uri getUri = new Uri(getUrl + "/random");
            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUri);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status =>" + statusCode);
            //Integer representation of status code
            Console.WriteLine("Status =>" + (int)statusCode);

            //Status Code
            HttpStatusCode statusCode2 = httpResponseMessage.StatusCode;
            Console.WriteLine("Status =>" + statusCode2);
            //Integer representation of status code
            Console.WriteLine("Status =>" + (int)statusCode2);

            //Response Data
            HttpContent responseContent = httpResponseMessage.Content;
            Task<String> responseData = responseContent.ReadAsStringAsync();
            String data = responseData.Result;
            Console.WriteLine(data);
            httpClient.Dispose();
            httpClient.Dispose();
        }

        [TestMethod]
        public void TestGetAllEndPointsInJsonFormat()
        {
            HttpClient httpClient = new HttpClient();
            Uri getUri = new Uri(getUrl);
            HttpRequestHeaders requestheaders = httpClient.DefaultRequestHeaders;
            requestheaders.Add("Accept", "application/json");

            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUri);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            //Status Code
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status =>" + statusCode);
            //Integer representation of status code
            Console.WriteLine("Status =>" + (int)statusCode);

            //Response Data
            HttpContent responseContent = httpResponseMessage.Content;
            Task<String> responseData = responseContent.ReadAsStringAsync();
            String data = responseData.Result;
            Console.WriteLine(data);
            httpClient.Dispose();

        }
        [TestMethod]
        public void TestGetAllEndPointsInXmlFormat()
        {
            HttpClient httpClient = new HttpClient();
            Uri getUri = new Uri(getUrl);
            HttpRequestHeaders requestHeaders = httpClient.DefaultRequestHeaders;
            requestHeaders.Add("Accept", "application/xml");

            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUri);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            //Status Code
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status =>" + statusCode);
            //Integer representation of status code
            Console.WriteLine("Status =>" + (int)statusCode);

            //Response Data
            HttpContent responseContent = httpResponseMessage.Content;
            Task<String> responseData = responseContent.ReadAsStringAsync();
            String data = responseData.Result;
            Console.WriteLine(data);
            httpClient.Dispose();

        }

        public void TestGetAllEndPointsInXmlFormatUsingAcceptHeader()
        {
            MediaTypeWithQualityHeaderValue jsonHeader = new MediaTypeWithQualityHeaderValue("application/json");
            HttpClient httpClient = new HttpClient();
            Uri getUri = new Uri(getUrl);
            HttpRequestHeaders requestHeaders = httpClient.DefaultRequestHeaders;
            requestHeaders.Accept.Add(jsonHeader);

            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUrl);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            //Status Code
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status =>" + statusCode);
            //Integer representation of status code
            Console.WriteLine("Status =>" + (int)statusCode);

            //Response Data
            HttpContent responseContent = httpResponseMessage.Content;
            Task<String> responseData = responseContent.ReadAsStringAsync();
            String data = responseData.Result;
            Console.WriteLine(data);
            httpClient.Dispose();

        }
        [TestMethod]
        public void TestGetAllEndPointsUsingSendAsync()
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.RequestUri = new Uri(getUrl);
            httpRequestMessage.Method = HttpMethod.Get;
            httpRequestMessage.Headers.Add("Accept", "application/json");

            HttpClient httpClient = new HttpClient();
            Task<HttpResponseMessage> httpResponse = httpClient.SendAsync(httpRequestMessage);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            //Status Code
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status =>" + statusCode);
            //Integer representation of status code
            Console.WriteLine("Status =>" + (int)statusCode);

            //Response Data
            HttpContent responseContent = httpResponseMessage.Content;
            Task<String> responseData = responseContent.ReadAsStringAsync();
            String data = responseData.Result;
            Console.WriteLine(data);
            httpClient.Dispose();

        }
        [TestMethod]
        public void TestUsingStatement()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage())
                {
                    httpRequestMessage.RequestUri = new Uri(getUrl);
                    httpRequestMessage.Method = HttpMethod.Get;
                    httpRequestMessage.Headers.Add("Accept", "application/json");
                    Task<HttpResponseMessage> httpResponse = httpClient.SendAsync(httpRequestMessage);

                    using (HttpResponseMessage httpResponseMessage = httpResponse.Result)
                    {
                        Console.WriteLine(httpResponseMessage.ToString());

                        //Status Code
                        HttpStatusCode statusCode = httpResponseMessage.StatusCode;
                        // Console.WriteLine("Status =>" + statusCode);
                        //Integer representation of status code
                        //Console.WriteLine("Status =>" + (int)statusCode);

                        //Response Data
                        HttpContent responseContent = httpResponseMessage.Content;
                        Task<String> responseData = responseContent.ReadAsStringAsync();
                        String data = responseData.Result;
                        // Console.WriteLine(data);

                        RestResponse restResponse = new RestResponse((int)statusCode, responseData.Result);
                        Console.WriteLine(restResponse.ToString());

                    }
                }

            }
        }

        [TestMethod]
        public void TestDeserializationOfJsonResponse()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage())
                {
                    httpRequestMessage.RequestUri = new Uri(getUrl);
                    httpRequestMessage.Method = HttpMethod.Get;
                    httpRequestMessage.Headers.Add("Accept", "application/json");
                    Task<HttpResponseMessage> httpResponse = httpClient.SendAsync(httpRequestMessage);

                    using (HttpResponseMessage httpResponseMessage = httpResponse.Result)
                    {
                        Console.WriteLine(httpResponseMessage.ToString());

                        //Status Code
                        HttpStatusCode statusCode = httpResponseMessage.StatusCode;
                        // Console.WriteLine("Status =>" + statusCode);
                        //Integer representation of status code
                        //Console.WriteLine("Status =>" + (int)statusCode);

                        //Response Data
                        HttpContent responseContent = httpResponseMessage.Content;
                        Task<String> responseData = responseContent.ReadAsStringAsync();
                        String data = responseData.Result;
                        // Console.WriteLine(data);

                        RestResponse restResponse = new RestResponse((int)statusCode, responseData.Result);
                        //Console.WriteLine(restResponse.ToString());
                       List<JsonRootObject>  jsonRootObject = JsonConvert.DeserializeObject<List<JsonRootObject>>(restResponse.ResponseContent);
                        Console.WriteLine(jsonRootObject.ToString());
                    }
                }

            }
        }
    }
}
