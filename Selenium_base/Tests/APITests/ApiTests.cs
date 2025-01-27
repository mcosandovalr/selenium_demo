using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;

namespace Selenium_base.Tests.APITests
{
    [TestClass]
    public class ApiTests
    {
        // TODO: get this from the testsettings file
        private string baseUri = "https://reqres.in/api";

        [TestMethod]
        public void GetUsers() 
        { 
            // create http client
            HttpClient client = new HttpClient();
            // call endpoint and get response
            Task<HttpResponseMessage> response = client.GetAsync(baseUri + "/users");
            // obtaining response
            HttpResponseMessage responseMessage = response.Result;
            
            // getting data from response
            // status code
            HttpStatusCode statusCode = responseMessage.StatusCode; 
            // to get the code value cast the statusCode to int: (int)statusCode

            // response data
            HttpContent responseContent = responseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;

            // closing client
            client.Dispose();

            // printing data

            Console.WriteLine("Status Code: {0} {1}", (int)statusCode, statusCode);
            //Console.WriteLine(responseMessage.ToString());
            
            Console.WriteLine($"data: \n {data}");
        }

        [TestMethod]
        public void GetUsersAsJson()
        {
            // create http client
            HttpClient client = new HttpClient();

            // adding headers to get the response as json 
            /** it doesn't do much to reqres :S
            HttpRequestHeaders requestHeaders = client.DefaultRequestHeaders;
            requestHeaders.Add("Accept", "application/json"); 
            **/

            // call endpoint and get response
            Task<HttpResponseMessage> response = client.GetAsync(baseUri + "/users");
            // obtaining response
            HttpResponseMessage responseMessage = response.Result;

            // getting data from response
            // status code
            HttpStatusCode statusCode = responseMessage.StatusCode;
            // to get the code value cast the statusCode to int: (int)statusCode

            // response data
            HttpContent responseContent = responseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;

            // closing client
            client.Dispose();

            // printing data

            Console.WriteLine("Status Code: {0} {1}", (int)statusCode, statusCode);
            //Console.WriteLine(responseMessage.ToString());

            Console.WriteLine($"data: \n {data}");
        }

        [TestMethod]
        public void GetUserWithUsing()
        {
            using (HttpClient client = new HttpClient()) 
            {
                Task<HttpResponseMessage> response = client.GetAsync(baseUri + "/users");
                using (HttpResponseMessage responseMessage = response.Result)
                {
                    // status code
                    HttpStatusCode statusCode = responseMessage.StatusCode;
                    // to get the code value cast the statusCode to int: (int)statusCode

                    // response data
                    HttpContent responseContent = responseMessage.Content;
                    Task<string> responseData = responseContent.ReadAsStringAsync();
                    string data = responseData.Result;

                    Console.WriteLine("Status Code: {0} {1}", (int)statusCode, statusCode);
                    //Console.WriteLine(responseMessage.ToString());

                    Console.WriteLine($"data: \n {data}");
                }
            }
        }
    }
}
