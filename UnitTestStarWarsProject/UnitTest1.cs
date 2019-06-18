using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsProject.Domain;
using StarWarsProject.Model;

namespace UnitTestStarWarsProject
{
    [TestClass]
    public class UnitTest1 
    {
        [TestMethod]
        public void TestMethodApiRequest()
        {
           
            var test1 = SWDomainRequests.GetStarshipList(@"https://swapi.co/api/starships/");
            Assert.IsNotNull(test1);
        }

        [TestMethod]
        public void TestMethodCreateStarship()
        {
            StarShip ship = new StarShip();
            ship.CreateStarShip(12000, "TestShip", 20); 
            Assert.IsNotNull(ship);
        }

        [TestMethod]
        public void TestMethodCalculateStops()
        {
            int distance = 10000000;
            StarShip ship = new StarShip();
            ship.CreateStarShip(12000, "TestShip", 20);
            int stops = ship.CalculateStops(distance);
            Assert.IsTrue(41 == ship.CalculateStops(distance));
        }


    }
}
