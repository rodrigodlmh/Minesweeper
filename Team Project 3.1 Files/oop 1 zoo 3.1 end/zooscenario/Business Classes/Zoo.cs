using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooScenario
{
    /// <summary>
    /// The class which is used to represent a zoo.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Zoo
    {
        /// <summary>
        /// Contains all of the animals in the zoo.
        /// </summary>
        public List<Animal> Animals;

        /// <summary>
        /// The vending machine which allows guests to buy snacks for animals.
        /// </summary>
        public VendingMachine AnimalSnackMachine;

        /// <summary>
        /// The average weight of all animals in the zoo.
        /// </summary>
        public double AverageAnimalWeight;

        /// <summary>
        /// The room for birthing animals.
        /// </summary>
        public BirthingRoom B168;

        /// <summary>
        /// The maximum number of guests the zoo can accommodate at a given time.
        /// </summary>
        public int Capacity;

        /// <summary>
        /// Contains all of the guests currently in the zoo.
        /// </summary>
        public List<Guest> Guests;

        /// <summary>
        /// The ladies' restroom.
        /// </summary>
        public Restroom LadiesRoom;

        /// <summary>
        /// The men's restroom.
        /// </summary>
        public Restroom MensRoom;

        /// <summary>
        /// The name of the zoo.
        /// </summary>
        public string Name;

        /// <summary>
        /// The ticket booth.
        /// </summary>
        public Booth TicketBooth;

        /// <summary>
        /// The total weight of all animals in the zoo.
        /// </summary>
        public double TotalAnimalWeight;
    }
}