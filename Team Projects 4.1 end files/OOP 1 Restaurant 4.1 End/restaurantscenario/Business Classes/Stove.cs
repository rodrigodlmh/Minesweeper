using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantScenario
{
    /// <summary>
    /// The class which is used to represent a stove.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Stove
    {
        /// <summary>
        /// The total amount of soup made by the stove (in quarts).
        /// </summary>
        public double AmountOfSoupMade;

        /// <summary>
        /// A value indicating whether or not the stove is currently in use.
        /// </summary>
        public bool IsInUse;

        /// <summary>
        /// The amount of soup that can be made in a single batch (in quarts).
        /// </summary>
        public double SoupBatchSize;
    }
}