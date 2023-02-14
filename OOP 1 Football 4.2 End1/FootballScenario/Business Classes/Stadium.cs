using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScenario
{
    /// <summary>
    /// The class used to represent a stadium.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not taught.")]
    public class Stadium
    {
        /// <summary>
        /// The number of persons that the stadium can hold at one time.
        /// </summary>
        public int Capacity;

        /// <summary>
        /// The stadium's concession stand.
        /// </summary>
        public Stand ConcessionStand;

        /// <summary>
        /// The name of the stadium.
        /// </summary>
        public string Name;

        /// <summary>
        /// The stadium's souvenir stand.
        /// </summary>
        public Stand SouvenirStand;
    }
}