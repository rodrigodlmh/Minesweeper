using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantScenario
{
    /// <summary>
    /// The class which is used to represent a cook.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Cook
    {
        /// <summary>
        /// The cook's breadbasket.
        /// </summary>
        public Basket Breadbasket;

        /// <summary>
        /// The cook's bread oven.
        /// </summary>
        public Oven BreadOven;

        /// <summary>
        /// The cook's gas stove.
        /// </summary>
        public Stove GasStove;

        /// <summary>
        /// The cook's name.
        /// </summary>
        public string Name;

        /// <summary>
        /// The total number of menu items the cook has cooked.
        /// </summary>
        public int NumberOfMenuItemsCooked;

        /// <summary>
        /// The cook's salary.
        /// </summary>
        public decimal Salary;

        /// <summary>
        /// The cook's soup vat.
        /// </summary>
        public Vat SoupVat;
    }
}