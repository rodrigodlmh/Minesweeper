using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScenario
{
    /// <summary>
    /// The class used to represent a player.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not taught.")]
    public class Player
    {
        /// <summary>
        /// The indicator of whether or not the player is an eligible receiver.
        /// </summary>
        public bool IsEligibleReceiver;

        /// <summary>
        /// The player's name.
        /// </summary>
        public string Name;

        /// <summary>
        /// The player's number.
        /// </summary>
        public int Number;

        /// <summary>
        /// The player's salary.
        /// </summary>
        public decimal Salary;

        /// <summary>
        /// The player's skill level.
        /// </summary>
        public int SkillLevel;

        /// <summary>
        /// The player's weight.
        /// </summary>
        public double Weight;
    }
}