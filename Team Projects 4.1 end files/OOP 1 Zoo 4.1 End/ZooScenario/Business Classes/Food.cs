using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooScenario
{
    /// <summary>
    /// The class which is used to represent food.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Food
    {
        /// <summary>
        /// The day of the week by which the food should be eaten.
        /// </summary>
        public string BestIfEatenBy;

        /// <summary>
        /// The type of food.
        /// </summary>
        public string Type;

        /// <summary>
        /// The weight of the food (in pounds).
        /// </summary>
        public double Weight;
    }
}