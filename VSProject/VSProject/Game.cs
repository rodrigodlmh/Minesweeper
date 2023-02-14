//----------------------------------------------------------------------
// <copyright file="Game.cs" company="😹👍">
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
    /// The class used to represent the game
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Game
    {
        /// <summary>
        /// true if the player already clicked for the first time
        /// </summary>
        public bool FirstClick;

        /// <summary>
        /// minefield object
        /// </summary>
        public Minefield Minefield;

        // Add difficulty settings...
    }
}
