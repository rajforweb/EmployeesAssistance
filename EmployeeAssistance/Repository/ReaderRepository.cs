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
        string BaseAddress = "http://localhost:52886";
        public List<ListItem> GetCountry()
        {
            //call API
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseAddress + "/api/Countries");

            Dictionary<string, string> output = new Dictionary<string, string>();
            using (client)
            {
                var result = client.GetAsync("").Result;
                output = result.Content.ReadAsAsync<Dictionary<string, string>>().Result;
            }

            var response = new List<ListItem>();

            output.ToList().ForEach(item => response.Add(new ListItem() { Id = item.Key, Value = item.Value }));

            return response;

        }

        public List<ListItem> GetStates(string countryId)
        {
            //call API
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseAddress + "/api/States?CountryId=" + countryId);

            Dictionary<string, string> output = new Dictionary<string, string>();
            using (client)
            {
                var result = client.GetAsync("").Result;
                output = result.Content.ReadAsAsync<Dictionary<string, string>>().Result;
            }

            var response = new List<ListItem>();

            output.ToList().ForEach(item => response.Add(new ListItem() { Id = item.Key, Value = item.Value }));

            return response;
        }


        public List<ListItem> GetCity(string stateId)
        {
            //call API
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseAddress + "/api/Cities?StateId=" + stateId);

            Dictionary<string, string> output = new Dictionary<string, string>();
            using (client)
            {
                var result = client.GetAsync("").Result;
                output = result.Content.ReadAsAsync<Dictionary<string, string>>().Result;
            }

            var response = new List<ListItem>();

            output.ToList().ForEach(item => response.Add(new ListItem() { Id = item.Key, Value = item.Value }));

            return response;
        }

        public List<Information> GetRecords(ReaderViewModel model)
        {
            //call API
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(BaseAddress + "/api/Read?Country=" + model.Country + "&State=" + model.State + "&City=" + model.City + "&Category=" + model.Category + "&SubCategory=" + model.SubCategory);
            
            List<Information> output = new List<Information>();
            using (client)
            {
                var result = client.GetAsync("").Result;
                output = result.Content.ReadAsAsync<List<Information>>().Result;
            }
            return output;
        }

        public ListItem UpdateLike(string informationId)
        {
            HttpClient client = new HttpClient();
            var input = new Information() { Id = informationId };
            ListItem output = null;
            //client.BaseAddress = new Uri(BaseAddress + "/api/Insert?Country=" + model.Country + "&State=" + model.State + "&City=" + model.City + "&Category=" + model.Category + "&SubCategory=" + model.SubCategory + "&Description=" + model.information[0].Description + "&Likes=" + model.information[0].Id + "&PostDate=" + model.information[0].PostDate);
            client.BaseAddress = new Uri(BaseAddress + "/api/Update/Like");
            using (client)
            {
                var response = client.PostAsJsonAsync<Information>("", input).Result;
                var listItem = response.Content.ReadAsAsync<ListItem>().Result;
                return listItem;
            }

        }


    }
}
