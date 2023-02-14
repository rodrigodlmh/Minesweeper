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

namespace RestaurantScenario
{
    /// <summary>
    /// Contains interaction logic for MainWindow.xaml.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Mom's restaurant.
        /// </summary>
        public Restaurant Moms;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Finds the first waitress in the guest list that has the specified name.
        /// </summary>
        /// <param name="name">The waitress's name.</param>
        /// <returns>The waitress with the passed in name.</returns>
        public Waitress FindWaitress(string name)
        {
            // Define a result variable.
            Waitress result = null;

            foreach (Waitress w in this.Moms.Waitresses)
            {
                // If a matching waitress was found...
                if (w.Name == name)
                {
                    // Set the temporary variable to the waitress.
                    result = w;

                    // Break out of the loop.
                    break;
                }
            }

            // Return the result.
            return result;
        }

        /// <summary>
        /// Gives a waitress an increase in (annual) salary by the amount specified.
        /// </summary>
        /// <param name="amount">The amount by which to increase the waitress' (annual) salary.</param>
        /// <param name="waitressName">The name of the waitress of which to give a raise.</param>
        public void GiveWaitressRaise(decimal amount, string waitressName)
        {
            // Find a waitress of the specified name.
            Waitress waitress = this.FindWaitress(waitressName);

            // If a waitress was found...
            if (waitress != null)
            {
                // Increase the waitress' salary by the specified amount.
                waitress.Salary += amount;
            }
        }

        /// <summary>
        /// Calculates the total amount due for the ticket.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void calculateTicketTotalDueButton_Click(object sender, RoutedEventArgs e)
        {
            // Define and initialize an accumlator variable.
            decimal totalDue = 0m;

            // Loop through the list of menu items in the ticket.
            foreach (MenuItem mi in this.Moms.TheRegular.MyTicket.MenuItems)
            {
                // Add the price of each menu item to the total
                totalDue += mi.Price;
            }

            // Assign the ticket's total due field to the calculated value.
            this.Moms.TheRegular.MyTicket.TotalDue = totalDue;
        }

        /// <summary>
        /// Gives Heidi a $1,000 raise.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void giveHeidi1000RaiseButton_Click(object sender, RoutedEventArgs e)
        {
            // Give Heidi a $1,000 raise.
            this.GiveWaitressRaise(1000m, "Heidi");
        }

        /// <summary>
        /// Requests that Heidi seat "The Regular".
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void heidiSeatPatronButton_Click(object sender, RoutedEventArgs e)
        {
            // Define a temporary variable to hold Heidi.
            Waitress heidi;

            // Find Svanhilde from the list of waitresses.
            heidi = this.FindWaitress("Heidi");

            // If Heidi was found...
            if (heidi != null)
            {
                // Have Heidi seat The Regular at his preferred table.
                this.Moms.TheRegular.TableNumber = this.Moms.TheRegular.PreferredTableNumber;

                // Increment a counter indicating the number of patrons Heidi has seated.
                heidi.NumberOfPatronsSeated++;
            }
        }

        /// <summary>
        /// Creates a restaurant and related objects.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void newRestaurantButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the Restaurant class.
            this.Moms = new Restaurant();

            // Set field values of Moms.
            this.Moms.Capacity = 25;
            this.Moms.DinnerMenu = new Menu();
            this.Moms.LunchMenu = new Menu();
            this.Moms.Name = "Mom's";
            this.Moms.Owner = new Cook();
            this.Moms.TheRegular = new Patron();
            this.Moms.Waitresses = new List<Waitress>();

            // Set field values of the dinner menu.
            this.Moms.DinnerMenu.Color = "Black";
            this.Moms.DinnerMenu.NumberOfPages = 6;
            this.Moms.DinnerMenu.Type = "Dinner";

            // Set field values of the lunch menu.
            this.Moms.LunchMenu.Color = "Black";
            this.Moms.LunchMenu.NumberOfPages = 4;
            this.Moms.LunchMenu.Type = "Lunch";

