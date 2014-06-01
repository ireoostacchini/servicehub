
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using ServiceHub.Model;



namespace ServiceHub.Test.System
{
    using System;
    using NUnit.Framework;





        [TestFixture]
        public class TestWebApi
        {


            [Test, Category("QA")]  //should have called the server QA rather than Test...
            public void Test_Url_works()
            {
                var url = GetFullUrl("http://localhost/ServiceHub.DataService.WebAPI.Test");

                TestUrl(url);
            }

            [Test, Category("Staging")]
            public void Staging_Url_works()
            {
                var url = GetFullUrl("http://localhost/ServiceHub.DataService.WebAPI.Staging");

                TestUrl(url);
            }


//            [Test, Category("Production")]
//            public void Production_Url_works()
//            {
//                var url = GetFullUrl(Config.SiteUrlProduction);
//
//                testUrl(url);
//            }






            private string GetFullUrl(string baseUrl)
            {
                return baseUrl + "/api/machines";
            }


            private static void TestUrl(string url)
            {
                var client = new HttpClient();

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // the 'Result' property makes this a blocking call
                var response = client.GetAsync(url).Result;

                // Throw an exception if not a success code.
                response.EnsureSuccessStatusCode();

//                var machines = response.Content.ReadAsAsync<IEnumerable<Machine>>().Result.ToList();
//
//                Assert.That(machines.Count>0);
            }
        }
    }
