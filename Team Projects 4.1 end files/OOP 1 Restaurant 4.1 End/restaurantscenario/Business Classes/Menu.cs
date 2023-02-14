using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantScenario
{
    /// <summary>
    /// The class which is used to represent a menu.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Menu
    {
        /// <summary>
        /// The color of the menu.
        /// </summary>
        public string Color;

        /// <summary>
        /// The number of pages in the menu.
        /// </summary>
        public int NumberOfPages;

        /// <summary>
        /// The type of the menu.
        /// </summary>
        public string Type;
    }
}