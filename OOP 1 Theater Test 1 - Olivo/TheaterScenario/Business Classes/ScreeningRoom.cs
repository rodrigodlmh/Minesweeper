//----------------------------------------------------------------------
// <copyright file="ScreeningRoom.cs" company="DO">
//     Company copyright tag.
// </copyright>
//----------------------------------------------------------------------
namespace TheaterScenario
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The class which is used to represent the screening room of a theeater
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not taught.")]
    public class ScreeningRoom
    {
        /// <summary>
        /// tells whether a movie had 3d capabilities or not
        /// </summary>
        public bool Is3dCapable;

        /// <summary>
        /// the number of seats avaliable in screening room
        /// </summary>
        public int SeatingCapacity;

        /// <summary>
        /// movie that is playing in screening room 
        /// </summary>
        public Movie nowShowing;
    }
}
