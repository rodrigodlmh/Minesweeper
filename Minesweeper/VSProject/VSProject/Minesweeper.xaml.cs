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
    /// Interaction logic for Minesweeper.xaml
    /// </summary>
    public partial class Minesweeper : Window
    {
        /// <summary>
        /// instance of the game class
        /// </summary>
        public Game Game;

        /// <summary>
        /// an array of the number of images/blocks that are going to be in the game board
        /// </summary>
        public Image[,] images;

        /// <summary>
        /// creates an instance of the grid that can be reused for the game 
        /// </summary>
        public Grid grid;

        public Minesweeper(int columns, int rows, int mines, bool FirstClickSafe)
        {
            InitializeComponent();
            this.Width = columns * 25 + 100;
            this.Height = rows * 25 + 100;
            this.Game = new Game(columns, rows, mines);
            this.Game.FirstClick = true;
            this.Game.SafetyNet = FirstClickSafe;

            CreateGrid();
            CreateImages();
        }

        /// <summary>
        /// creates the grid for the game board
        /// </summary>
        private void CreateGrid()
        {
            grid = new Grid();
            grid.Width = this.Game.columns * 25;
            grid.Height = this.Game.rows * 25;
            grid.HorizontalAlignment = HorizontalAlignment.Center;
            grid.VerticalAlignment = VerticalAlignment.Center;
            grid.ShowGridLines = true;
            for (int i = 0; i < this.Game.columns; i++)
            {
                ColumnDefinition cd = new ColumnDefinition();
                grid.ColumnDefinitions.Add(cd);
            }

            for (int i = 0; i < this.Game.rows; i++)
            {
                RowDefinition rd = new RowDefinition();
                grid.RowDefinitions.Add(rd);
            }
            this.Content = grid;
            grid.MouseLeftButtonDown += GridLeftMouseDown;
            grid.MouseRightButtonDown += GridRightMouseDown;
        }

        /// <summary>
        /// create images for the game board
        /// </summary>
        private void CreateImages()
        {
            images = new Image[this.Game.columns, this.Game.rows];
            for (int i = 0; i < this.Game.columns; i++)
            {
                for (int j = 0; j < this.Game.rows; j++)
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
                    grid.Children.Add(image);
                    images[i, j] = image;
                }
            }
        }

        private void GridLeftMouseDown(object sender, RoutedEventArgs e)
        {
            Coordinate coordinate = this.GetMouseClickCoordinates(); // Get coordinates of the first click
            if (this.Game.FirstClick)
            {
                // The player already made his first click
                this.Game.FirstClick = false;
                if(Game.SafetyNet)
                {
                    Game.StartSafeGame(coordinate);
                }
                else
                {
                    Game.StartGame();
                }
            }

            State state = Game.GetSquare(coordinate).State;
            if (state == State.IsAMine)
            {
                RevealAllMines();
                MessageBox.Show("You lost bro");
            }
            else if(Game.GetRevealed(coordinate))
            {
                Game.leftClicks++;
                if(Game.CheckWinCondition())
                {
                    MessageBox.Show("You win");
                }
            }

            if(state == State.NoMines)
            {
                SearchMines(coordinate);
            }

            State2 state2 = Game.GetSquare(coordinate).State2;
            if(state2 == State2.Flag)
            {
                return;
            }

            ChangeImageOnState(state, coordinate);
        }

        private void GridRightMouseDown(object sender, RoutedEventArgs e)
        {
            if(this.Game.FirstClick)
            {
                return;
            }
            Coordinate coordinate = this.GetMouseClickCoordinates();

            if(Game.GetSquare(coordinate).Revealed)
            {
                return;
            }

            State2 state = Game.GetSquare(coordinate).State2;

            ChangeImageOnState2(state, coordinate);
        }

        private void RevealAllMines()
        {
            foreach(Coordinate c in Game.GetAllMines())
            {
                ChangeImageOnState(State.IsAMine, c);
            }
        }


        private Coordinate GetMouseClickCoordinates()
        {
            Point mousePosition = Mouse.GetPosition(grid);
            double doubleX = Math.Floor(mousePosition.X);
            double doubleY = Math.Floor(mousePosition.Y);
            int x = Convert.ToInt32(doubleX);
            int y = Convert.ToInt32(doubleY);

            x /= 25;
            y /= 25;
            Coordinate coordinate = new Coordinate(x, y);
            return coordinate;
        }

        private void ChangeImageOnState(State s, Coordinate c)
        {
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            switch (s)
            {
                case State.NoMines:
                    bi3.UriSource = new Uri("Images/Blank.jpg", UriKind.Relative);
                    bi3.EndInit();
                    images[c.X, c.Y].Source = bi3;
                    Game.SetRevealed(c, true);
                    break;
                case State.OneMine:
                    bi3.UriSource = new Uri("Images/1.jpg", UriKind.Relative);
                    bi3.EndInit();
                    images[c.X, c.Y].Source = bi3;
                    Game.SetRevealed(c, true);
                    break;
                case State.TwoMines:
                    bi3.UriSource = new Uri("Images/2.jpg", UriKind.Relative);
                    bi3.EndInit();
                    images[c.X, c.Y].Source = bi3;
                    Game.SetRevealed(c, true);
                    break;
                case State.ThreeMines:
                    bi3.UriSource = new Uri("Images/3.jpg", UriKind.Relative);
                    bi3.EndInit();
                    images[c.X, c.Y].Source = bi3;
                    Game.SetRevealed(c, true);
                    break;
                case State.FourMines:
                    bi3.UriSource = new Uri("Images/4.jpg", UriKind.Relative);
                    bi3.EndInit();
                    images[c.X, c.Y].Source = bi3;
                    Game.SetRevealed(c, true);
                    break;
                case State.FiveMines:
                    bi3.UriSource = new Uri("Images/5.jpg", UriKind.Relative);
                    bi3.EndInit();
                    images[c.X, c.Y].Source = bi3;
                    Game.SetRevealed(c, true);
                    break;
                case State.SixMines:
                    bi3.UriSource = new Uri("Images/6.jpg", UriKind.Relative);
                    bi3.EndInit();
                    images[c.X, c.Y].Source = bi3;
                    Game.SetRevealed(c, true);
                    break;
                case State.SevenMines:
                    bi3.UriSource = new Uri("Images/7.jpg", UriKind.Relative);
                    bi3.EndInit();
                    images[c.X, c.Y].Source = bi3;
                    Game.SetRevealed(c, true);
                    break;
                case State.EightMines:
                    bi3.UriSource = new Uri("Images/8.jpg", UriKind.Relative);
                    bi3.EndInit();
                    images[c.X, c.Y].Source = bi3;
                    Game.SetRevealed(c, true);
                    break;
                case State.IsAMine:
                    bi3.UriSource = new Uri("Images/Bomb.jpg", UriKind.Relative);
                    bi3.EndInit();
                    images[c.X, c.Y].Source = bi3;
                    Game.SetRevealed(c, true);
                    break;
            }
        }

        private void ChangeImageOnState2(State2 s, Coordinate c)
        {
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            switch (s)
            {
                case State2.Blank:
                    bi3.UriSource = new Uri("Images/Grass_Question.png", UriKind.Relative);
                    bi3.EndInit();
                    images[c.X, c.Y].Source = bi3;
                    Game.SetState2(State2.Question, c);
                    break;
                case State2.Question:
                    bi3.UriSource = new Uri("Images/Grass_Flag.png", UriKind.Relative);
                    bi3.EndInit();
                    images[c.X, c.Y].Source = bi3;
                    Game.SetState2(State2.Flag, c);
                    break;
                case State2.Flag:
                    bi3.UriSource = new Uri("Images/Grass.png", UriKind.Relative);
                    bi3.EndInit();
                    images[c.X, c.Y].Source = bi3;
                    Game.SetState2(State2.Blank, c);
                    break;
            }
        }

        public void SearchMines(Coordinate coordinate)
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
                            // If the value is a blank
                            if (this.Game.Minefield.Squares[xNum, yNum].State == State.NoMines)
                            {
                                ChangeImageOnState(State.NoMines, new Coordinate(xNum, yNum));
                                this.Game.Minefield.Squares[xNum, yNum].Revealed = true;
                                Game.leftClicks++;
                                List<Coordinate> coordinates = this.Game.Minefield.GetSurroundingCoordinates(new Coordinate(xNum, yNum));
                                for (int i = 0; i < 8; i++)
                                {
                                    // Check if outside the Minefield
                                    if (this.Game.Minefield.IsCoordinateValid(coordinates[i]))
                                    {
                                        State state = this.Game.Minefield.Squares[coordinates[i].X, coordinates[i].Y].State;

                                        // not blank because we will check that blank 
                                        if (state != State.IsAMine)
                                        {
                                            this.ChangeImageOnState(state, coordinates[i]);
                                            this.Game.Minefield.Squares[coordinates[i].X, coordinates[i].Y].Revealed = true;
                                            Game.leftClicks++;
                                            if (state == State.NoMines)
                                            {
                                                this.SearchMines(coordinates[i]);
                                            }
                                        }
                                    }
                                }
                            }
                            else if (this.Game.Minefield.IsCoordinateValid(coordinate))
                            {
                                State state = this.Game.Minefield.Squares[xNum, yNum].State;
                                if (state != State.NoMines && state != State.IsAMine)
                                {
                                    this.ChangeImageOnState(state, new Coordinate(xNum, yNum));
                                    this.Game.Minefield.Squares[xNum, yNum].Revealed = true;
                                    Game.leftClicks++;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
