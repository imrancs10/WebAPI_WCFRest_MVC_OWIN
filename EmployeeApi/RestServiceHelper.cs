using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace EmployeeApi
{
    public class RestServiceHelper
    {
        public static async Task<string> GetServiceData(string uri)
        {
            Uri geturi = new Uri("http://localhost:51931/EmployeeService.svc/" + uri);
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            System.Net.Http.HttpResponseMessage responseGet = await client.GetAsync(geturi);
            string response = await responseGet.Content.ReadAsStringAsync();
            return response;
        }

        public static async Task<string> PostServiceData(string uri, dynamic data)
        {
            Uri requestUri = new Uri("http://localhost:51931/EmployeeService.svc/" + uri); //replace your Url  
            dynamic dynamicJson = new ExpandoObject();
            dynamicJson.FirstName = data.FirstName;
            dynamicJson.LastName = data.LastName;
            dynamicJson.Gender = data.Gender;
            dynamicJson.Salary = data.Salary;
            string json = "";
            json = Newtonsoft.Json.JsonConvert.SerializeObject(dynamicJson);
            var objClint = new System.Net.Http.HttpClient();
            System.Net.Http.HttpResponseMessage respon = await objClint.PostAsync(requestUri, new StringContent(json, System.Text.Encoding.UTF8, "application/json"));
            string responJsonText = await respon.Content.ReadAsStringAsync();
            return responJsonText;
        }
    }
}