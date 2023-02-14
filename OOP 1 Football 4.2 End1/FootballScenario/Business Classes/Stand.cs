using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScenario
{
    /// <summary>
    /// The class used to represent a vending stand.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not taught.")]
    public class Stand
    {
        /// <summary>
        /// The amount of money currently in the stand.
        /// </summary>
        public decimal MoneyBalance;

        /// <summary>
        /// The number of items available for sale in the stand.
        /// </summary>
        public int QuantityOnHand;

        /// <summary>
        /// The number of items sold by the stand.
        /// </summary>
        public int QuantitySold;

        /// <summary>
        /// The type of item for sale at the stand.
        /// </summary>
        public string Type;
    }
}