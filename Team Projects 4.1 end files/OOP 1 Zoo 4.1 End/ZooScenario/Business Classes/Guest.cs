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

        /// <summary>
        /// Gives a specified amount of money from one guest to another guest.
        /// </summary>
        /// <param name="giverName">The name of the guest that will be giving the money.</param>
        /// <param name="receiverName">The name of the guest that will be receiving the money.</param>
        /// <param name="amount">The amount of money to transfer between the two guests.</param>
        public void GiveMoney(string giverName, string receiverName, decimal amount)
        {
            // Find the giver.
            Guest giver = this.FindGuest(giverName);

            // Find the receiver.
            Guest receiver = this.FindGuest(receiverName);

            // If both giver and receiver were found
            if (giver != null && receiver != null)
            {
                // Take money from giver.
                giver.Wallet.MoneyBalance -= amount;

                // Give money to receiver.
                receiver.Wallet.MoneyBalance += amount;
            }
        }
    }
}