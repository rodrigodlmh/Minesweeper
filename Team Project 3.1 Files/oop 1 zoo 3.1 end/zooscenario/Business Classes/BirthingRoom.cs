using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooScenario
{
    /// <summary>
    /// The class which is used to represent a birthing room.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class BirthingRoom
    {
        /// <summary>
        /// The newborn baby animal.
        /// </summary>
        public Animal Baby;

        /// <summary>
        /// The mother animal.
        /// </summary>
        public Animal Mother;

        /// <summary>
        /// The current temperature of the birthing room.
        /// </summary>
        public double Temperature;
    }
}