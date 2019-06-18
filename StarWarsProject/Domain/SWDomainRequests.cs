using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsProject.Domain
{   
    /// <summary>
    /// Domain created to deal with Starship repositories - in this case Web API request. (Can be database functionality as well.)
    /// </summary>
    public class SWDomainRequests
    {
        private static HttpClient httpClient;

        private  static JObject starShipList;


        /// <summary>
        /// Web API request to get values from provided url.
        /// </summary>
        /// <param name="url">Url to API endpoint</param>
        /// <returns></returns>
        public static JObject GetStarshipList(string url)
        {            
            httpClient = new HttpClient();

            var response = httpClient.GetAsync(url);
            if (!response.Result.IsSuccessStatusCode) return null;

            starShipList = new JObject();
            var result = response.Result.Content.ReadAsStringAsync();
            starShipList = JObject.Parse(result.Result.ToString());
            
            return starShipList;
        }

    }
}
