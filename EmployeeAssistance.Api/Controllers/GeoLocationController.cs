using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using EmployeeAssistance.Api.Models;
using EmployeeAssistance.Api.Providers;
using System.Linq;

namespace EmployeeAssist.WebApi.Controllers
{

    public class GeoLocationController : ApiController
    {
        // GET api/Geolocation/Countries
        [Route("api/Countries")]
        [HttpGet]
        public Dictionary<string, string> Get()
        {
            ResultModel model = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://lab.iamrohit.in/php_ajax_country_state_city_dropdown/api.php?type=getCountries");
            using (client)
            {
                var result = client.GetAsync("").Result;
                model = result.Content.ReadAsAsync<ResultModel>().Result;
            }

            return model.result;
        }
        [Route("api/States")]
        [HttpGet]
        public Dictionary<string, string> GetStates([FromUri]string countryId = "0")
        {
            ResultModel model = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://lab.iamrohit.in/php_ajax_country_state_city_dropdown/api.php?type=getStates&countryId=" + countryId);
            using (client)
            {
                var result = client.GetAsync("").Result;
                model = result.Content.ReadAsAsync<ResultModel>().Result;
            }

            return model.result;
        }

        [Route("api/States/{id}")]
        [HttpGet]
        public string States([FromUri]string id = "0", string countryId = "0")
        {

            var statesDictionary = GetStates(countryId);
            if (statesDictionary.ContainsKey(id))
            {
                return statesDictionary[id];
            }
            return string.Empty;
        }


        [Route("api/Cities")]
        [HttpGet]
        public Dictionary<string, string> GetCities([FromUri]string stateId = "0")
        {
            ResultModel model = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://lab.iamrohit.in/php_ajax_country_state_city_dropdown/api.php?type=getCities&stateId=" + stateId);
            using (client)
            {
                var result = client.GetAsync("").Result;
                model = result.Content.ReadAsAsync<ResultModel>().Result;
            }

            return model.result;
        }


        [Route("api/Cities/{id}")]
        [HttpGet]
        public string Cities([FromUri]string id = "0", string stateId = "0")
        {

            var citiesDictionary = GetCities(stateId);
            if (citiesDictionary.ContainsKey(id))
            {
                return citiesDictionary[id];
            }
            return string.Empty;
        }
    }
}
