//----------------------------------------------------------------------
// <copyright file="GameWindow.xaml.cs" company="😹👍">
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
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public partial class GameWindow : Window
    {
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        int tenthsOfSecondsElapsed;
        Game game;
        
            /// <summary>
            /// initialize the game screen and the timer
            /// </summary>
        public GameWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            game = new Game();
            game.FirstClick = false;
            game.minefield = new Minefield();
        }

        /// <summary>
        /// makes the timer work by increasing the time by 1 second every second
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e)
        {
            tenthsOfSecondsElapsed++;
            TimeTextBlock.Text = (tenthsOfSecondsElapsed / 1f).ToString("0s");
        }

        /// <summary>
        /// When the user first clicks on the minefield it will generate the mines and numbers
        /// </summary>
        private void ClickButton_Click(object sender, RoutedEventArgs e)
        {
            // If it is the first click the mine field is made with the parameters
            // to make sure to what ever the user clicked on isn't a bomb
            Coordinate coordinate = GetMouseClickCoordinates(); // Get coordinates of the first click
            if (!game.FirstClick)
            {
                // The player already made his first click
                game.FirstClick = true;

                // Set forbidden squares (where the player clicked)
                game.minefield.SetForbiddenCoordinates(coordinate);
                game.minefield.CreateSquares();
                game.minefield.GenerateMines();
                game.minefield.SetStateOfSquares();
                timer.Start();
                tenthsOfSecondsElapsed = 0;
            }

            // If the user has a flag on the square the user can't "uncover" what benith it
            State2 state2 = game.minefield.squares[coordinate.x, coordinate.y].state2;
            if (state2 == State2.Flag)
            {
                return;
            }

            if (game.minefield.squares[coordinate.x, coordinate.y].revlealed == true)
            {
                return;
            }

            State state = game.minefield.squares[coordinate.x, coordinate.y].state;

            // Shows the image corilating to the board on the square the user left clicked
            ChangeImageOnState(state, coordinate);
            if(game.minefield.squares[coordinate.x, coordinate.y].state == State.NoMines)
            {
                SearchMines(coordinate);
            }
        }

        /// <summary>
        /// changes the image on the square basedon its state
        /// </summary>
        private void ChangeImageOnState(State state, Coordinate coordinate)
        {
            string imageName = GetImageName(coordinate);
            switch (state)
            {
                case State.NoMines:
                    ChangeImage(imageName, "Images/Blank.jpg");
                    AfterClickCheck(coordinate);
                    break;
                case State.OneMine:
                    ChangeImage(imageName, "Images/1.jpg");
                    AfterClickCheck(coordinate);
                    break;
                case State.TwoMines:
                    ChangeImage(imageName, "Images/2.jpg");
                    AfterClickCheck(coordinate);
                    break;
                case State.ThreeMines:
                    ChangeImage(imageName, "Images/3.jpg");
                    AfterClickCheck(coordinate);
                    break;
                case State.FourMines:
                    ChangeImage(imageName, "Images/4.jpg");
                    AfterClickCheck(coordinate);
                    break;
                case State.FiveMines:
                    ChangeImage(imageName, "Images/5.jpg");
                    AfterClickCheck(coordinate);
                    break;
                case State.SixMines:
                    ChangeImage(imageName, "Images/6.jpg");
                    AfterClickCheck(coordinate);
                    break;
                case State.SevenMines:
                    ChangeImage(imageName, "Images/7.jpg");
                    AfterClickCheck(coordinate);
                    break;
                case State.EightMines:
                    ChangeImage(imageName, "Images/8.jpg");
                    AfterClickCheck(coordinate);
                    break;
                case State.IsAMine:
                    ChangeImage(imageName, "Images/Bomb.jpg");
                    AfterClickCheck(coordinate);
                    ShowMines();
                    timer.Stop();
                    TimeTextBlock.Text = TimeTextBlock.Text + " 😿";
                    // Player loses game
                    MessageBoxResult result = MessageBox.Show("Game over?", "Game Over 😿", MessageBoxButton.YesNo, MessageBoxImage.Hand);
                    if (result == MessageBoxResult.Yes)
                    {
                        Quit();
                    }
                    else
                    {
                        Restart();
                    }
                    break;
            }
        }

        /// <summary>
        /// When the user right clicks the minefield
        /// </summary>
        private void ClickButton_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!game.FirstClick)
            {
                return;
            }

            Coordinate coordinate = GetMouseClickCoordinates();
            State2 state2 = game.minefield.squares[coordinate.x, coordinate.y].state2;
            if (game.minefield.squares[coordinate.x, coordinate.y].revlealed)
            {
                return;
            }

            string imageName = "Image" + coordinate.y + "_" + coordinate.x;

            // gets what sqaure to show either a flag, question mark or back to blank
            switch (state2)
            {
                case State2.Blank:
                    ChangeImage(imageName, "Images/Grass_Question.png");
                    game.minefield.squares[coordinate.x, coordinate.y].state2 = State2.Question;
                    break;
                case State2.Question:
                    ChangeImage(imageName, "Images/Grass_Flag.png");
                    game.minefield.squares[coordinate.x, coordinate.y].state2 = State2.Flag;
                    if(game.minefield.squares[coordinate.x, coordinate.y].state == State.IsAMine)
                    {
                        game.minefield.minesLeft--;
                        MinesTextBlock.Text = game.minefield.minesLeft.ToString();
                    }
                    break;
                case State2.Flag:
                    ChangeImage(imageName, "Images/Grass.png");
                    game.minefield.squares[coordinate.x, coordinate.y].state2 = State2.Blank;
                    if (game.minefield.squares[coordinate.x, coordinate.y].state == State.IsAMine)
                    {
                        game.minefield.minesLeft++;
                        MinesTextBlock.Text = game.minefield.minesLeft.ToString();
                    }
                    break;
            }
        }

        /// <summary>
        /// update the image on the screen
        /// </summary>
        private void ChangeImage(string imageName, string source)
        {
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            Image targetImage = GetImage(imageName);
            bi3.UriSource = new Uri(source, UriKind.Relative);
            bi3.EndInit();
            targetImage.Source = bi3;
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

            // Size of each grid square
            coordinate.x = x / 25;
            coordinate.y = y / 25; 
            return coordinate;
        }

        private void ShowMines()
        {
            foreach (Coordinate coord in game.minefield.mineCoords)
            {
                int x = coord.x;
                int y = coord.y;
                if (game.minefield.squares[x, y].state == State.IsAMine)
                {
                    ChangeImage(GetImageName(coord), "Images/Bomb.jpg");
                }
            }
        }

        private string GetImageName(Coordinate coordinate)
        {
            string imageName = "Image" + coordinate.y + "_" + coordinate.x;
            return imageName;
        }

        private void AfterClickCheck(Coordinate coord)
        {
            if (game.minefield.squares[coord.x, coord.y].revlealed == false)
            {
                game.minefield.safeSquares--;
                if (game.minefield.safeSquares == 0)
                {
                    MessageBox.Show("you won");
                }
            }
            game.minefield.squares[coord.x, coord.y].revlealed = true;
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
        public void SearchMines(Coordinate coordinate)
        {
            
            for (int xNum = coordinate.x - 1; xNum <= coordinate.x + 1; xNum++)
            {
                for (int yNum = coordinate.y - 1; yNum <= coordinate.y + 1; yNum++)
                {
                    // if outside minefield area BORDERS!! OR ALREADY REVEALED
                    if (game.minefield.IsCoordinateValid(new Coordinate(xNum, yNum)))
                    {
                        if (game.minefield.squares[xNum, yNum].revlealed != true)
                        {
                            // if blank or question mark CHECK IF NOT FLAGGED 
                            if (game.minefield.squares[xNum, yNum].state2 == State2.Question || game.minefield.squares[xNum, yNum].state2 == State2.Blank || game.minefield.squares[xNum, yNum].state2 == State2.Flag)
                            {
                                // If the value is a blank
                                if (game.minefield.squares[xNum, yNum].state == State.NoMines)
                                {
                                    ChangeImage(GetImageName(new Coordinate(xNum, yNum)), "Images/Blank.jpg");
                                    game.minefield.squares[xNum, yNum].revlealed = true;
                                    List<Coordinate> coordinates = game.minefield.GetSurroundingCoordinates(new Coordinate(xNum, yNum));

                                    for (int i = 0; i < 8; i++)
                                    {
                                        // Check if outside the minefield
                                        if (game.minefield.IsCoordinateValid(coordinates[i]))
                                        {
                                            State state = game.minefield.squares[coordinates[i].x, coordinates[i].y].state;

                                            // not blank because we will check that blank 
                                            if (state != State.IsAMine)
                                            {
                                                ChangeImageOnState(state, coordinates[i]);
                                                game.minefield.squares[coordinates[i].x, coordinates[i].y].revlealed = true;
                                                if (state == State.NoMines)
                                                {
                                                    SearchMines(coordinates[i]);
                                                }
                                            }


                                        }

                                    }
                                }

                                // FIND WHAT NUMBER IT IS
                                else if (game.minefield.IsCoordinateValid(coordinate))
                                {
                                    State state = game.minefield.squares[xNum, yNum].state;
                                    if (state != State.NoMines && state != State.IsAMine)
                                    {

                                        ChangeImageOnState(state, new Coordinate(xNum, yNum));
                                        game.minefield.squares[xNum, yNum].revlealed = true;
                                    }

                                }
                            }
                        }
                    }
                }
            }
        }
        private void ShowMinesCB_Checked(object sender, RoutedEventArgs e)
        {
            if (game.FirstClick)
            {
                ShowMines();
                ShowMinesCB.IsEnabled = false;
            }
        }

        // Returns back a new image of the square of what the user did 
        Image GetImage(string imageName)
        {
            // 256 if else
            if (imageName == "Image0_0")
            {
                return this.Image0_0;
            }
            else if (imageName == "Image1_0")
            {
                return this.Image1_0;
            }
            else if (imageName == "Image2_0")
            {
                return this.Image2_0;
            }
            else if (imageName == "Image3_0")
            {
                return this.Image3_0;
            }
            else if (imageName == "Image4_0")
            {
                return this.Image4_0;
            }
            else if (imageName == "Image5_0")
            {
                return this.Image5_0;
            }
            else if (imageName == "Image6_0")
            {
                return this.Image6_0;
            }
            else if (imageName == "Image7_0")
            {
                return this.Image7_0;
            }
            else if (imageName == "Image8_0")
            {
                return this.Image8_0;
            }
            else if (imageName == "Image9_0")
            {
                return this.Image9_0;
            }
            else if (imageName == "Image10_0")
            {
                return this.Image10_0;
            }
            else if (imageName == "Image11_0")
            {
                return this.Image11_0;
            }
            else if (imageName == "Image12_0")
            {
                return this.Image12_0;
            }
            else if (imageName == "Image13_0")
            {
                return this.Image13_0;
            }
            else if (imageName == "Image14_0")
            {
                return this.Image14_0;
            }
            else if (imageName == "Image15_0")
            {
                return this.Image15_0;
            }
            else if (imageName == "Image0_1")
            {
                return this.Image0_1;
            }
            else if (imageName == "Image1_1")
            {
                return this.Image1_1;
            }
            else if (imageName == "Image2_1")
            {
                return this.Image2_1;
            }
            else if (imageName == "Image3_1")
            {
                return this.Image3_1;
            }
            else if (imageName == "Image4_1")
            {
                return this.Image4_1;
            }
            else if (imageName == "Image5_1")
            {
                return this.Image5_1;
            }
            else if (imageName == "Image6_1")
            {
                return this.Image6_1;
            }
            else if (imageName == "Image7_1")
            {
                return this.Image7_1;
            }
            else if (imageName == "Image8_1")
            {
                return this.Image8_1;
            }
            else if (imageName == "Image9_1")
            {
                return this.Image9_1;
            }
            else if (imageName == "Image10_1")
            {
                return this.Image10_1;
            }
            else if (imageName == "Image11_1")
            {
                return this.Image11_1;
            }
            else if (imageName == "Image12_1")
            {
                return this.Image12_1;
            }
            else if (imageName == "Image13_1")
            {
                return this.Image13_1;
            }
            else if (imageName == "Image14_1")
            {
                return this.Image14_1;
            }
            else if (imageName == "Image15_1")
            {
                return this.Image15_1;
            }
            else if (imageName == "Image0_2")
            {
                return this.Image0_2;
            }
            else if (imageName == "Image1_2")
            {
                return this.Image1_2;
            }
            else if (imageName == "Image2_2")
            {
                return this.Image2_2;
            }
            else if (imageName == "Image3_2")
            {
                return this.Image3_2;
            }
            else if (imageName == "Image4_2")
            {
                return this.Image4_2;
            }
            else if (imageName == "Image5_2")
            {
                return this.Image5_2;
            }
            else if (imageName == "Image6_2")
            {
                return this.Image6_2;
            }
            else if (imageName == "Image7_2")
            {
                return this.Image7_2;
            }
            else if (imageName == "Image8_2")
            {
                return this.Image8_2;
            }
            else if (imageName == "Image9_2")
            {
                return this.Image9_2;
            }
            else if (imageName == "Image10_2")
            {
                return this.Image10_2;
            }
            else if (imageName == "Image11_2")
            {
                return this.Image11_2;
            }
            else if (imageName == "Image12_2")
            {
                return this.Image12_2;
            }
            else if (imageName == "Image13_2")
            {
                return this.Image13_2;
            }
            else if (imageName == "Image14_2")
            {
                return this.Image14_2;
            }
            else if (imageName == "Image15_2")
            {
                return this.Image15_2;
            }
            else if (imageName == "Image0_3")
            {
                return this.Image0_3;
            }
            else if (imageName == "Image1_3")
            {
                return this.Image1_3;
            }
            else if (imageName == "Image2_3")
            {
                return this.Image2_3;
            }
            else if (imageName == "Image3_3")
            {
                return this.Image3_3;
            }
            else if (imageName == "Image4_3")
            {
                return this.Image4_3;
            }
            else if (imageName == "Image5_3")
            {
                return this.Image5_3;
            }
            else if (imageName == "Image6_3")
            {
                return this.Image6_3;
            }
            else if (imageName == "Image7_3")
            {
                return this.Image7_3;
            }
            else if (imageName == "Image8_3")
            {
                return this.Image8_3;
            }
            else if (imageName == "Image9_3")
            {
                return this.Image9_3;
            }
            else if (imageName == "Image10_3")
            {
                return this.Image10_3;
            }
            else if (imageName == "Image11_3")
            {
                return this.Image11_3;
            }
            else if (imageName == "Image12_3")
            {
                return this.Image12_3;
            }
            else if (imageName == "Image13_3")
            {
                return this.Image13_3;
            }
            else if (imageName == "Image14_3")
            {
                return this.Image14_3;
            }
            else if (imageName == "Image15_3")
            {
                return this.Image15_3;
            }
            else if (imageName == "Image0_4")
            {
                return this.Image0_4;
            }
            else if (imageName == "Image1_4")
            {
                return this.Image1_4;
            }
            else if (imageName == "Image2_4")
            {
                return this.Image2_4;
            }
            else if (imageName == "Image3_4")
            {
                return this.Image3_4;
            }
            else if (imageName == "Image4_4")
            {
                return this.Image4_4;
            }
            else if (imageName == "Image5_4")
            {
                return this.Image5_4;
            }
            else if (imageName == "Image6_4")
            {
                return this.Image6_4;
            }
            else if (imageName == "Image7_4")
            {
                return this.Image7_4;
            }
            else if (imageName == "Image8_4")
            {
                return this.Image8_4;
            }
            else if (imageName == "Image9_4")
            {
                return this.Image9_4;
            }
            else if (imageName == "Image10_4")
            {
                return this.Image10_4;
            }
            else if (imageName == "Image11_4")
            {
                return this.Image11_4;
            }
            else if (imageName == "Image12_4")
            {
                return this.Image12_4;
            }
            else if (imageName == "Image13_4")
            {
                return this.Image13_4;
            }
            else if (imageName == "Image14_4")
            {
                return this.Image14_4;
            }
            else if (imageName == "Image15_4")
            {
                return this.Image15_4;
            }
            else if (imageName == "Image0_5")
            {
                return this.Image0_5;
            }
            else if (imageName == "Image1_5")
            {
                return this.Image1_5;
            }
            else if (imageName == "Image2_5")
            {
                return this.Image2_5;
            }
            else if (imageName == "Image3_5")
            {
                return this.Image3_5;
            }
            else if (imageName == "Image4_5")
            {
                return this.Image4_5;
            }
            else if (imageName == "Image5_5")
            {
                return this.Image5_5;
            }
            else if (imageName == "Image6_5")
            {
                return this.Image6_5;
            }
            else if (imageName == "Image7_5")
            {
                return this.Image7_5;
            }
            else if (imageName == "Image8_5")
            {
                return this.Image8_5;
            }
            else if (imageName == "Image9_5")
            {
                return this.Image9_5;
            }
            else if (imageName == "Image10_5")
            {
                return this.Image10_5;
            }
            else if (imageName == "Image11_5")
            {
                return this.Image11_5;
            }
            else if (imageName == "Image12_5")
            {
                return this.Image12_5;
            }
            else if (imageName == "Image13_5")
            {
                return this.Image13_5;
            }
            else if (imageName == "Image14_5")
            {
                return this.Image14_5;
            }
            else if (imageName == "Image15_5")
            {
                return this.Image15_5;
            }
            else if (imageName == "Image0_6")
            {
                return this.Image0_6;
            }
            else if (imageName == "Image1_6")
            {
                return this.Image1_6;
            }
            else if (imageName == "Image2_6")
            {
                return this.Image2_6;
            }
            else if (imageName == "Image3_6")
            {
                return this.Image3_6;
            }
            else if (imageName == "Image4_6")
            {
                return this.Image4_6;
            }
            else if (imageName == "Image5_6")
            {
                return this.Image5_6;
            }
            else if (imageName == "Image6_6")
            {
                return this.Image6_6;
            }
            else if (imageName == "Image7_6")
            {
                return this.Image7_6;
            }
            else if (imageName == "Image8_6")
            {
                return this.Image8_6;
            }
            else if (imageName == "Image9_6")
            {
                return this.Image9_6;
            }
            else if (imageName == "Image10_6")
            {
                return this.Image10_6;
            }
            else if (imageName == "Image11_6")
            {
                return this.Image11_6;
            }
            else if (imageName == "Image12_6")
            {
                return this.Image12_6;
            }
            else if (imageName == "Image13_6")
            {
                return this.Image13_6;
            }
            else if (imageName == "Image14_6")
            {
                return this.Image14_6;
            }
            else if (imageName == "Image15_6")
            {
                return this.Image15_6;
            }
            else if (imageName == "Image0_7")
            {
                return this.Image0_7;
            }
            else if (imageName == "Image1_7")
            {
                return this.Image1_7;
            }
            else if (imageName == "Image2_7")
            {
                return this.Image2_7;
            }
            else if (imageName == "Image3_7")
            {
                return this.Image3_7;
            }
            else if (imageName == "Image4_7")
            {
                return this.Image4_7;
            }
            else if (imageName == "Image5_7")
            {
                return this.Image5_7;
            }
            else if (imageName == "Image6_7")
            {
                return this.Image6_7;
            }
            else if (imageName == "Image7_7")
            {
                return this.Image7_7;
            }
            else if (imageName == "Image8_7")
            {
                return this.Image8_7;
            }
            else if (imageName == "Image9_7")
            {
                return this.Image9_7;
            }
            else if (imageName == "Image10_7")
            {
                return this.Image10_7;
            }
            else if (imageName == "Image11_7")
            {
                return this.Image11_7;
            }
            else if (imageName == "Image12_7")
            {
                return this.Image12_7;
            }
            else if (imageName == "Image13_7")
            {
                return this.Image13_7;
            }
            else if (imageName == "Image14_7")
            {
                return this.Image14_7;
            }
            else if (imageName == "Image15_7")
            {
                return this.Image15_7;
            }
            else if (imageName == "Image0_8")
            {
                return this.Image0_8;
            }
            else if (imageName == "Image1_8")
            {
                return this.Image1_8;
            }
            else if (imageName == "Image2_8")
            {
                return this.Image2_8;
            }
            else if (imageName == "Image3_8")
            {
                return this.Image3_8;
            }
            else if (imageName == "Image4_8")
            {
                return this.Image4_8;
            }
            else if (imageName == "Image5_8")
            {
                return this.Image5_8;
            }
            else if (imageName == "Image6_8")
            {
                return this.Image6_8;
            }
            else if (imageName == "Image7_8")
            {
                return this.Image7_8;
            }
            else if (imageName == "Image8_8")
            {
                return this.Image8_8;
            }
            else if (imageName == "Image9_8")
            {
                return this.Image9_8;
            }
            else if (imageName == "Image10_8")
            {
                return this.Image10_8;
            }
            else if (imageName == "Image11_8")
            {
                return this.Image11_8;
            }
            else if (imageName == "Image12_8")
            {
                return this.Image12_8;
            }
            else if (imageName == "Image13_8")
            {
                return this.Image13_8;
            }
            else if (imageName == "Image14_8")
            {
                return this.Image14_8;
            }
            else if (imageName == "Image15_8")
            {
                return this.Image15_8;
            }
            else if (imageName == "Image0_9")
            {
                return this.Image0_9;
            }
            else if (imageName == "Image1_9")
            {
                return this.Image1_9;
            }
            else if (imageName == "Image2_9")
            {
                return this.Image2_9;
            }
            else if (imageName == "Image3_9")
            {
                return this.Image3_9;
            }
            else if (imageName == "Image4_9")
            {
                return this.Image4_9;
            }
            else if (imageName == "Image5_9")
            {
                return this.Image5_9;
            }
            else if (imageName == "Image6_9")
            {
                return this.Image6_9;
            }
            else if (imageName == "Image7_9")
            {
                return this.Image7_9;
            }
            else if (imageName == "Image8_9")
            {
                return this.Image8_9;
            }
            else if (imageName == "Image9_9")
            {
                return this.Image9_9;
            }
            else if (imageName == "Image10_9")
            {
                return this.Image10_9;
            }
            else if (imageName == "Image11_9")
            {
                return this.Image11_9;
            }
            else if (imageName == "Image12_9")
            {
                return this.Image12_9;
            }
            else if (imageName == "Image13_9")
            {
                return this.Image13_9;
            }
            else if (imageName == "Image14_9")
            {
                return this.Image14_9;
            }
            else if (imageName == "Image15_9")
            {
                return this.Image15_9;
            }
            else if (imageName == "Image0_10")
            {
                return this.Image0_10;
            }
            else if (imageName == "Image1_10")
            {
                return this.Image1_10;
            }
            else if (imageName == "Image2_10")
            {
                return this.Image2_10;
            }
            else if (imageName == "Image3_10")
            {
                return this.Image3_10;
            }
            else if (imageName == "Image4_10")
            {
                return this.Image4_10;
            }
            else if (imageName == "Image5_10")
            {
                return this.Image5_10;
            }
            else if (imageName == "Image6_10")
            {
                return this.Image6_10;
            }
            else if (imageName == "Image7_10")
            {
                return this.Image7_10;
            }
            else if (imageName == "Image8_10")
            {
                return this.Image8_10;
            }
            else if (imageName == "Image9_10")
            {
                return this.Image9_10;
            }
            else if (imageName == "Image10_10")
            {
                return this.Image10_10;
            }
            else if (imageName == "Image11_10")
            {
                return this.Image11_10;
            }
            else if (imageName == "Image12_10")
            {
                return this.Image12_10;
            }
            else if (imageName == "Image13_10")
            {
                return this.Image13_10;
            }
            else if (imageName == "Image14_10")
            {
                return this.Image14_10;
            }
            else if (imageName == "Image15_10")
            {
                return this.Image15_10;
            }
            else if (imageName == "Image0_11")
            {
                return this.Image0_11;
            }
            else if (imageName == "Image1_11")
            {
                return this.Image1_11;
            }
            else if (imageName == "Image2_11")
            {
                return this.Image2_11;
            }
            else if (imageName == "Image3_11")
            {
                return this.Image3_11;
            }
            else if (imageName == "Image4_11")
            {
                return this.Image4_11;
            }
            else if (imageName == "Image5_11")
            {
                return this.Image5_11;
            }
            else if (imageName == "Image6_11")
            {
                return this.Image6_11;
            }
            else if (imageName == "Image7_11")
            {
                return this.Image7_11;
            }
            else if (imageName == "Image8_11")
            {
                return this.Image8_11;
            }
            else if (imageName == "Image9_11")
            {
                return this.Image9_11;
            }
            else if (imageName == "Image10_11")
            {
                return this.Image10_11;
            }
            else if (imageName == "Image11_11")
            {
                return this.Image11_11;
            }
            else if (imageName == "Image12_11")
            {
                return this.Image12_11;
            }
            else if (imageName == "Image13_11")
            {
                return this.Image13_11;
            }
            else if (imageName == "Image14_11")
            {
                return this.Image14_11;
            }
            else if (imageName == "Image15_11")
            {
                return this.Image15_11;
            }
            else if (imageName == "Image0_12")
            {
                return this.Image0_12;
            }
            else if (imageName == "Image1_12")
            {
                return this.Image1_12;
            }
            else if (imageName == "Image2_12")
            {
                return this.Image2_12;
            }
            else if (imageName == "Image3_12")
            {
                return this.Image3_12;
            }
            else if (imageName == "Image4_12")
            {
                return this.Image4_12;
            }
            else if (imageName == "Image5_12")
            {
                return this.Image5_12;
            }
            else if (imageName == "Image6_12")
            {
                return this.Image6_12;
            }
            else if (imageName == "Image7_12")
            {
                return this.Image7_12;
            }
            else if (imageName == "Image8_12")
            {
                return this.Image8_12;
            }
            else if (imageName == "Image9_12")
            {
                return this.Image9_12;
            }
            else if (imageName == "Image10_12")
            {
                return this.Image10_12;
            }
            else if (imageName == "Image11_12")
            {
                return this.Image11_12;
            }
            else if (imageName == "Image12_12")
            {
                return this.Image12_12;
            }
            else if (imageName == "Image13_12")
            {
                return this.Image13_12;
            }
            else if (imageName == "Image14_12")
            {
                return this.Image14_12;
            }
            else if (imageName == "Image15_12")
            {
                return this.Image15_12;
            }
            else if (imageName == "Image0_13")
            {
                return this.Image0_13;
            }
            else if (imageName == "Image1_13")
            {
                return this.Image1_13;
            }
            else if (imageName == "Image2_13")
            {
                return this.Image2_13;
            }
            else if (imageName == "Image3_13")
            {
                return this.Image3_13;
            }
            else if (imageName == "Image4_13")
            {
                return this.Image4_13;
            }
            else if (imageName == "Image5_13")
            {
                return this.Image5_13;
            }
            else if (imageName == "Image6_13")
            {
                return this.Image6_13;
            }
            else if (imageName == "Image7_13")
            {
                return this.Image7_13;
            }
            else if (imageName == "Image8_13")
            {
                return this.Image8_13;
            }
            else if (imageName == "Image9_13")
            {
                return this.Image9_13;
            }
            else if (imageName == "Image10_13")
            {
                return this.Image10_13;
            }
            else if (imageName == "Image11_13")
            {
                return this.Image11_13;
            }
            else if (imageName == "Image12_13")
            {
                return this.Image12_13;
            }
            else if (imageName == "Image13_13")
            {
                return this.Image13_13;
            }
            else if (imageName == "Image14_13")
            {
                return this.Image14_13;
            }
            else if (imageName == "Image15_13")
            {
                return this.Image15_13;
            }
            else if (imageName == "Image0_14")
            {
                return this.Image0_14;
            }
            else if (imageName == "Image1_14")
            {
                return this.Image1_14;
            }
            else if (imageName == "Image2_14")
            {
                return this.Image2_14;
            }
            else if (imageName == "Image3_14")
            {
                return this.Image3_14;
            }
            else if (imageName == "Image4_14")
            {
                return this.Image4_14;
            }
            else if (imageName == "Image5_14")
            {
                return this.Image5_14;
            }
            else if (imageName == "Image6_14")
            {
                return this.Image6_14;
            }
            else if (imageName == "Image7_14")
            {
                return this.Image7_14;
            }
            else if (imageName == "Image8_14")
            {
                return this.Image8_14;
            }
            else if (imageName == "Image9_14")
            {
                return this.Image9_14;
            }
            else if (imageName == "Image10_14")
            {
                return this.Image10_14;
            }
            else if (imageName == "Image11_14")
            {
                return this.Image11_14;
            }
            else if (imageName == "Image12_14")
            {
                return this.Image12_14;
            }
            else if (imageName == "Image13_14")
            {
                return this.Image13_14;
            }
            else if (imageName == "Image14_14")
            {
                return this.Image14_14;
            }
            else if (imageName == "Image15_14")
            {
                return this.Image15_14;
            }
            else if (imageName == "Image0_15")
            {
                return this.Image0_15;
            }
            else if (imageName == "Image1_15")
            {
                return this.Image1_15;
            }
            else if (imageName == "Image2_15")
            {
                return this.Image2_15;
            }
            else if (imageName == "Image3_15")
            {
                return this.Image3_15;
            }
            else if (imageName == "Image4_15")
            {
                return this.Image4_15;
            }
            else if (imageName == "Image5_15")
            {
                return this.Image5_15;
            }
            else if (imageName == "Image6_15")
            {
                return this.Image6_15;
            }
            else if (imageName == "Image7_15")
            {
                return this.Image7_15;
            }
            else if (imageName == "Image8_15")
            {
                return this.Image8_15;
            }
            else if (imageName == "Image9_15")
            {
                return this.Image9_15;
            }
            else if (imageName == "Image10_15")
            {
                return this.Image10_15;
            }
            else if (imageName == "Image11_15")
            {
                return this.Image11_15;
            }
            else if (imageName == "Image12_15")
            {
                return this.Image12_15;
            }
            else if (imageName == "Image13_15")
            {
                return this.Image13_15;
            }
            else if (imageName == "Image14_15")
            {
                return this.Image14_15;
            }
            else if (imageName == "Image15_15")
            {
                return this.Image15_15;
            }
            return Image0_0;
        }
    }
}
