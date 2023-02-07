using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSProject
{
    class Coordinate
    {
        public Coordinate()
        {

        }
        // Constructor to initialize the x and y components
        public Coordinate(int X, int Y)
        {
            x = X;
            y = Y;
        }
        // x and y components
        public int x;
        public int y;
    }
}
