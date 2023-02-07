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
using System.Windows.Shapes;

namespace VSProject
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        Game game;
        public GameWindow()
        {
            InitializeComponent();
            game = new Game();
            game.FirstClick = false;
            game.minefield = new Minefield();
        }

        // When the user first clicks on the minefield it will generate the mines and numbers
        private void ClickButton_Click(object sender, RoutedEventArgs e)
        {
            // If it is the first click the mine field is made with the parameters
            // to make sure to what ever the user clicked on isn't a bomb
            Coordinate coordinate = GetMouseClickCoordinates(); // Get coordinates of the first click
            if (!game.FirstClick)
            {
                game.FirstClick = true; // The player already made his first click
                game.minefield.SetForbiddenCoordinates(coordinate);// Set forbidden squares (where the player clicked)
                game.minefield.CreateSquares();
                game.minefield.GenerateMines();
                game.minefield.SetStateOfSquares();
            }

            // If the user has a flag on the square the user can't "uncover" what benith it
            State2 state2 = game.minefield.squares[coordinate.x, coordinate.y].state2;
            if (state2 == State2.Flag)
            {
                return;
            }
            State state = game.minefield.squares[coordinate.x, coordinate.y].state;
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            string imageName = "Image" + coordinate.y + "_" + coordinate.x;
            Image targetImage = GetImage(imageName);

            // Shows the image corilating to the board on the square the user left clicked
            switch (state)
            {
                case State.NoMines:
                    bi3.UriSource = new Uri("Images/Blank.jpg", UriKind.Relative);
                    bi3.EndInit();
                    targetImage.Source = bi3;
                    game.minefield.squares[coordinate.x, coordinate.y].revlealed = true;
                    break;
                case State.OneMine:
                    bi3.UriSource = new Uri("Images/1.jpg", UriKind.Relative);
                    bi3.EndInit();
                    targetImage.Source = bi3;
                    game.minefield.squares[coordinate.x, coordinate.y].revlealed = true;
                    break;
                case State.TwoMines:
                    bi3.UriSource = new Uri("Images/2.jpg", UriKind.Relative);
                    bi3.EndInit();
                    targetImage.Source = bi3;
                    game.minefield.squares[coordinate.x, coordinate.y].revlealed = true;
                    break;
                case State.ThreeMines:
                    bi3.UriSource = new Uri("Images/3.jpg", UriKind.Relative);
                    bi3.EndInit();
                    targetImage.Source = bi3;
                    game.minefield.squares[coordinate.x, coordinate.y].revlealed = true;
                    break;
                case State.FourMines:
                    bi3.UriSource = new Uri("Images/4.jpg", UriKind.Relative);
                    bi3.EndInit();
                    targetImage.Source = bi3;
                    game.minefield.squares[coordinate.x, coordinate.y].revlealed = true;
                    break;
                case State.FiveMines:
                    bi3.UriSource = new Uri("Images/5.jpg", UriKind.Relative);
                    bi3.EndInit();
                    targetImage.Source = bi3;
                    game.minefield.squares[coordinate.x, coordinate.y].revlealed = true;
                    break;
                case State.SixMines:
                    bi3.UriSource = new Uri("Images/6.jpg", UriKind.Relative);
                    bi3.EndInit();
                    targetImage.Source = bi3;
                    game.minefield.squares[coordinate.x, coordinate.y].revlealed = true;
                    break;
                case State.SevenMines:
                    bi3.UriSource = new Uri("Images/7.jpg", UriKind.Relative);
                    bi3.EndInit();
                    targetImage.Source = bi3;
                    game.minefield.squares[coordinate.x, coordinate.y].revlealed = true;
                    break;
                case State.EightMines:
                    bi3.UriSource = new Uri("Images/8.jpg", UriKind.Relative);
                    bi3.EndInit();
                    targetImage.Source = bi3;
                    game.minefield.squares[coordinate.x, coordinate.y].revlealed = true;
                    break;
                case State.IsAMine:
                    bi3.UriSource = new Uri("Images/Bomb.jpg", UriKind.Relative);
                    bi3.EndInit();
                    targetImage.Source = bi3;
                    game.minefield.squares[coordinate.x, coordinate.y].revlealed = true;
                    // Player loses game
                    MessageBoxResult result = MessageBox.Show("Game over?", "Game Over", MessageBoxButton.YesNo, MessageBoxImage.Hand);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            Quit();
                            break;
                        case MessageBoxResult.No:
                            Restart();
                            break;
                    }
                    break;
            }
        }

        // Gets the coordniates of where evere the user clicked
        private Coordinate GetMouseClickCoordinates()
        {
            Point mousePosition = Mouse.GetPosition(MinefieldGrid);
            double doubleX = Math.Floor(mousePosition.X);
            double doubleY = Math.Floor(mousePosition.Y);
            int x = Convert.ToInt32(doubleX);
            int y = Convert.ToInt32(doubleY);
            Coordinate coordinate = new Coordinate(x, y);
            coordinate.x = x / 25;
            coordinate.y = y / 25; // Size of each grid square
            return coordinate;
        }

        // Shows a new game window and closes the prevous one
        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            Restart();
        }

        // Closes the gamewindow and opens the main window
        private void MainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            Quit();
        }
        // Creates a new window, opens it and closes the current
        private void Restart()
        {
            GameWindow restartWindow = new GameWindow();
            restartWindow.Show();
            this.Close();
        }
        // Creates a new main menu window, opens it and closes the current
        private void Quit()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        // When the user right clicks the minefield
        private void ClickButton_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(!game.FirstClick)
            {
                return;
            }
            Coordinate coordinate = GetMouseClickCoordinates();
            State2 state2 = game.minefield.squares[coordinate.x, coordinate.y].state2;

            if(game.minefield.squares[coordinate.x, coordinate.y].revlealed)
            {
                return;
            }

            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            string imageName = "Image" + coordinate.y + "_" + coordinate.x;
            Image targetImage = GetImage(imageName);

            // gets what sqaure to show either a flag, question mark or back to blank
            switch (state2)
            {
                case State2.Blank:
                    bi3.UriSource = new Uri("Images/Grass_Question.png", UriKind.Relative);
                    bi3.EndInit();
                    targetImage.Source = bi3;
                    game.minefield.squares[coordinate.x, coordinate.y].state2 = State2.Question;
                    break;
                case State2.Question:
                    bi3.UriSource = new Uri("Images/Grass_Flag.png", UriKind.Relative);
                    bi3.EndInit();
                    targetImage.Source = bi3;
                    game.minefield.squares[coordinate.x, coordinate.y].state2 = State2.Flag;
                    break;
                case State2.Flag:
                    bi3.UriSource = new Uri("Images/Grass.png", UriKind.Relative);
                    bi3.EndInit();
                    targetImage.Source = bi3;
                    game.minefield.squares[coordinate.x, coordinate.y].state2 = State2.Blank;
                    break;
            }
        }

        // Returns back a new image of the square of what the user did 
        Image GetImage(string imageName)
        {
            // 256 if else
            if (imageName == "Image0_0")
            {
                return Image0_0;
            }
            else if (imageName == "Image1_0")
            {
                return Image1_0;
            }
            else if (imageName == "Image2_0")
            {
                return Image2_0;
            }
            else if (imageName == "Image3_0")
            {
                return Image3_0;
            }
            else if (imageName == "Image4_0")
            {
                return Image4_0;
            }
            else if (imageName == "Image5_0")
            {
                return Image5_0;
            }
            else if (imageName == "Image6_0")
            {
                return Image6_0;
            }
            else if (imageName == "Image7_0")
            {
                return Image7_0;
            }
            else if (imageName == "Image8_0")
            {
                return Image8_0;
            }
            else if (imageName == "Image9_0")
            {
                return Image9_0;
            }
            else if (imageName == "Image10_0")
            {
                return Image10_0;
            }
            else if (imageName == "Image11_0")
            {
                return Image11_0;
            }
            else if (imageName == "Image12_0")
            {
                return Image12_0;
            }
            else if (imageName == "Image13_0")
            {
                return Image13_0;
            }
            else if (imageName == "Image14_0")
            {
                return Image14_0;
            }
            else if (imageName == "Image15_0")
            {
                return Image15_0;
            }
            else if (imageName == "Image0_1")
            {
                return Image0_1;
            }
            else if (imageName == "Image1_1")
            {
                return Image1_1;
            }
            else if (imageName == "Image2_1")
            {
                return Image2_1;
            }
            else if (imageName == "Image3_1")
            {
                return Image3_1;
            }
            else if (imageName == "Image4_1")
            {
                return Image4_1;
            }
            else if (imageName == "Image5_1")
            {
                return Image5_1;
            }
            else if (imageName == "Image6_1")
            {
                return Image6_1;
            }
            else if (imageName == "Image7_1")
            {
                return Image7_1;
            }
            else if (imageName == "Image8_1")
            {
                return Image8_1;
            }
            else if (imageName == "Image9_1")
            {
                return Image9_1;
            }
            else if (imageName == "Image10_1")
            {
                return Image10_1;
            }
            else if (imageName == "Image11_1")
            {
                return Image11_1;
            }
            else if (imageName == "Image12_1")
            {
                return Image12_1;
            }
            else if (imageName == "Image13_1")
            {
                return Image13_1;
            }
            else if (imageName == "Image14_1")
            {
                return Image14_1;
            }
            else if (imageName == "Image15_1")
            {
                return Image15_1;
            }
            else if (imageName == "Image0_2")
            {
                return Image0_2;
            }
            else if (imageName == "Image1_2")
            {
                return Image1_2;
            }
            else if (imageName == "Image2_2")
            {
                return Image2_2;
            }
            else if (imageName == "Image3_2")
            {
                return Image3_2;
            }
            else if (imageName == "Image4_2")
            {
                return Image4_2;
            }
            else if (imageName == "Image5_2")
            {
                return Image5_2;
            }
            else if (imageName == "Image6_2")
            {
                return Image6_2;
            }
            else if (imageName == "Image7_2")
            {
                return Image7_2;
            }
            else if (imageName == "Image8_2")
            {
                return Image8_2;
            }
            else if (imageName == "Image9_2")
            {
                return Image9_2;
            }
            else if (imageName == "Image10_2")
            {
                return Image10_2;
            }
            else if (imageName == "Image11_2")
            {
                return Image11_2;
            }
            else if (imageName == "Image12_2")
            {
                return Image12_2;
            }
            else if (imageName == "Image13_2")
            {
                return Image13_2;
            }
            else if (imageName == "Image14_2")
            {
                return Image14_2;
            }
            else if (imageName == "Image15_2")
            {
                return Image15_2;
            }
            else if (imageName == "Image0_3")
            {
                return Image0_3;
            }
            else if (imageName == "Image1_3")
            {
                return Image1_3;
            }
            else if (imageName == "Image2_3")
            {
                return Image2_3;
            }
            else if (imageName == "Image3_3")
            {
                return Image3_3;
            }
            else if (imageName == "Image4_3")
            {
                return Image4_3;
            }
            else if (imageName == "Image5_3")
            {
                return Image5_3;
            }
            else if (imageName == "Image6_3")
            {
                return Image6_3;
            }
            else if (imageName == "Image7_3")
            {
                return Image7_3;
            }
            else if (imageName == "Image8_3")
            {
                return Image8_3;
            }
            else if (imageName == "Image9_3")
            {
                return Image9_3;
            }
            else if (imageName == "Image10_3")
            {
                return Image10_3;
            }
            else if (imageName == "Image11_3")
            {
                return Image11_3;
            }
            else if (imageName == "Image12_3")
            {
                return Image12_3;
            }
            else if (imageName == "Image13_3")
            {
                return Image13_3;
            }
            else if (imageName == "Image14_3")
            {
                return Image14_3;
            }
            else if (imageName == "Image15_3")
            {
                return Image15_3;
            }
            else if (imageName == "Image0_4")
            {
                return Image0_4;
            }
            else if (imageName == "Image1_4")
            {
                return Image1_4;
            }
            else if (imageName == "Image2_4")
            {
                return Image2_4;
            }
            else if (imageName == "Image3_4")
            {
                return Image3_4;
            }
            else if (imageName == "Image4_4")
            {
                return Image4_4;
            }
            else if (imageName == "Image5_4")
            {
                return Image5_4;
            }
            else if (imageName == "Image6_4")
            {
                return Image6_4;
            }
            else if (imageName == "Image7_4")
            {
                return Image7_4;
            }
            else if (imageName == "Image8_4")
            {
                return Image8_4;
            }
            else if (imageName == "Image9_4")
            {
                return Image9_4;
            }
            else if (imageName == "Image10_4")
            {
                return Image10_4;
            }
            else if (imageName == "Image11_4")
            {
                return Image11_4;
            }
            else if (imageName == "Image12_4")
            {
                return Image12_4;
            }
            else if (imageName == "Image13_4")
            {
                return Image13_4;
            }
            else if (imageName == "Image14_4")
            {
                return Image14_4;
            }
            else if (imageName == "Image15_4")
            {
                return Image15_4;
            }
            else if (imageName == "Image0_5")
            {
                return Image0_5;
            }
            else if (imageName == "Image1_5")
            {
                return Image1_5;
            }
            else if (imageName == "Image2_5")
            {
                return Image2_5;
            }
            else if (imageName == "Image3_5")
            {
                return Image3_5;
            }
            else if (imageName == "Image4_5")
            {
                return Image4_5;
            }
            else if (imageName == "Image5_5")
            {
                return Image5_5;
            }
            else if (imageName == "Image6_5")
            {
                return Image6_5;
            }
            else if (imageName == "Image7_5")
            {
                return Image7_5;
            }
            else if (imageName == "Image8_5")
            {
                return Image8_5;
            }
            else if (imageName == "Image9_5")
            {
                return Image9_5;
            }
            else if (imageName == "Image10_5")
            {
                return Image10_5;
            }
            else if (imageName == "Image11_5")
            {
                return Image11_5;
            }
            else if (imageName == "Image12_5")
            {
                return Image12_5;
            }
            else if (imageName == "Image13_5")
            {
                return Image13_5;
            }
            else if (imageName == "Image14_5")
            {
                return Image14_5;
            }
            else if (imageName == "Image15_5")
            {
                return Image15_5;
            }
            else if (imageName == "Image0_6")
            {
                return Image0_6;
            }
            else if (imageName == "Image1_6")
            {
                return Image1_6;
            }
            else if (imageName == "Image2_6")
            {
                return Image2_6;
            }
            else if (imageName == "Image3_6")
            {
                return Image3_6;
            }
            else if (imageName == "Image4_6")
            {
                return Image4_6;
            }
            else if (imageName == "Image5_6")
            {
                return Image5_6;
            }
            else if (imageName == "Image6_6")
            {
                return Image6_6;
            }
            else if (imageName == "Image7_6")
            {
                return Image7_6;
            }
            else if (imageName == "Image8_6")
            {
                return Image8_6;
            }
            else if (imageName == "Image9_6")
            {
                return Image9_6;
            }
            else if (imageName == "Image10_6")
            {
                return Image10_6;
            }
            else if (imageName == "Image11_6")
            {
                return Image11_6;
            }
            else if (imageName == "Image12_6")
            {
                return Image12_6;
            }
            else if (imageName == "Image13_6")
            {
                return Image13_6;
            }
            else if (imageName == "Image14_6")
            {
                return Image14_6;
            }
            else if (imageName == "Image15_6")
            {
                return Image15_6;
            }
            else if (imageName == "Image0_7")
            {
                return Image0_7;
            }
            else if (imageName == "Image1_7")
            {
                return Image1_7;
            }
            else if (imageName == "Image2_7")
            {
                return Image2_7;
            }
            else if (imageName == "Image3_7")
            {
                return Image3_7;
            }
            else if (imageName == "Image4_7")
            {
                return Image4_7;
            }
            else if (imageName == "Image5_7")
            {
                return Image5_7;
            }
            else if (imageName == "Image6_7")
            {
                return Image6_7;
            }
            else if (imageName == "Image7_7")
            {
                return Image7_7;
            }
            else if (imageName == "Image8_7")
            {
                return Image8_7;
            }
            else if (imageName == "Image9_7")
            {
                return Image9_7;
            }
            else if (imageName == "Image10_7")
            {
                return Image10_7;
            }
            else if (imageName == "Image11_7")
            {
                return Image11_7;
            }
            else if (imageName == "Image12_7")
            {
                return Image12_7;
            }
            else if (imageName == "Image13_7")
            {
                return Image13_7;
            }
            else if (imageName == "Image14_7")
            {
                return Image14_7;
            }
            else if (imageName == "Image15_7")
            {
                return Image15_7;
            }
            else if (imageName == "Image0_8")
            {
                return Image0_8;
            }
            else if (imageName == "Image1_8")
            {
                return Image1_8;
            }
            else if (imageName == "Image2_8")
            {
                return Image2_8;
            }
            else if (imageName == "Image3_8")
            {
                return Image3_8;
            }
            else if (imageName == "Image4_8")
            {
                return Image4_8;
            }
            else if (imageName == "Image5_8")
            {
                return Image5_8;
            }
            else if (imageName == "Image6_8")
            {
                return Image6_8;
            }
            else if (imageName == "Image7_8")
            {
                return Image7_8;
            }
            else if (imageName == "Image8_8")
            {
                return Image8_8;
            }
            else if (imageName == "Image9_8")
            {
                return Image9_8;
            }
            else if (imageName == "Image10_8")
            {
                return Image10_8;
            }
            else if (imageName == "Image11_8")
            {
                return Image11_8;
            }
            else if (imageName == "Image12_8")
            {
                return Image12_8;
            }
            else if (imageName == "Image13_8")
            {
                return Image13_8;
            }
            else if (imageName == "Image14_8")
            {
                return Image14_8;
            }
            else if (imageName == "Image15_8")
            {
                return Image15_8;
            }
            else if (imageName == "Image0_9")
            {
                return Image0_9;
            }
            else if (imageName == "Image1_9")
            {
                return Image1_9;
            }
            else if (imageName == "Image2_9")
            {
                return Image2_9;
            }
            else if (imageName == "Image3_9")
            {
                return Image3_9;
            }
            else if (imageName == "Image4_9")
            {
                return Image4_9;
            }
            else if (imageName == "Image5_9")
            {
                return Image5_9;
            }
            else if (imageName == "Image6_9")
            {
                return Image6_9;
            }
            else if (imageName == "Image7_9")
            {
                return Image7_9;
            }
            else if (imageName == "Image8_9")
            {
                return Image8_9;
            }
            else if (imageName == "Image9_9")
            {
                return Image9_9;
            }
            else if (imageName == "Image10_9")
            {
                return Image10_9;
            }
            else if (imageName == "Image11_9")
            {
                return Image11_9;
            }
            else if (imageName == "Image12_9")
            {
                return Image12_9;
            }
            else if (imageName == "Image13_9")
            {
                return Image13_9;
            }
            else if (imageName == "Image14_9")
            {
                return Image14_9;
            }
            else if (imageName == "Image15_9")
            {
                return Image15_9;
            }
            else if (imageName == "Image0_10")
            {
                return Image0_10;
            }
            else if (imageName == "Image1_10")
            {
                return Image1_10;
            }
            else if (imageName == "Image2_10")
            {
                return Image2_10;
            }
            else if (imageName == "Image3_10")
            {
                return Image3_10;
            }
            else if (imageName == "Image4_10")
            {
                return Image4_10;
            }
            else if (imageName == "Image5_10")
            {
                return Image5_10;
            }
            else if (imageName == "Image6_10")
            {
                return Image6_10;
            }
            else if (imageName == "Image7_10")
            {
                return Image7_10;
            }
            else if (imageName == "Image8_10")
            {
                return Image8_10;
            }
            else if (imageName == "Image9_10")
            {
                return Image9_10;
            }
            else if (imageName == "Image10_10")
            {
                return Image10_10;
            }
            else if (imageName == "Image11_10")
            {
                return Image11_10;
            }
            else if (imageName == "Image12_10")
            {
                return Image12_10;
            }
            else if (imageName == "Image13_10")
            {
                return Image13_10;
            }
            else if (imageName == "Image14_10")
            {
                return Image14_10;
            }
            else if (imageName == "Image15_10")
            {
                return Image15_10;
            }
            else if (imageName == "Image0_11")
            {
                return Image0_11;
            }
            else if (imageName == "Image1_11")
            {
                return Image1_11;
            }
            else if (imageName == "Image2_11")
            {
                return Image2_11;
            }
            else if (imageName == "Image3_11")
            {
                return Image3_11;
            }
            else if (imageName == "Image4_11")
            {
                return Image4_11;
            }
            else if (imageName == "Image5_11")
            {
                return Image5_11;
            }
            else if (imageName == "Image6_11")
            {
                return Image6_11;
            }
            else if (imageName == "Image7_11")
            {
                return Image7_11;
            }
            else if (imageName == "Image8_11")
            {
                return Image8_11;
            }
            else if (imageName == "Image9_11")
            {
                return Image9_11;
            }
            else if (imageName == "Image10_11")
            {
                return Image10_11;
            }
            else if (imageName == "Image11_11")
            {
                return Image11_11;
            }
            else if (imageName == "Image12_11")
            {
                return Image12_11;
            }
            else if (imageName == "Image13_11")
            {
                return Image13_11;
            }
            else if (imageName == "Image14_11")
            {
                return Image14_11;
            }
            else if (imageName == "Image15_11")
            {
                return Image15_11;
            }
            else if (imageName == "Image0_12")
            {
                return Image0_12;
            }
            else if (imageName == "Image1_12")
            {
                return Image1_12;
            }
            else if (imageName == "Image2_12")
            {
                return Image2_12;
            }
            else if (imageName == "Image3_12")
            {
                return Image3_12;
            }
            else if (imageName == "Image4_12")
            {
                return Image4_12;
            }
            else if (imageName == "Image5_12")
            {
                return Image5_12;
            }
            else if (imageName == "Image6_12")
            {
                return Image6_12;
            }
            else if (imageName == "Image7_12")
            {
                return Image7_12;
            }
            else if (imageName == "Image8_12")
            {
                return Image8_12;
            }
            else if (imageName == "Image9_12")
            {
                return Image9_12;
            }
            else if (imageName == "Image10_12")
            {
                return Image10_12;
            }
            else if (imageName == "Image11_12")
            {
                return Image11_12;
            }
            else if (imageName == "Image12_12")
            {
                return Image12_12;
            }
            else if (imageName == "Image13_12")
            {
                return Image13_12;
            }
            else if (imageName == "Image14_12")
            {
                return Image14_12;
            }
            else if (imageName == "Image15_12")
            {
                return Image15_12;
            }
            else if (imageName == "Image0_13")
            {
                return Image0_13;
            }
            else if (imageName == "Image1_13")
            {
                return Image1_13;
            }
            else if (imageName == "Image2_13")
            {
                return Image2_13;
            }
            else if (imageName == "Image3_13")
            {
                return Image3_13;
            }
            else if (imageName == "Image4_13")
            {
                return Image4_13;
            }
            else if (imageName == "Image5_13")
            {
                return Image5_13;
            }
            else if (imageName == "Image6_13")
            {
                return Image6_13;
            }
            else if (imageName == "Image7_13")
            {
                return Image7_13;
            }
            else if (imageName == "Image8_13")
            {
                return Image8_13;
            }
            else if (imageName == "Image9_13")
            {
                return Image9_13;
            }
            else if (imageName == "Image10_13")
            {
                return Image10_13;
            }
            else if (imageName == "Image11_13")
            {
                return Image11_13;
            }
            else if (imageName == "Image12_13")
            {
                return Image12_13;
            }
            else if (imageName == "Image13_13")
            {
                return Image13_13;
            }
            else if (imageName == "Image14_13")
            {
                return Image14_13;
            }
            else if (imageName == "Image15_13")
            {
                return Image15_13;
            }
            else if (imageName == "Image0_14")
            {
                return Image0_14;
            }
            else if (imageName == "Image1_14")
            {
                return Image1_14;
            }
            else if (imageName == "Image2_14")
            {
                return Image2_14;
            }
            else if (imageName == "Image3_14")
            {
                return Image3_14;
            }
            else if (imageName == "Image4_14")
            {
                return Image4_14;
            }
            else if (imageName == "Image5_14")
            {
                return Image5_14;
            }
            else if (imageName == "Image6_14")
            {
                return Image6_14;
            }
            else if (imageName == "Image7_14")
            {
                return Image7_14;
            }
            else if (imageName == "Image8_14")
            {
                return Image8_14;
            }
            else if (imageName == "Image9_14")
            {
                return Image9_14;
            }
            else if (imageName == "Image10_14")
            {
                return Image10_14;
            }
            else if (imageName == "Image11_14")
            {
                return Image11_14;
            }
            else if (imageName == "Image12_14")
            {
                return Image12_14;
            }
            else if (imageName == "Image13_14")
            {
                return Image13_14;
            }
            else if (imageName == "Image14_14")
            {
                return Image14_14;
            }
            else if (imageName == "Image15_14")
            {
                return Image15_14;
            }
            else if (imageName == "Image0_15")
            {
                return Image0_15;
            }
            else if (imageName == "Image1_15")
            {
                return Image1_15;
            }
            else if (imageName == "Image2_15")
            {
                return Image2_15;
            }
            else if (imageName == "Image3_15")
            {
                return Image3_15;
            }
            else if (imageName == "Image4_15")
            {
                return Image4_15;
            }
            else if (imageName == "Image5_15")
            {
                return Image5_15;
            }
            else if (imageName == "Image6_15")
            {
                return Image6_15;
            }
            else if (imageName == "Image7_15")
            {
                return Image7_15;
            }
            else if (imageName == "Image8_15")
            {
                return Image8_15;
            }
            else if (imageName == "Image9_15")
            {
                return Image9_15;
            }
            else if (imageName == "Image10_15")
            {
                return Image10_15;
            }
            else if (imageName == "Image11_15")
            {
                return Image11_15;
            }
            else if (imageName == "Image12_15")
            {
                return Image12_15;
            }
            else if (imageName == "Image13_15")
            {
                return Image13_15;
            }
            else if (imageName == "Image14_15")
            {
                return Image14_15;
            }
            else if (imageName == "Image15_15")
            {
                return Image15_15;
            }
            return Image0_0;
        }
    }
}
