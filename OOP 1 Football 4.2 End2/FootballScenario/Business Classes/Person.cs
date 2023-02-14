using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScenario
{
    /// <summary>
    /// The class used to represent a coach.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not taught.")]
    public class Person
    {
        /// <summary>
        /// An indicator as to whether or not the person is currently in costume.
        /// </summary>
        public bool IsInCostume;

        /// <summary>
        /// The person's name.
        /// </summary>
        public string Name;
    }
}