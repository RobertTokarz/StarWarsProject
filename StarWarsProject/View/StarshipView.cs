using StarWarsProject.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsProject.View
{
    public class StarshipView
    {
        /// <summary>
        /// Little bit artificial View functionality - just to separate Main method from program functionality.
        /// </summary>
        /// <returns></returns>
        public static bool RunProgram()
        {
            Console.WriteLine("Please enter distance between planets in MGLT:");
            string distanceString = Console.ReadLine();
            int distance = 0;
            bool checkInput = Int32.TryParse(distanceString, out distance);
            if (checkInput)
            {
                var starShips = StarShipController.GetStarShips();
                foreach(var starShip in starShips)
                {
                    Console.WriteLine(starShip.StarShipName + ": "+ starShip.CalculateStops(distance));
                }
            }
            else
            {
                Console.WriteLine("Entered value was not valid!");
            }
            Console.WriteLine("Do you want to quit?(y/n)");
            string quit = Console.ReadLine().ToLower();
            if (quit.Equals("y")) return false;
            return true;
        }

    }
}
