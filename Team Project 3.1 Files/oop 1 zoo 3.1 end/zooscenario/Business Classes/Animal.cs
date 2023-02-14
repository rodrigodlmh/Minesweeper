using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooScenario
{
    /// <summary>
    /// The class which is used to represent an animal.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Animal
    {
        /// <summary>
        /// The age of the animal.
        /// </summary>
        public int Age;

        /// <summary>
        /// A value indicating whether or not the animal is pregnant.
        /// </summary>
        public bool IsPregnant;

        /// <summary>
        /// The name of the animal.
        /// </summary>
        public string Name;

        /// <summary>
        /// The type of the animal.
        /// </summary>
        public string Type;

        /// <summary>
        /// The weight of the animal (in pounds).
        /// </summary>
        public double Weight;
    }
}