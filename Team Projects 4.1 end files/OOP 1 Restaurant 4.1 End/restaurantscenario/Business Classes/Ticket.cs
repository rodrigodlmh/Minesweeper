using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantScenario
{
    /// <summary>
    /// The class which is used to represent a meal ticket.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Ticket
    {
        /// <summary>
        /// The list of the ticket's menu items.
        /// </summary>
        public List<MenuItem> MenuItems;

        /// <summary>
        /// The ticket's total amount due.
        /// </summary>
        public decimal TotalDue;
    }
}