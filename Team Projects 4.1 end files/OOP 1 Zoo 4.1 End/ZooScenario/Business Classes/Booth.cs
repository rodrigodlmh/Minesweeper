using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooScenario
{
    /// <summary>
    /// The class which is used to represent a ticket booth.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Booth
    {
        /// <summary>
        /// The booth attendant.
        /// </summary>
        public Employee Attendant;

        /// <summary>
        /// The amount of money currently in the ticket booth.
        /// </summary>
        public decimal MoneyBalance;

        /// <summary>
        /// The number of tickets sold.
        /// </summary>
        public int TicketCountSold;

        /// <summary>
        /// The price of a ticket.
        /// </summary>
        public decimal TicketPrice;
    }
}