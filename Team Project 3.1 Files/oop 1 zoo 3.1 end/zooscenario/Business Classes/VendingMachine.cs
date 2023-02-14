using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooScenario
{
    /// <summary>
    /// The class which is used to represent a vending machine.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class VendingMachine
    {
        /// <summary>
        /// The weight of a single portion of dingo food.
        /// </summary>
        public readonly double DingoFoodPortionWeight = 0.1;

        /// <summary>
        /// The weight of a single portion of platypus food.
        /// </summary>
        public readonly double PlatypusFoodPortionWeight = 0.05;

        /// <summary>
        /// A pre-packaged packet of dingo food which is displayed
        /// to guests, and which will be the next one sold.
        /// </summary>
        public Food DingoFood;

        /// <summary>
        /// The maximum capacity of dingo food (in pounds).
        /// </summary>
        public double DingoFoodMaxStock;

        /// <summary>
        /// The price of a single portion of dingo food.
        /// </summary>
        public decimal DingoFoodPrice;

        /// <summary>
        /// The amount of dingo food currently in stock (in pounds).
        /// </summary>
        public double DingoFoodStock;

        /// <summary>
        /// The amount of money currently in the vending machine.
        /// </summary>
        public decimal MoneyBalance;

        /// <summary>
        /// A pre-packaged packet of platypus food which is displayed
        /// to guests, and which will be the next one sold.
        /// </summary>
        public Food PlatypusFood;

        /// <summary>
        /// The maximum capacity of platypus food (in pounds).
        /// </summary>
        public double PlatypusFoodMaxStock;

        /// <summary>
        /// The price of a single portion of platypus food.
        /// </summary>
        public decimal PlatypusFoodPrice;

        /// <summary>
        /// The amount of platypus food currently in stock (in pounds).
        /// </summary>
        public double PlatypusFoodStock;
    }
}