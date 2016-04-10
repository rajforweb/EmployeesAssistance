using EmployeeAssistance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAssistance.Repository
{
    public class EditorRepository
    {
        string BaseAddress = "http://192.168.1.33:8080/EmployeeAssistance.Api";

        //call API
        public void AddAssistData(ReaderViewModel model)
        {
            //call API
            HttpClient client = new HttpClient();
            Dictionary<string, string> output = null;
            //client.BaseAddress = new Uri(BaseAddress + "/api/Insert?Country=" + model.Country + "&State=" + model.State + "&City=" + model.City + "&Category=" + model.Category + "&SubCategory=" + model.SubCategory + "&Description=" + model.information[0].Description + "&Likes=" + model.information[0].Id + "&PostDate=" + model.information[0].PostDate);
            client.BaseAddress = new Uri(BaseAddress + "/api/Create");
            using (client)
            {
                var response = client.PostAsJsonAsync<ReaderViewModel>("", model);
                var resilt = response.Result;
            }
        }

    }
}
