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
        string BaseAddress = "http://localhost:52886";

        //call API
        public void AddAssistData(ReaderViewModel model)
        {
            //call API
            HttpClient client = new HttpClient();
            Dictionary<string, string> output = null;
            //client.BaseAddress = new Uri(BaseAddress + "/api/Insert?Country=" + model.Country + "&State=" + model.State + "&City=" + model.City + "&Category=" + model.Category + "&SubCategory=" + model.SubCategory + "&Description=" + model.information[0].Description + "&Likes=" + model.information[0].Id + "&PostDate=" + model.information[0].PostDate);
            client.BaseAddress = new Uri(BaseAddress + "/api/Insert");
            using (client)
            {
                var response = client.PostAsJsonAsync<ReaderViewModel>("", model);
                var resilt = response.Result;
            }
        }

    }
}
