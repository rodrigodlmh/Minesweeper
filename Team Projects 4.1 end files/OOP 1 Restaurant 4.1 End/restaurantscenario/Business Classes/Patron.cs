using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantScenario
{
    /// <summary>
    /// The class which is used to represent a patron.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Patron
    {
        /// <summary>
        /// The patron's favorite meal.
        /// </summary>
        public string FavoriteMealName;

        /// <summary>
        /// The patron's ticket.
        /// </summary>
        public Ticket MyTicket;

        /// <summary>
        /// The name of the patron.
        /// </summary>
        public string Name;

        /// <summary>
        /// The number of the patron's preferred table.
        /// </summary>
        public int PreferredTableNumber;

        /// <summary>
        /// The number of the table the patron is currently seated at.
        /// </summary>
        public int TableNumber;
    }
}