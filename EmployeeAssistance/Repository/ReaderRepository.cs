using EmployeeAssistance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAssistance.Repository
{
    public class ReaderRepository
    {
        string BaseAddress = "http://localhost:";
        public List<ListItem> GetCountry()
        {
            //call API
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseAddress + "/api/GetCountry");

            List<ListItem> output = new List<ListItem>();
            using (client)
            {
                var result = client.GetAsync("").Result;
                output = result.Content.ReadAsAsync<List<ListItem>>().Result;
            }
            return output;
        }

        public List<ListItem> GetStates()
        {
            //call API
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseAddress + "/api/GetSates");

            List<ListItem> output = new List<ListItem>();
            using (client)
            {
                var result = client.GetAsync("").Result;
                output = result.Content.ReadAsAsync<List<ListItem>>().Result;
            }
            return output;
        }


        public List<ListItem> GetCity()
        {
            //call API
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseAddress + "/api/GetCity");

            List<ListItem> output = new List<ListItem>();
            using (client)
            {
                var result = client.GetAsync("").Result;
                output = result.Content.ReadAsAsync<List<ListItem>>().Result;
            }
            return output;
        }

       

    }
}
