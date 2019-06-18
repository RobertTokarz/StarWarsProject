using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsProject.Model
{
    public class StarShip : ICalculations
    {
        private string _starShipName;
        private int _MGLT;
        private int _consumables;
        private int _stops;


        public string StarShipName
        {
            get { return _starShipName; }
            set { _starShipName = value; }
        }

        public int MGLT
        {
            get { return _MGLT; }
            set { _MGLT = value; }
        }

        public int Consumables
        {
            get { return _consumables; }
            set { _consumables = value; }
        }
        public int Stops
        {
            get { return _stops; }
            private set
            {
                _stops = value;
            }
        }



        /// <summary>
        /// Method which calculate stops needed to cover provided distance
        /// </summary>
        /// <param name="distance"></param>
        /// <returns></returns>
        public int CalculateStops(int distance)
        {
            int travelHours = distance / _MGLT;

            return  travelHours/_consumables;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="consumables">Time for which consumables last in hours</param>
        /// <param name="name">Starship name</param>
        /// <param name="mglt">Starship speed per hour</param>
        public void CreateStarShip(int consumables, string name, int mglt)
        {
            _starShipName = name;
            _MGLT = mglt;
            _consumables = consumables;
        }
    }
}
