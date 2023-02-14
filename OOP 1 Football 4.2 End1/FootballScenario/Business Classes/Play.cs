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
    public class Play
    {
        /// <summary>
        /// The formation of the play.
        /// </summary>
        public string Formation;

        /// <summary>
        /// The maximum possible gain for the play (if successful) in yards.
        /// </summary>
        public double MaxGain;

        /// <summary>
        /// The minimum gain for the play (if successful) in yards.
        /// </summary>
        public double MinGain;

        /// <summary>
        /// The name of the play.
        /// </summary>
        public string Name;

        /// <summary>
        /// The chance of the play being successful.
        /// </summary>
        public double SuccessRate;
    }
}