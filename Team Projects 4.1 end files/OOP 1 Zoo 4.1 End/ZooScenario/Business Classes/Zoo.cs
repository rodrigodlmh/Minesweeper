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

        /// <summary>
        /// Calculates total weight of all animals in the zoo.
        /// </summary>
        /// <returns>The weight of all animals in the zoo.</returns>
        public double CalculateTotalAnimalWeight()
        {
            // Define and initialize a result variable.
            double result = 0;

            // Loop through the zoo's list of animals (for each animal in the list).
            foreach (Animal a in this.ComoZoo.Animals)
            {
                // Add the current animal's weight to the accumulator variable.
                result += a.Weight;
            }

            // Return result.
            return result;
        }

        /// <summary>
        /// Finds a guest from the zoo's guest list.
        /// </summary>
        /// <param name="name">The name of the guest to find.</param>
        /// <returns>The first guest whose name matches.</returns>
        public Guest FindGuest(string name)
        {
            // Define and initialize a result variable.
            Guest result = null;

            // Loop through all guests in the zoo.
            foreach (Guest g in this.ComoZoo.Guests)
            {
                // If the desired guest was found...
                if (g.Name == name)
                {
                    // Set the variable to point to the current guest.
                    result = g;

                    // Break out of the loop (no need to continue looking).
                    break;
                }
            }

            // Return result.
            return result;
        }

        public void BirthAnimal(Animal mother)
        {
            Animal animal = B168.BirthAnimal(mother);
        }

        public Animal FindAnimal(string type)
        {
            
        }

        public Animal FindAnimal(string type, int age)
        {

        }

        public Animal FindAnimal(string type, bool isPregnant)
        {

        }
    }
}