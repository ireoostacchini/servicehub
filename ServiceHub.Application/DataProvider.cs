using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net.Http;
using System.Net.Http.Headers;
using ServiceHub.DataContracts.Interfaces;



using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime;
using ServiceHub.UI.Interfaces;
using ServiceHub.DataContracts;


namespace ServiceHub.Application
{
 public    class DataProvider
    {
     private IData _data;
     private IConfig _config;

     public DataProvider(IData data, IConfig config)
     {
         _data = data;
         _config = config;
     }

     public void LoadData()
     {
         HttpClient client = new HttpClient();
         client.BaseAddress = new Uri(_config.DataServiceBaseUrl);

         // Add an Accept header for JSON format.
         client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


         _data.MachineServices = GetData<MachineServiceDto>(client, "api/machineservices/");

         _data.Machines= GetData<MachineDto>(client, "api/machines/");

         _data.Services= GetData<ServiceDto>(client, "api/services/");
     }



     private List<T> GetData<T>(HttpClient client, string relativeUrl)
     {
         try
         {
             // the 'Result' property makes this a blocking call
             var response = client.GetAsync(relativeUrl).Result;

             // Throw an exception if not a success code.
             response.EnsureSuccessStatusCode();

             // again, Result makes this block
             return response.Content.ReadAsAsync<IEnumerable<T>>().Result.ToList();

         }
         catch (HttpRequestException e)
         {
             Console.WriteLine(e.Message);
             throw;
         }
     }
    }
}
