//----------------------------------------------------------------------
// <copyright file="Minesweeper.xaml.cs" company="😹👍">
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
    using System.Windows.Shapes;
    using System.Windows.Threading;

    /// <summary>
    /// Interaction logic for Minesweeper.xaml
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public partial class Minesweeper : Window
    {
        /// <summary>
        /// Dispatcher timer object
        /// </summary>
        public System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();

        /// <summary>
        /// timer variable
        /// </summary>
        public int TenthsOfSecondsElapsed;

        /// <summary>
        /// instance of the game class
        /// </summary>
        public Game Game;

        /// <summary>
        /// an array of the number of images/blocks that are going to be in the game board
        /// </summary>
        public Image[,] Images;

        /// <summary>
        /// creates an instance of the grid that can be reused for the game 
        /// </summary>
        public Grid Grid;

        /// <summary>
        /// canvas object
        /// </summary>
        public Canvas Canvas;

        /// <summary>
        /// row count
        /// </summary>
        public int Rows;

        /// <summary>
        /// columns count
        /// </summary>
        public int Columns;

        /// <summary>
        /// mine count
        /// </summary>
        public int Mines;

        /// <summary>
        /// Safe first click?
        /// </summary>
        public bool FirstClickSafe;

        /// <summary>
        /// the one playing the game
        /// </summary>
        public int Player;

        /// <summary>
        /// text block to put the time in seconds
        /// </summary>
        private TextBlock timerText;

        /// <summary>
        /// restart button to get a new board of the same size but newly randomnized bombs s
        /// </summary>
        private Button restartButton;

        /// <summary>
        /// exit button to be able to go back to main window or to finish executing the whole game. 
        /// </summary>
        private Button exitButton;

        /// <summary>
        /// Initializes a new instance of the <see cref="Minesweeper"/> class 
        /// </summary>
        /// <param name="rows"> the number of rows</param>
        /// <param name="columns"> the number of columns </param>
        /// <param name="mines"> the number of mines</param>
        /// <param name="firstClickSafe"> determine if the first click is guaranteed to be safe or not</param> 
        /// <param name="player"> who is playing the game, a living organism or a computer</param>
        public Minesweeper(int rows, int columns, int mines, bool firstClickSafe, int player)
        {
            this.InitializeComponent();

            this.Rows = rows;
            this.Columns = columns;
            this.Mines = mines;
            this.FirstClickSafe = firstClickSafe;
            this.Player = player;

            this.Width = (columns * 25) + 200;
            this.Height = (rows * 25) + 200;
            this.Game = new Game(rows, columns, mines, this.Player);
            this.Game.FirstClick = true;
            this.Game.SafetyNet = firstClickSafe;

            this.Canvas = new Canvas();
            this.Content = this.Canvas;
            this.Canvas.Width = (columns * 25) + 200;
            this.Canvas.Height = (rows * 25) + 200;
            this.Canvas.Background = Brushes.LightSteelBlue;

            this.CreateGrid();
            this.CreateImages();
            this.Timer.Interval = TimeSpan.FromSeconds(1);
            this.Timer.Tick += this.Timer_Tick;
        }

        /// <summary>
        /// creates the grid for the game board with the number of rows and columns specified by the user 
        /// </summary>
        private void CreateGrid()
        {
            this.Grid = new Grid();
            this.Grid.Width = this.Game.Columns * 25;
            this.Grid.Height = this.Game.Rows * 25;
            this.Grid.HorizontalAlignment = HorizontalAlignment.Center;
            this.Grid.VerticalAlignment = VerticalAlignment.Center;
            this.Grid.ShowGridLines = true;

            for (int i = 0; i < this.Game.Rows; i++)
            {
                RowDefinition rd = new RowDefinition();
                this.Grid.RowDefinitions.Add(rd);
            }

            for (int i = 0; i < this.Game.Columns; i++)
            {
                ColumnDefinition cd = new ColumnDefinition();
                this.Grid.ColumnDefinitions.Add(cd);
            }

            Canvas.SetTop(this.Grid, 25);
            Canvas.SetLeft(this.Grid, 20);
            this.Canvas.Children.Add(this.Grid);
            this.Grid.MouseLeftButtonDown += this.GridLeftMouseDown;
            this.Grid.MouseRightButtonDown += this.GridRightMouseDown;

            // textblock to display the timer 
            this.timerText = new TextBlock();
            this.timerText.Text = "0";
            Canvas.SetBottom(this.timerText, 150);
            Canvas.SetLeft(this.timerText, 20);
            this.Canvas.Children.Add(this.timerText);

            // button to restart a new game
            this.restartButton = new Button();
            this.restartButton.Content = "Restart";
            Canvas.SetBottom(this.restartButton, 100);
            Canvas.SetLeft(this.restartButton, 20);
            this.Canvas.Children.Add(this.restartButton);
            this.restartButton.Click += this.RestartButtonClick;

            // button to exit the game and go to the main menu=
            this.exitButton = new Button();
            this.exitButton.Content = "Exit";
            Canvas.SetBottom(this.exitButton, 100);
            Canvas.SetLeft(this.exitButton, 100);
            this.Canvas.Children.Add(this.exitButton);
            this.exitButton.Click += this.ExitButtonClick;

            if (Player > 0)
            {
                Button nextMoveButton = new Button();
                nextMoveButton.Content = "GPT, make your next move";
                Canvas.SetBottom(nextMoveButton, 150);
                Canvas.SetLeft(nextMoveButton, 200);
                this.Canvas.Children.Add(nextMoveButton);
                nextMoveButton.Click += nextMoveButtonClick;
            }
        }

        /// <summary>
        /// makes the computer player choose another square to interact with 
        /// </summary>
        private void nextMoveButtonClick(object sender, RoutedEventArgs e)
        {
            MakeMove();
        }


        private async void Wait()
        {
            // start the timer
            int timerValue = 0;
            int maxTimerValue = 1;

            while (timerValue < maxTimerValue)
            {
                // wait for 1 second
                await Task.Delay(1000); 
                timerValue++;
                
            }
        }



        /// <summary>
        /// the way computer player will play based on it's IQ
        ///</summary>
        private void MakeMove()
        {
            if (this.Game.FirstClick)
            {
                // The player already made his first click
                this.Game.FirstClick = false;
                Coordinate coord = Coordinate.GetRandomCoordinate(this.Columns, this.Rows);
                this.Game.StartSafeGame(coord);
                this.Game.GPT.RevealedCoords.Add(coord);
                this.Game.Minefield.Squares[coord.X, coord.Y].Revealed = true;
                ChangeImageOnState(Game.Minefield.Squares[coord.X, coord.Y].State, coord);
                SearchMines(coord);

                this.Timer.Start();
                this.TenthsOfSecondsElapsed = 0;
                return;
            }
            Wait();


            if (Player == 1)
            {
                Wait();

                Coordinate selection = this.Game.GPT.RandomizeSelection();
                State s = Game.Minefield.Squares[selection.X, selection.Y].State;

                //ChangeImageOnState(s, selection);


                // If they click on a mine
                if (s == State.IsAMine)
                {
                    this.RevealAllMines();
                    this.Timer.Stop();
                    MessageBoxResult result = MessageBox.Show("Game over? yes to quit no to retry", "Game Over 😿", MessageBoxButton.YesNo, MessageBoxImage.Hand);
                    if (result == MessageBoxResult.Yes)
                    {
                        this.Exit();
                    }
                    else
                    {
                        this.Restart();
                    }
                }
                else if (s == State.NoMines)
                {
                    this.SearchMines(selection);
                }
                else if (!this.Game.GetRevealed(selection))
                {
                    this.Game.LeftClicks++;
                }

                this.ChangeImageOnState(s, selection);
                if (this.Game.CheckWinCondition())
                {

                    this.Timer.Stop();
                    MessageBox.Show("You win");
                }
            }


            else if (Player == 2)
            {
                // get a coord of 100% or close
                Coordinate i = this.Game.GPT.FindHighestCoordPercent(Game.Minefield.Columns, Game.Minefield.Rows);
                // recursion
                SmartAI(i);
            }
            
        }

        // Couldn't have this in GPT class becuase everything private here. Couldn't recursively change image in GPT class
        // Recursion 
        private void SmartAI(Coordinate coord)
        {
            // Keep variable a when we need to have this be a recursion method (while loops) not done yet
            //int a = 0;

            Coordinate dumby;
            List<Coordinate> dumbylist;
            int percent = this.Game.GPT.MinePercent(coord);
            // opening mines
            int sNum;
            int sFlag;
            int sGrass;
            // flag any surrounding squares
            if (percent == 100)
            {
                //dumbylist = this.Game.GPT.FlagCoords(coord);
                dumby = this.Game.GPT.FlagCoords(coord);
                /*while (dumbylist.Count - 1 == a)
                {
                    // one sec pause
                    this.ChangeImageOnState2(State2.Flag, dumbylist[a]);
                    a++;
                }
                a = 0;*/

                //if (dumbylist.Count >= 1)
                //{
                //ChangeImageOnState2(State2.Question, dumbylist[0]);
                //this.Game.Minefield.Squares[coord.X, coord.Y].Revealed = true;
                ChangeImageOnState2(State2.Question, dumby);
                
                for (int xNum = dumby.X - 1; xNum <= dumby.X + 1; xNum++)
                {
                    for (int yNum = dumby.Y - 1; yNum <= dumby.Y + 1; yNum++)
                    {
                        sNum = this.Game.GPT.GetStateNumber(coord);
                        sFlag = this.Game.GPT.SurroundingFlagged(coord);
                        sGrass = this.Game.GPT.SurroundingGreen(coord);
                        if ((sNum == sFlag && sGrass == 0) && !Game.GPT.RevealedCoords.Contains(coord))
                        {
                            Game.GPT.RevealedCoords.Add(coord);
                        }
                    }
                }




                        //}
                        /*if (dumbylist.Count == 1)
                        {
                            this.Game.GPT.RevealedCoords.Add(coord);
                        }*/
                        //dumbylist.Clear();
                    }

            // dig up any surrounding green squares
            else if (percent == 101)
            {
                // loops until no more green squares (hopefully)
                //dumbylist = this.Game.GPT.UncoverCoords(coord);
                dumby = this.Game.GPT.UncoverCoords(coord);
                /*while (dumbylist.Count > a)
                {
                    State state = this.Game.Minefield.Squares[dumbylist[a].X, dumbylist[a].Y].State;
                    this.ChangeImageOnState(state, dumbylist[a]);
                    this.Game.LeftClicks++;
                    // one sec pause
                    SmartAI(dumbylist[a]);
                    a++;
                }*/
                //State state = this.Game.Minefield.Squares[dumbylist[0].X, dumbylist[0].Y].State;
                //State state = this.Game.Minefield.Squares[dumby.X, dumby.Y].State;
                //this.ChangeImageOnState(state, dumbylist[0]);
                //this.ChangeImageOnState(state, dumby);
                //this.Game.LeftClicks++;
                /*if (dumbylist.Count == 1)
                {
                    this.Game.GPT.RevealedCoords.Add(coord);
                }*/
                //dumbylist.Clear();

                EndGame(dumby);

                




            }

            // pick a random square that we arent sure of
            else
            {
                //for (int i = 0; i == this.Game.GPT.GetStateNumber(coord); i++){
                    //Choosing random numbers to pick
                    Random rand = new Random();
                    int xNum = rand.Next(0, 2);
                    int yNum = rand.Next(0, 2);
                    while (true)
                    {
                        if (this.Game.GPT.PrevChecked(new Coordinate(xNum, yNum)) || !(Game.GPT.CheckInBounds(new Coordinate((coord.X + xNum - 1), (coord.Y + yNum - 1)))))
                        {
                            xNum = rand.Next(0, 2);
                            yNum = rand.Next(0, 2);
                    }
                        else
                        {
                            break;
                        }
                    }

                    dumby = new Coordinate((coord.X + xNum - 1), (coord.Y + yNum - 1));
                EndGame(dumby);
                    

                    
                //}
                
            }
            

            // Adding coords
            sNum = this.Game.GPT.GetStateNumber(coord);
            sFlag = this.Game.GPT.SurroundingFlagged(coord);
            sGrass = this.Game.GPT.SurroundingGreen(coord);
            if ((sNum == sFlag && sGrass == 0) && !Game.GPT.RevealedCoords.Contains(coord))
            {
                Game.GPT.RevealedCoords.Add(coord);
            }
                //win/lose condition


            }

        private bool LuckyChance()
        {
            Random random = new Random();

            // generate a random number between 1 and 10 (inclusive)
            int randomNumber = random.Next(1, 11); 

            if (randomNumber == 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void EndGame(Coordinate coord)
        {
            State state = this.Game.GetSquare(coord).State;

            // If they click on a mine
            if (state == State.IsAMine)
            {
                if (!LuckyChance())
                {
                    this.RevealAllMines();
                    this.Timer.Stop();
                    MessageBoxResult result = MessageBox.Show("Game over? yes to quit no to retry", "Game Over 😿", MessageBoxButton.YesNo, MessageBoxImage.Hand);
                    if (result == MessageBoxResult.Yes)
                    {
                        this.Exit();
                    }
                    else
                    {
                        this.Restart();
                    }
                }
                else
                {
                    MessageBox.Show("You get another chance!");
                }
            }
            else if (state == State.NoMines)
            {
                this.SearchMines(coord);
                //this.Game.GPT.RevealedCoords.Add(new Coordinate(xNum, yNum));
                //SmartAI(this.Game.GPT.FindHighestCoordPercent(Game.Minefield.Columns, Game.Minefield.Rows));
            }
            else if (!this.Game.GetRevealed(coord))
            {
                this.Game.LeftClicks++;
                //this.Game.GPT.RevealedCoords.Add(new Coordinate(xNum, yNum));
                //SmartAI(this.Game.GPT.FindHighestCoordPercent(Game.Minefield.Columns, Game.Minefield.Rows));
            }

            // one sec pause
            this.ChangeImageOnState(state, coord);

            if (this.Game.CheckWinCondition())
            {
                this.Timer.Stop();
                MessageBox.Show("You win");
            }
        }

        /// <summary>
        /// Restart button event
        /// </summary>
        /// <param name="sender">The parameter is not used</param>
        /// <param name="e">The parameter is not used v2</param>
        private void RestartButtonClick(object sender, RoutedEventArgs e)
        {
            this.Restart();
        }

        /// <summary>
        /// Exit button event
        /// </summary>
        /// <param name="sender">The parameter is not used</param>
        /// <param name="e">The parameter is not used v2</param>
        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            this.Exit();
        }

        /// <summary>
        /// restart method
        /// </summary>
        private void Restart()
        {
            Minesweeper minesweeper = new Minesweeper(this.Rows, this.Columns, this.Mines, this.FirstClickSafe, this.Player);
            minesweeper.Show();
            this.Close();
        }

        /// <summary>
        /// exit method
        /// </summary>
        private void Exit()
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        /// <summary>
        /// timer event
        /// </summary>
        /// <param name="sender">The parameter is not used</param>
        /// <param name="e">The parameter is not used v2</param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            this.TenthsOfSecondsElapsed++;
            this.timerText.Text = (this.TenthsOfSecondsElapsed / 1f).ToString("0s");
        }

        /// <summary>
        /// create images for the game board
        /// </summary>
        private void CreateImages()
        {
            this.Images = new Image[this.Game.Columns, this.Game.Rows];
            for (int i = 0; i < this.Game.Columns; i++)
            {
                for (int j = 0; j < this.Game.Rows; j++)
                {
                    Image image = new Image();
                    image.Width = 25;
                    image.Height = 25;
                    BitmapImage bi3 = new BitmapImage();
                    bi3.BeginInit();
                    bi3.UriSource = new Uri("Images/Grass.png", UriKind.Relative);
                    bi3.EndInit();
                    image.Source = bi3;
                    Grid.SetColumn(image, i);
                    Grid.SetRow(image, j);
                    Grid.Children.Add(image);
                    this.Images[i, j] = image;
                }
            }
        }

        /// <summary>
        /// the click event for when the left side of the mouse is clicked while it is positioned above the board
        /// </summary>
        /// <param name="sender"> a sender for something</param>
        /// <param name="e"> the letter e</param>
        private void GridLeftMouseDown(object sender, RoutedEventArgs e)
        {
            if (Player > 0) return;
            Coordinate coordinate = this.GetMouseClickCoordinates(); // Get coordinates of the first 
            if (this.Game.FirstClick)
            {
                // The player already made his first click
                this.Game.FirstClick = false;
                if (this.Game.SafetyNet)
                {
                    this.Game.StartSafeGame(coordinate);
                }
                else
                {
                    this.Game.StartGame();
                }

                this.Timer.Start();
                this.TenthsOfSecondsElapsed = 0;
            }

            State state = this.Game.GetSquare(coordinate).State;
            State2 state2 = this.Game.GetSquare(coordinate).State2;

            if (state2 != State2.Flag)
            {
                EndGame(coordinate);
                /*// If they click on a mine
                if (state == State.IsAMine)
                {
                    this.RevealAllMines();
                    this.Timer.Stop();
                    MessageBoxResult result = MessageBox.Show("Game over? yes to quit no to retry", "Game Over 😿", MessageBoxButton.YesNo, MessageBoxImage.Hand);
                    if (result == MessageBoxResult.Yes)
                    {
                        this.Exit();
                    }
                    else
                    {
                        this.Restart();
                    }
                }
                else if (state == State.NoMines)
                {
                    this.SearchMines(coordinate);
                }
                else if (!this.Game.GetRevealed(coordinate))
                {
                    this.Game.LeftClicks++;
                }

                this.ChangeImageOnState(state, coordinate);
                if (this.Game.CheckWinCondition())
                {
                    this.Timer.Stop();
                    MessageBox.Show("You win");
                }*/
            }
        }

        /// <summary>
        /// the click event for when the user clicks this right side of the mouse while it is above the grid
        /// </summary>
        /// <param name="sender"> a sender for something</param>
        /// <param name="e"> the letter e</param>
        private void GridRightMouseDown(object sender, RoutedEventArgs e)
        {
            if (this.Game.FirstClick)
            {
                return;
            }

            Coordinate coordinate = this.GetMouseClickCoordinates();

            if (this.Game.GetSquare(coordinate).Revealed)
            {
                return;
            }

            State2 state = this.Game.GetSquare(coordinate).State2;

            this.ChangeImageOnState2(state, coordinate);
        }

        /// <summary>
        /// method to reveal all the mines that were randomly placed on the field. 
        /// </summary>
        private void RevealAllMines()
        {
            foreach (Coordinate c in this.Game.GetAllMines())
            {
                this.ChangeImageOnState(State.IsAMine, c);
            }
        }

        /// <summary>
        /// a method to get the coordinates of the mouse cursor when either mouse button is clicked 
        /// </summary>
        /// <returns> returns a instance of the coordinate class which includes the coordinates of the location of the mouse when one of its button were clicked</returns>
        private Coordinate GetMouseClickCoordinates()
        {
            Point mousePosition = Mouse.GetPosition(this.Grid);
            double doubleX = Math.Floor(mousePosition.X);
            double doubleY = Math.Floor(mousePosition.Y);
            int x = Convert.ToInt32(doubleX);
            int y = Convert.ToInt32(doubleY);

            x /= 25;
            y /= 25;
            Coordinate coordinate = new Coordinate(x, y);
            return coordinate;
        }

        /// <summary>
        /// change the image displayed for a square when it is interacted with. 
        /// revealed square images and the empty unrevealed square
        /// </summary>
        /// <param name="s"> the current state of the square</param>
        /// <param name="c"> the coordinates of the square imported into the method</param>
        private void ChangeImageOnState(State s, Coordinate c)
        {
            BitmapImage bi3 = new BitmapImage();

            bi3.BeginInit();
            
            switch (s)
            {
                case State.NoMines:
                    bi3.UriSource = new Uri("Images/Blank.jpg", UriKind.Relative);
                    bi3.EndInit();
                    this.Images[c.X, c.Y].Source = bi3;
                    this.Game.SetRevealed(c, true);
                    break;
                case State.OneMine:
                    bi3.UriSource = new Uri("Images/1.jpg", UriKind.Relative);
                    bi3.EndInit();
                    this.Images[c.X, c.Y].Source = bi3;
                    this.Game.SetRevealed(c, true);
                    break;
                case State.TwoMines:
                    bi3.UriSource = new Uri("Images/2.jpg", UriKind.Relative);
                    bi3.EndInit();
                    this.Images[c.X, c.Y].Source = bi3;
                    this.Game.SetRevealed(c, true);
                    break;
                case State.ThreeMines:
                    bi3.UriSource = new Uri("Images/3.jpg", UriKind.Relative);
                    bi3.EndInit();
                    this.Images[c.X, c.Y].Source = bi3;
                    this.Game.SetRevealed(c, true);
                    break;
                case State.FourMines:
                    bi3.UriSource = new Uri("Images/4.jpg", UriKind.Relative);
                    bi3.EndInit();
                    this.Images[c.X, c.Y].Source = bi3;
                    this.Game.SetRevealed(c, true);
                    break;
                case State.FiveMines:
                    bi3.UriSource = new Uri("Images/5.jpg", UriKind.Relative);
                    bi3.EndInit();
                    this.Images[c.X, c.Y].Source = bi3;
                    this.Game.SetRevealed(c, true);
                    break;
                case State.SixMines:
                    bi3.UriSource = new Uri("Images/6.jpg", UriKind.Relative);
                    bi3.EndInit();
                    this.Images[c.X, c.Y].Source = bi3;
                    this.Game.SetRevealed(c, true);
                    break;
                case State.SevenMines:
                    bi3.UriSource = new Uri("Images/7.jpg", UriKind.Relative);
                    bi3.EndInit();
                    this.Images[c.X, c.Y].Source = bi3;
                    this.Game.SetRevealed(c, true);
                    break;
                case State.EightMines:
                    bi3.UriSource = new Uri("Images/8.jpg", UriKind.Relative);
                    bi3.EndInit();
                    this.Images[c.X, c.Y].Source = bi3;
                    this.Game.SetRevealed(c, true);
                    break;
                case State.IsAMine:
                    bi3.UriSource = new Uri("Images/Bomb.jpg", UriKind.Relative);
                    bi3.EndInit();
                    this.Images[c.X, c.Y].Source = bi3;
                    this.Game.SetRevealed(c, true);
                    break;
            }
        }

        /// <summary>
        /// the different images possible when a block is undiscovered
        /// it also includes the empty unrevealed square image 
        /// </summary>
        /// <param name="s"> the current state of a block</param>
        /// <param name="c"> the current coordinate of the block imported into the method</param>
        private void ChangeImageOnState2(State2 s, Coordinate c)
        {
            BitmapImage bi3 = new BitmapImage();
            
            bi3.BeginInit();
            
            switch (s)
            {
                case State2.Blank:
                    bi3.UriSource = new Uri("Images/Grass_Question.png", UriKind.Relative);
                    bi3.EndInit();
                    this.Images[c.X, c.Y].Source = bi3;
                    this.Game.SetState2(State2.Question, c);
                    break;
                case State2.Question:
                    bi3.UriSource = new Uri("Images/Grass_Flag.png", UriKind.Relative);
                    bi3.EndInit();
                    this.Images[c.X, c.Y].Source = bi3;
                    this.Game.SetState2(State2.Flag, c);
                    break;
                case State2.Flag:
                    bi3.UriSource = new Uri("Images/Grass.png", UriKind.Relative);
                    bi3.EndInit();
                    this.Images[c.X, c.Y].Source = bi3;
                    this.Game.SetState2(State2.Blank, c);
                    break;
            }
        }

        /// <summary>
        /// a method to search for all the mines placed on the the grid/game board
        /// </summary>
        /// <param name="coordinate"> instance of the coordinate class that include the x and y coordinates</param>
        private void SearchMines(Coordinate coordinate)
        {
            if (this.Game.Minefield.IsCoordinateValid(coordinate))
            {
                for (int xNum = coordinate.X - 1; xNum <= coordinate.X + 1; xNum++)
                {
                    for (int yNum = coordinate.Y - 1; yNum <= coordinate.Y + 1; yNum++)
                    {
                        // if outside Minefield area BORDERS!! OR ALREADY REVEALED
                        if (this.Game.Minefield.IsCoordinateValid(new Coordinate(xNum, yNum)))
                        {
                            if (this.Game.Minefield.Squares[xNum, yNum].Revealed != true)
                            {
                                if (this.Game.Minefield.Squares[xNum, yNum].State == State.NoMines)
                                {
                                    this.ChangeImageOnState(State.NoMines, new Coordinate(xNum, yNum));
                                    this.Game.Minefield.Squares[xNum, yNum].Revealed = true;
                                    this.Game.LeftClicks++;
                                    if (Player > 0)
                                    {
                                        this.Game.GPT.RevealedCoords.Add(new Coordinate(xNum, yNum));
                                    }
                                    this.SearchMines(new Coordinate(xNum, yNum));
                                }
                                else
                                {
                                    State state = this.Game.Minefield.Squares[xNum, yNum].State;
                                    this.ChangeImageOnState(state, new Coordinate(xNum, yNum));
                                    this.Game.Minefield.Squares[xNum, yNum].Revealed = true;
                                    this.Game.LeftClicks++;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}