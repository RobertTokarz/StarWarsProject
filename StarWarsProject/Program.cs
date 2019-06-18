using StarWarsProject.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsProject
{
    class Program
    {
        static void Main(string[] args)
        {
            bool play = true;
            while (play)
            {
                play = StarshipView.RunProgram();
            }
        }
    }
}
