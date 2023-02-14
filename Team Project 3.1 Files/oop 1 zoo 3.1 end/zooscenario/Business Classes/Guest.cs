using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooScenario
{
    /// <summary>
    /// The class which is used to represent a guest.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Guest
    {
        /// <summary>
        /// The age of the guest.
        /// </summary>
        public int Age;

        /// <summary>
        /// The name of the guest.
        /// </summary>
        public string Name;

        /// <summary>
        /// The guest's wallet.
        /// </summary>
        public Wallet Wallet;
    }
}