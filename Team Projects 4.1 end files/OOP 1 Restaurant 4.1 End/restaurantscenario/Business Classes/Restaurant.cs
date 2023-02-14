using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantScenario
{
    /// <summary>
    /// The class which is used to represent a restaurant.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Restaurant
    {
        /// <summary>
        /// The number of patrons that can be seated in the restaurant at one time.
        /// </summary>
        public int Capacity;

        /// <summary>
        /// The dinner menu.
        /// </summary>
        public Menu DinnerMenu;

        /// <summary>
        /// The lunch menu.
        /// </summary>
        public Menu LunchMenu;

        /// <summary>
        /// The name of the restaurant.
        /// </summary>
        public string Name;

        /// <summary>
        /// The owner of the restaurant.
        /// </summary>
        public Cook Owner;

        /// <summary>
        /// The restaurant's "regular" patron.
        /// </summary>
        public Patron TheRegular;

        /// <summary>
        /// The restaurant's list of waitresses.
        /// </summary>
        public List<Waitress> Waitresses;
    }
}