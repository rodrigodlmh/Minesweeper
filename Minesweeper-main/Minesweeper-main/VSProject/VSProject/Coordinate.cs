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
