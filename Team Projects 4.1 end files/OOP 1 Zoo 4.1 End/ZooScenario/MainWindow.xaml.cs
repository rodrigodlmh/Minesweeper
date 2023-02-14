using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZooScenario
{
    /// <summary>
    /// Contains interaction logic for MainWindow.xaml.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Minnesota's Como Zoo.
        /// </summary>
        public Zoo ComoZoo;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Calculates total and average animal weights of all animals in the zoo.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void calculateAnimalWeightsButton_Click(object sender, RoutedEventArgs e)
        {
            // Define and set a variable to hold the sum of all animal weights.
            double totalWeight = this.CalculateTotalAnimalWeight();

            // Set the zoo's total field to the accumulator variable.
            this.ComoZoo.TotalAnimalWeight = totalWeight;

            // Set the zoo's average field to the accumulator variable divided by the
            // total number of animals in the zoo (the Count of the Animals List).
            this.ComoZoo.AverageAnimalWeight = totalWeight / this.ComoZoo.Animals.Count;
        }

        /// <summary>
        /// Finds Fred's age.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void findFredAgeButton_Click(object sender, RoutedEventArgs e)
        {
            // Define and set a variable to hold Fred.
            Guest fred = this.FindGuest("Fred");

            // If Fred was found...
            if (fred != null)
            {
                // Retrieve Fred's age and store it in a variable.
                int fredsAge = fred.Age;
            }
        }

        /// <summary>
        /// Creates a zoo and related objects.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void newZooButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the Zoo class.
            this.ComoZoo = new Zoo();

            // Set field values of Como Zoo.
            this.ComoZoo.Animals = new List<Animal>();
            this.ComoZoo.AnimalSnackMachine = new VendingMachine();
            this.ComoZoo.B168 = new BirthingRoom();
            this.ComoZoo.Capacity = 1000;
            this.ComoZoo.Guests = new List<Guest>();
            this.ComoZoo.LadiesRoom = new Restroom();
            this.ComoZoo.MensRoom = new Restroom();
            this.ComoZoo.Name = "Como Zoo";
            this.ComoZoo.TicketBooth = new Booth();

            // Set field values of the animal snack machine.
            this.ComoZoo.AnimalSnackMachine.DingoFood = new Food();
            this.ComoZoo.AnimalSnackMachine.DingoFoodMaxStock = 20;
            this.ComoZoo.AnimalSnackMachine.DingoFoodPrice = 0.75m;
            this.ComoZoo.AnimalSnackMachine.DingoFoodStock = 5.5;
            this.ComoZoo.AnimalSnackMachine.MoneyBalance = 42.75m;
            this.ComoZoo.AnimalSnackMachine.PlatypusFood = new Food();
            this.ComoZoo.AnimalSnackMachine.PlatypusFoodMaxStock = 17;
            this.ComoZoo.AnimalSnackMachine.PlatypusFoodPrice = 0.5m;
            this.ComoZoo.AnimalSnackMachine.PlatypusFoodStock = 16;

            // Set field values of the dingo food.
            this.ComoZoo.AnimalSnackMachine.DingoFood.BestIfEatenBy = "Friday";
            this.ComoZoo.AnimalSnackMachine.DingoFood.Type = "Bone";
            this.ComoZoo.AnimalSnackMachine.DingoFood.Weight = 0.1;

            // Set field values of the platypus food.
            this.ComoZoo.AnimalSnackMachine.PlatypusFood.BestIfEatenBy = "Tuesday";
            this.ComoZoo.AnimalSnackMachine.PlatypusFood.Type = "Earthworms";
            this.ComoZoo.AnimalSnackMachine.PlatypusFood.Weight = 0.05;

            // Set field values of room B168.
            this.ComoZoo.B168.Temperature = 77;
            this.ComoZoo.B168.Vet = new Employee();

            // set vet values
            this.ComoZoo.B168.Vet.Name = "Flora";
            this.ComoZoo.B168.Vet.Number = 98;

            // Define a temporary animal variable.
            Animal animal;

            // Create an instance of the Animal class (Brutus).
            animal = new Animal();

            // Set field values of Brutus.
            animal.Age = 0;
            animal.IsPregnant = false;
            animal.Name = "Brutus";
            animal.Type = "Dingo";
            animal.Weight = 2.25;

            // Add Brutus to the zoo's animal list.
            this.ComoZoo.Animals.Add(animal);

            // Create an instance of the Animal class (Coco).
            animal = new Animal();

            // Set field values of Coco.
            animal.Age = 5;
            animal.IsPregnant = true;
            animal.Name = "Coco";
            animal.Type = "Dingo";
            animal.Weight = 25.8;

            // Add Coco to the zoo's animal list.
            this.ComoZoo.Animals.Add(animal);

            // Create an instance of the Animal class (Paddy).
            animal = new Animal();

            // Set field values of Paddy.
            animal.Age = 3;
            animal.IsPregnant = false;
            animal.Name = "Paddy";
            animal.Type = "Platypus";
            animal.Weight = 15.4;

            // Add Paddy to the zoo's animal list.
            this.ComoZoo.Animals.Add(animal);

            // Create an instance of the Animal class (Bella).
            animal = new Animal();

            // Set field values of Bella.
            animal.Age = 6;
            animal.IsPregnant = true;
            animal.Name = "Bella";
            animal.Type = "Dingo";
            animal.Weight = 23.5;

            // Add Bella to the zoo's animal list.
            this.ComoZoo.Animals.Add(animal);

            // Define a temporary guest variable.
            Guest guest;

            // Create an instance of the Guest class (Sally).
            guest = new Guest();

            // Set field values of Sally.
            guest.Age = 38;
            guest.Name = "Sally";
            guest.Wallet = new Wallet();

            // Set field values of Sally's wallet.
            guest.Wallet.Color = "Black";
            guest.Wallet.MoneyBalance = 150.35m;

            // Add Sally to the zoo's guest list.
            this.ComoZoo.Guests.Add(guest);

            // Create an instance of the Guest class (Fred).
            guest = new Guest();

            // Set field values of Fred.
            guest.Age = 11;
            guest.Name = "Fred";
            guest.Wallet = new Wallet();

            // Set field values of Fred's wallet.
            guest.Wallet.Color = "Brown";
            guest.Wallet.MoneyBalance = 15m;

            // Add Fred to the zoo's guest list.
            this.ComoZoo.Guests.Add(guest);

            // Set field values of the ladies' restroom.
            this.ComoZoo.LadiesRoom.Capacity = 4;
            this.ComoZoo.LadiesRoom.Gender = "Female";
            this.ComoZoo.LadiesRoom.IsOccupied = false;

            // Set field values of the men's restroom.
            this.ComoZoo.MensRoom.Capacity = 4;
            this.ComoZoo.MensRoom.Gender = "Male";
            this.ComoZoo.MensRoom.IsOccupied = true;

            // Set field values of the ticket booth.
            this.ComoZoo.TicketBooth.Attendant = new Employee();
            this.ComoZoo.TicketBooth.MoneyBalance = 3640.25m;
            this.ComoZoo.TicketBooth.TicketCountSold = 236;
            this.ComoZoo.TicketBooth.TicketPrice = 15m;

            // Set field values of the ticket booth attendant.
            this.ComoZoo.TicketBooth.Attendant.Name = "Sam";
            this.ComoZoo.TicketBooth.Attendant.Number = 42;
        }

        /// <summary>
        /// Requests that Sally give Fred $5.00.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void sallyGiveFred5Button_Click(object sender, RoutedEventArgs e)
        {
            ComoZoo.Guests[0].GiveMoney("Sally", "Fred", 5m);
        }

        private void floraBirthDingoButton_Click(object sender, RoutedEventArgs e)
        {
            double initialWeight = ComoZoo.CalculateTotalAnimalWeight();

            Animal BirthingAnimal = ComoZoo.FindAnimal("Dingo", true);

            ComoZoo.BirthAnimal(BirthingAnimal);

            double finalWeight = ComoZoo.CalculateTotalAnimalWeight();
        }

        private void releaseBabyDingo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}