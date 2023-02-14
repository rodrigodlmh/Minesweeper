using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantScenario
{
    /// <summary>
    /// The class which is used to represent a basket.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Basket
    {
        /// <summary>
        /// The number of breadsticks that the basket can hold.
        /// </summary>
        public int BreadstickCapacity;

        /// <summary>
        /// The number of breadsticks currently in the basket.
        /// </summary>
        public int BreadstickCount;
    }
}