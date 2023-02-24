//----------------------------------------------------------------------
// <copyright file="Coordinate.cs" company="😹👍">
//     Company copyright tag.
// </copyright>
//----------------------------------------------------------------------
namespace VSProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The class used to represent coordinates.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Coordinate
    {
        /// <summary>
        /// x coordinate of the board, the rows
        /// </summary>
        public int X;

        /// <summary>
        /// y coordinate of the game, the column 
        /// </summary>
        public int Y;

        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinate"/> class 
        /// </summary>
        public Coordinate()
        {
            X = 0;
            Y = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinate"/> class 
        /// </summary>
        /// <param name="x">the x value of the board</param>
        /// <param name="y">the y value of the board</param>
        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Generates random number and returns it
        /// </summary>
        /// <returns> a integer value</returns>
        public static Coordinate GetRandomCoordinate(int c, int r)
        {
            Coordinate coord = new Coordinate();
            Random Random = new Random();
            coord.X = Random.Next(0, c);
            coord.Y = Random.Next(0, r);
            return coord;
        }
    }
}
