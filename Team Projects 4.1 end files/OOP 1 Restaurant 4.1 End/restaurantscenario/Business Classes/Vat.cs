using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantScenario
{
    /// <summary>
    /// The class which is used to represent a vat.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Vat
    {
        /// <summary>
        /// The maximum amount of soup that fits in the vat (in quarts).
        /// </summary>
        public double Capacity;

        /// <summary>
        /// The amount of soup currently contained within the vat (in quarts).
        /// </summary>
        public double Level;

        /// <summary>
        /// The vat's type.
        /// </summary>
        public string Type;
    }
}