using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantScenario
{
    /// <summary>
    /// The class which is used to represent a waitress.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Waitress
    {
        /// <summary>
        /// The waitress' name.
        /// </summary>
        public string Name;

        /// <summary>
        /// The number of condiment bottles the waitress has filled.
        /// </summary>
        public int NumberOfCondimentsFilled;

        /// <summary>
        /// The number of patrons the waitress has seated.
        /// </summary>
        public int NumberOfPatronsSeated;

        /// <summary>
        /// The number of tables the waitress has set.
        /// </summary>
        public int NumberOfTablesSet;

        /// <summary>
        /// The waitress' salary.
        /// </summary>
        public decimal Salary;

        /// <summary>
        /// The number of the waitress' assigned table.
        /// </summary>
        public int TableNumber;

        /// <summary>
        /// The waitress' current ticket.
        /// </summary>
        public Ticket Ticket;
    }
}