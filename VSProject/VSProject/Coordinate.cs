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
        /// x components
        /// </summary>
        public int X;

        /// <summary>
        /// y component
        /// </summary>
        public int Y;

        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinate"/> class 
        /// </summary>
        public Coordinate()
        {
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
    }
}
