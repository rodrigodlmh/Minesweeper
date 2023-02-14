using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooScenario
{
    /// <summary>
    /// The class which is used to represent a wallet.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Wallet
    {
        /// <summary>
        /// The color of the wallet.
        /// </summary>
        public string Color;

        /// <summary>
        /// The amount of money currently contained within the wallet.
        /// </summary>
        public decimal MoneyBalance;
    }
}