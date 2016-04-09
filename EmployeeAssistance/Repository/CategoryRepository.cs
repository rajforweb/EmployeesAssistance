using EmployeeAssistance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;


namespace EmployeeAssistance.Repository
{
    public class CategoryRepository
    {
        string BaseAddress = "http://localhost:";
        public void AddCategory(CategoryModel model)
        {
            //call API
            HttpClient client = new HttpClient();
            Dictionary<string, string> output = null;
            client.BaseAddress = new Uri(BaseAddress + "/api/Category");
            using (client)
            {
                var response = client.PostAsJsonAsync<CategoryModel>("", model);
                var resilt = response.Result;
            }
        }

        public void AddSubCategory(CategoryModel model)
        {
            //call API
            HttpClient client = new HttpClient();
            Dictionary<string, string> output = null;
            client.BaseAddress = new Uri(BaseAddress + "/api/SubCategory");
            using (client)
            {
                var response = client.PostAsJsonAsync<CategoryModel>("", model);
                var resilt = response.Result;
            }
        }

        public List<ListItem> GetCategory()
        {
            //call API
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseAddress + "/api/GetCategories");

            List<ListItem> output = new List<ListItem>();
            using (client)
            {
                var result = client.GetAsync("").Result;
                output = result.Content.ReadAsAsync<List<ListItem>>().Result;
            }
            return output;
        }

        public List<ListItem> GetSubCategory(string category)
        {
            //call API
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseAddress + "/api/SubCategories?Category=" + category);

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
