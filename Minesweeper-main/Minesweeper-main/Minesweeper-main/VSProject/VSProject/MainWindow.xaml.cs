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
        // Difficulty selection (0 = easy, 1 = medium, 2 = hard, 3 = impossible)
        int difficultySelection = 0;

        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            // Open a different window based on the difficulty selected
            // Right know all options open the medium difficulty window
            switch (this.difficultySelection)
            {
                case 0:
                    // Open easy window
                    GameWindow window = new GameWindow();
                    window.Show();
                    this.Hide();
                    break;
                case 1:
                    GameWindow window2 = new GameWindow();
                    window2.Show();
                    this.Hide();
                    break;
                case 2:
                    // Open hard window
                    GameWindow window3 = new GameWindow();
                    window3.Show();
                    this.Hide();
                    break;
                case 3:
                    // Open impossible window
                    GameWindow window4 = new GameWindow();
                    window4.Show();
                    this.Hide();
                    break;
                default:
                    // Open easy window
                    GameWindow window5 = new GameWindow();
                    window5.Show();
                    this.Hide();
                    break;
            }
        }

        private void Difficulty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Set selection variable based on what the user chose in the menu
            string selection = Difficulty.SelectedItem.ToString();
            if (selection == "System.Windows.Controls.Button: Easy")
            {
                this.difficultySelection = 0;
            }
            else if (selection == "System.Windows.Controls.Button: Medium")
            {
                this.difficultySelection = 1;
            }
            else if (selection == "System.Windows.Controls.Button: Hard")
            {
                this.difficultySelection = 2;
            }
            else
            {
                this.difficultySelection = 3;
            }
        }

        // Exit Button
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // About the Developers
        private void aboutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Developers: Rodrigo De la Mora, Damian Olivo, Donald Swearing, Sam Thorpe  \nVersion: 1.1.1 \nDate: 2/7/2023");          
        }

        ///button to show the amou
        private void rulesButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Minesweeper Rules: \n\n" +
                "1. The goal is to uncover all cells that do not contain mines. \n" +
                "2. Left-click to uncover a cell. If the cell contains a mine, you lose.\n" +
                "3. Right-click to flag a cell if you think it contains a mine.\n" +
                "4. The number on a cell indicates how many mines are in the surrounding cells.\n" +
                "5. Uncover all cells that do not contain mines to win the game.\n" +
                "6. Be careful, one incorrect move can result in a loss!");
        }
    }
}