            // Set field values of the owner.
            this.Moms.Owner.Breadbasket = new Basket();
            this.Moms.Owner.BreadOven = new Oven();
            this.Moms.Owner.GasStove = new Stove();
            this.Moms.Owner.Name = "Vladimir";
            this.Moms.Owner.NumberOfMenuItemsCooked = 25;
            this.Moms.Owner.Salary = 28000m;
            this.Moms.Owner.SoupVat = new Vat();

            // Set field values of the breadbasket.
            this.Moms.Owner.Breadbasket.BreadstickCapacity = 30;
            this.Moms.Owner.Breadbasket.BreadstickCount = 30;

            // Set field values of the bread oven.
            this.Moms.Owner.BreadOven.BreadstickBatchSize = 20;
            this.Moms.Owner.BreadOven.IsInUse = false;
            this.Moms.Owner.BreadOven.NumberOfBreadsticksBaked = 255;

            // Set field values of the gas stove.
            this.Moms.Owner.GasStove.AmountOfSoupMade = 174;
            this.Moms.Owner.GasStove.IsInUse = false;
            this.Moms.Owner.GasStove.SoupBatchSize = 12;

            // Set field values of the soup vat.
            this.Moms.Owner.SoupVat.Capacity = 24;
            this.Moms.Owner.SoupVat.Level = 24;
            this.Moms.Owner.SoupVat.Type = "Soup";

            // Set field values of the regular.
            this.Moms.TheRegular.FavoriteMealName = "Meatloaf";
            this.Moms.TheRegular.MyTicket = new Ticket();
            this.Moms.TheRegular.Name = "Frank";
            this.Moms.TheRegular.PreferredTableNumber = 2;

            // Set field values of the regular's ticket.
            this.Moms.TheRegular.MyTicket.MenuItems = new List<MenuItem>();

            // Define a temporary menu item variable.
            MenuItem menuItem;

            // Create an instance of the MenuItem class (coffee).
            menuItem = new MenuItem();

            // Set field values of the coffee.
            menuItem.Cost = 0.12m;
            menuItem.Price = 1.50m;
            menuItem.Type = "Coffee";

            // Add the coffee to the ticket.
            this.Moms.TheRegular.MyTicket.MenuItems.Add(menuItem);

            // Create an instance of the MenuItem class (meatloaf).
            menuItem = new MenuItem();

            // Set field values of the meatloaf.
            menuItem.Cost = 2.25m;
            menuItem.Price = 7.99m;
            menuItem.Type = "Meatloaf";

            // Add the meatloaf to the ticket.
            this.Moms.TheRegular.MyTicket.MenuItems.Add(menuItem);

            // Define a temporary waitress variable.
            Waitress waitress;

            // Create an instance of the Waitress class (Svanhilde).
            waitress = new Waitress();

            // Set field values of Svanhilde.
            waitress.Name = "Svanhilde";
            waitress.NumberOfCondimentsFilled = 257;
            waitress.NumberOfPatronsSeated = 395;
            waitress.NumberOfTablesSet = 64;
            waitress.Salary = 18575m;
            waitress.TableNumber = 1;
            waitress.Ticket = this.Moms.TheRegular.MyTicket;

            // Add Svanhilde to the restaurant's list of waitresses.
            this.Moms.Waitresses.Add(waitress);

            // Create an instance of the Waitress class (Heidi).
            waitress = new Waitress();

            // Set field values of Heidi.
            waitress.Name = "Heidi";
            waitress.NumberOfCondimentsFilled = 63;
            waitress.NumberOfPatronsSeated = 101;
            waitress.NumberOfTablesSet = 13;
            waitress.Salary = 16550m;
            waitress.TableNumber = 2;

            // Add Heidi to the restaurant's list of waitresses.
            this.Moms.Waitresses.Add(waitress);
        }
    }
}