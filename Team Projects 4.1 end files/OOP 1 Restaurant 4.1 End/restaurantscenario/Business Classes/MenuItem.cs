using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantScenario
{
    /// <summary>
    /// The class which is used to represent a menu item.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class MenuItem
    {
        /// <summary>
        /// The cost of the menu item.
        /// </summary>
        public decimal Cost;

        /// <summary>
        /// The price of the menu item.
        /// </summary>
        public decimal Price;

        /// <summary>
        /// The type of the menu item.
        /// </summary>
        public string Type;
    }
}