using Newtonsoft.Json.Linq;
using StarWarsProject.Domain;
using StarWarsProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsProject.Controller
{
    public class StarShipController
    {
        /// <summary>
        /// Controller class created to separate data access and business logic.
        /// </summary>
        private static List<StarShip> starShipList = new List<StarShip>(); 

        /// <summary>
        /// Method calls domain functionality to get list of Starships 
        /// </summary>
        /// <returns></returns>
        public static List<StarShip> GetStarShips()
        {
            if(starShipList.Count == 0)
            {
                string url = "https://swapi.co/api/starships/";
                bool hasNextPage = true;
                while (hasNextPage)
                {
                    var starships = SWDomainRequests.GetStarshipList(@url);
                    url = starships.SelectToken("next").ToString();
                    if (url == null || url == "") hasNextPage = false;
                    foreach (var starShip in starships.SelectToken("results"))
                    {
                        if(!(starShip.SelectToken("consumables").ToString().ToLower().Equals("unknown") || starShip.SelectToken("MGLT").ToString().ToLower().Equals("unknown")))
                        {
                            starShipList.Add(ResolveStarship(starShip));
                        }                        
                    }
                }

            }     
            return starShipList;
        }

        /// <summary>
        /// StarShip entity created with parameters needed to perform requested calculations
        /// </summary>
        /// <param name="starShip"></param>
        /// <returns></returns>
        private static StarShip ResolveStarship(JToken starShip)
        {
            StarShip ship = new StarShip();
            ship.CreateStarShip(ResolveConsumables(starShip.SelectToken("consumables").ToString()), starShip.SelectToken("name").ToString(), ResolveMGLT(starShip.SelectToken("MGLT").ToString()));
         
            return ship;
        }
        /// <summary>
        /// Function convert speed in MGLT string value to int 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static int ResolveMGLT(string value)
        {
            int mglt = 0;
            Int32.TryParse(value, out mglt);
            return mglt;
        }
        /// <summary>
        /// Function calculate consumable time in hours
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static int ResolveConsumables(string value)
        {
            string timeUnit = value.Substring(value.IndexOf(" ")).Trim().ToLower();
            int timePeriod = 0;
            Int32.TryParse(value.Substring(0, value.IndexOf(" ")).Trim(), out timePeriod);
            switch (timeUnit)
            {
                case "years":
                case "year":
                    return 365 * 24 * timePeriod;
                case "months":
                case "month":
                    return 30 * 24 * timePeriod;
                case "week":
                case "weeks":
                    return 7 * 24 * timePeriod;
                case "day":
                case "days":
                    return 24 * timePeriod;
            }
            return 1; // to avoid division by 0
           
        }
    }
}
