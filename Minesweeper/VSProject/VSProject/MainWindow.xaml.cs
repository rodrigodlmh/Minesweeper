//----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="😹👍">
//     Company copyright tag.
// </copyright>
//----------------------------------------------------------------------
namespace VSProject
{
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

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// click on start button event
        /// </summary>
        /// <param name="sender"> a sender</param>
        /// <param name="e"> a letter</param>
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            // Open a different window based on the difficulty selected
            // Right know all options open the medium difficulty window
            int columns = 0;
            if(int.TryParse(columnsTB.Text, out columns))
            {
                int rows = 0;
                if (int.TryParse(rowsTB.Text, out rows))
                {
                    int mines = 0;
                    if (int.TryParse(minesTB.Text, out mines))
                    {
                        if(columns >= 1 && columns <= 30 && rows >= 1 && rows <= 22)
                        {
                            if ((rows*columns) >= mines)
                            {
                                Minesweeper window;
                                if (safteynetCB.IsChecked == true)
                                {
                                    window = new Minesweeper(columns, rows, mines, true);
                                }
                                else 
                                {
                                    window = new Minesweeper(columns, rows, mines, false);
                                }
                                window.Show();
                                this.Hide();
                            }
                            else
                            {
                                //mines are too big
                                MessageBox.Show("Invalid number of mines", "Mine issue 🤯");
                            }
                        }
                        else
                        {
                            //Columns or rows are not in the parameters of numbers
                            MessageBox.Show("You need to have the rows and columns more than zero and less than 100 🤯", "board issue");
                        }
                    }
                    else
                    {
                        // enter a valid number of mines
                        MessageBox.Show("You need to have the mines number more than zero 🤯", "mine issue");
                    }
                }
                else
                {
                    // enter a valid number of rows
                    MessageBox.Show("Your rows need to be a number. 🤯", "row issue");
                }
            }
            else
            {
                // enter a valid number of columns
                MessageBox.Show("Your columns need to be a number. 🤯", "column issue");
            }
        }

        /// <summary>
        /// select game difficulty (easy, medium, hard)
        /// </summary>
        /// <param name="sender"> a sender</param>
        /// <param name="e"> a letter</param>
        private void Difficulty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Set selection variable based on what the user chose in the menu
            string selection = Difficulty.SelectedItem.ToString();
            if (selection == "System.Windows.Controls.Button: Easy")
            {
                columnsTB.Text = "8";
                rowsTB.Text = "8";
                minesTB.Text = "10";
            }
            else if (selection == "System.Windows.Controls.Button: Medium")
            {
                columnsTB.Text = "16";
                rowsTB.Text = "16";
                minesTB.Text = "40";
            }
            else if (selection == "System.Windows.Controls.Button: Hard")
            {
                columnsTB.Text = "16";
                rowsTB.Text = "30";
                minesTB.Text = "99";
            }
        }

        /// <summary>
        /// Exit Button to close to the WPF 
        /// </summary>
        /// <param name="sender"> a sender</param>
        /// <param name="e"> a letter</param>
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// About the Developers message box and game version and the date
        /// </summary>
        /// <param name="sender"> a sender</param>
        /// <param name="e"> a letter</param>
        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Developers:\n\t Rodrigo De la Mora,\n\t Damian Olivo, \n\tDonald Swearing,\n\t Sam Thorpe  \nVersion: 1.1.1 \nDate: 2/7/2023 \nLists used: 7 \nArrays used: 2");          
        }

        /// <summary>
        /// button to show the rules of the game  
        /// </summary>
        /// <param name="sender"> a sender</param>
        /// <param name="e"> a letter</param>
        private void RulesButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Minesweeper Rules: \n\n" +
                "1. The goal is to uncover all cells that do not contain mines. \n" +
                "2. Left-click to uncover a cell. If the cell contains a mine, you lose.\n" +
                "3. Right-click to question-mark a cell if you think it contains a mine.\n" +
                "4. Right-click again to flag a cell if you are sure it contains a mine\n" +
                "5. The number on a cell indicates how many mines are in the surrounding 8 cells.\n" +
                "6. Uncover all cells that do not contain mines to win the game.\n" +
                "7. Be careful, one incorrect move can result in a loss!");
        }
    }
}
