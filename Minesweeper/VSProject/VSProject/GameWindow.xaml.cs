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
        /// <summary>
        /// sets a timer up
        /// </summary>
        public System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();

        /// <summary>
        /// for use in for loop
        /// </summary>
        public int TenthsOfSecondsElapsed;

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

        /// <summary>
        /// Initializes a new instance of the <see cref="GameWindow"/> class.
        /// </summary>
        public GameWindow()
        {
            this.InitializeComponent();
            this.Timer.Interval = TimeSpan.FromSeconds(1);
            this.Timer.Tick += this.Timer_Tick;
            //this.Game = new Game();
            this.Game.FirstClick = false;
            this.Game.Minefield = new Minefield();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameWindow"/> class.
        /// </summary>
        /// <param name="columns"> the number of columns to create</param>
        /// <param name="rows"> the number of rows to create</param>
        /// <param name="mines"> the number of mines to create and place on the board</param>
        public GameWindow(int columns, int rows, int mines)
        {
            this.InitializeComponent();
            //this.Game = new Game();
            this.Game.FirstClick = false;
            this.Game.Minefield = new Minefield();
            this.Game.Minefield.MineCount = mines;
            this.Game.Minefield.Columns = columns;
            this.Game.Minefield.Rows = rows;

            CreateGrid();
            CreateImages();
        }

        /// <summary>
        /// creates the grid for the game board
        /// </summary>
        private void CreateGrid()
        {
            grid = new Grid();
            grid.Width = this.Game.Minefield.Columns * 25;
            grid.Height = this.Game.Minefield.Rows * 25;
            grid.HorizontalAlignment = HorizontalAlignment.Center;
            grid.VerticalAlignment = VerticalAlignment.Center;
            grid.ShowGridLines = true;
            for (int i = 0; i < this.Game.Minefield.Columns; i++)
            {
                ColumnDefinition cd = new ColumnDefinition();
                grid.ColumnDefinitions.Add(cd);
            }

            for (int i = 0; i < this.Game.Minefield.Rows; i++)
            {
                RowDefinition rd = new RowDefinition();
                grid.RowDefinitions.Add(rd);
            }
            this.Content = grid;
        }
        /// <sumary>
        /// click 
        /// </summary>

        /// <summary>
        /// create images for the game board
        /// </summary>
        private void CreateImages()
        {
            images = new Image[this.Game.Minefield.Rows, this.Game.Minefield.Columns];
            for(int i = 0; i < this.Game.Minefield.Columns; i++)
            {
                for(int j = 0; j < this.Game.Minefield.Rows; j++)
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

     

        /// <summary>
        /// searches mines on board
        /// </summary>
        /// <param name="coordinate"> a coordinate used to search mines</param>
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
                            // if blank or question mark CHECK IF NOT FLAGGED 
                            if (this.Game.Minefield.Squares[xNum, yNum].State2 == State2.Question || this.Game.Minefield.Squares[xNum, yNum].State2 == State2.Blank || this.Game.Minefield.Squares[xNum, yNum].State2 == State2.Flag)
                            {
                                // If the value is a blank
                                if (this.Game.Minefield.Squares[xNum, yNum].State == State.NoMines)
                                {
                                    this.ChangeImage(this.GetImageName(new Coordinate(xNum, yNum)), "Images/Blank.jpg");
                                    this.Game.Minefield.Squares[xNum, yNum].Revealed = true;
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
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Returns back a new image of the square of what the user did 
        /// </summary>
        /// <returns>a instance of the iage class</returns>
        /// <param name="imageName"> the name of the image</param>
        public Image GetImage(string imageName)
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

            return this.Image0_0;
        }

        /// <summary>
        /// makes the timer work by increasing the time by 1 second every second
        /// </summary>
        /// <param name="sender"> a sender</param>
        /// <param name="e"> a letter</param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            this.TenthsOfSecondsElapsed++;
            TimeTextBlock.Text = (this.TenthsOfSecondsElapsed / 1f).ToString("0s");
        }

        /// <summary>
        /// When the user first clicks on the Minefield it will generate the mines and numbers
        /// </summary>
        /// <param name="sender"> a sender</param>
        /// <param name="e"> a letter</param>
        private void ClickButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("bi");
            // If it is the first click the mine field is made with the parameters
            // to make sure to what ever the user clicked on isn't a bomb
            Coordinate coordinate = this.GetMouseClickCoordinates(); // Get coordinates of the first click
            if (!this.Game.FirstClick)
            {
                // The player already made his first click
                this.Game.FirstClick = true;
                if(this.Game.SafetyNet == true)
                {
                    this.Game.Minefield.SetForbiddenCoordinates(coordinate);
                }
                // Set forbidden Squares (where the player clicked)
                this.Game.Minefield.CreateSquares();
                this.Game.Minefield.GenerateMines();
                this.Game.Minefield.SetStateOfSquares();
                this.Timer.Start();
                this.TenthsOfSecondsElapsed = 0;
            }

            // If the user has a flag on the square the user can't "uncover" what benith it
            State2 state2 = this.Game.Minefield.Squares[coordinate.X, coordinate.Y].State2;
            if (state2 == State2.Flag)
            {
                return;
            }

            if (this.Game.Minefield.Squares[coordinate.X, coordinate.Y].Revealed == true)
            {
                return;
            }

            State state = this.Game.Minefield.Squares[coordinate.X, coordinate.Y].State;

            // Shows the image corilating to the board on the square the user left clicked

            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri("Images/Blank.jpg", UriKind.Relative);
            bi3.EndInit();
            images[coordinate.X, coordinate.Y].Source = bi3;

            /*
            this.ChangeImageOnState(state, coordinate);
            if (this.Game.Minefield.Squares[coordinate.X, coordinate.Y].State == State.NoMines)
            {
                this.SearchMines(coordinate);
            }
            */
        }

        /// <summary>
        /// changes the image on the square based on its state
        /// </summary>
        /// <param name="state"> a state</param>
        /// <param name="coordinate"> a coordinate</param>
        private void ChangeImageOnState(State state, Coordinate coordinate)
        {
            string imageName = this.GetImageName(coordinate);
            switch (state)
            {
                case State.NoMines:
                    this.ChangeImage(imageName, "Images/Blank.jpg");
                    this.AfterClickCheck(coordinate);
                    break;
                case State.OneMine:
                    this.ChangeImage(imageName, "Images/1.jpg");
                    this.AfterClickCheck(coordinate);
                    break;
                case State.TwoMines:
                    this.ChangeImage(imageName, "Images/2.jpg");
                    this.AfterClickCheck(coordinate);
                    break;
                case State.ThreeMines:
                    this.ChangeImage(imageName, "Images/3.jpg");
                    this.AfterClickCheck(coordinate);
                    break;
                case State.FourMines:
                    this.ChangeImage(imageName, "Images/4.jpg");
                    this.AfterClickCheck(coordinate);
                    break;
                case State.FiveMines:
                    this.ChangeImage(imageName, "Images/5.jpg");
                    this.AfterClickCheck(coordinate);
                    break;
                case State.SixMines:
                    this.ChangeImage(imageName, "Images/6.jpg");
                    this.AfterClickCheck(coordinate);
                    break;
                case State.SevenMines:
                    this.ChangeImage(imageName, "Images/7.jpg");
                    this.AfterClickCheck(coordinate);
                    break;
                case State.EightMines:
                    this.ChangeImage(imageName, "Images/8.jpg");
                    this.AfterClickCheck(coordinate);
                    break;
                case State.IsAMine:
                    this.ChangeImage(imageName, "Images/Bomb.jpg");
                    this.AfterClickCheck(coordinate);
                    this.ShowMines();
                    this.Timer.Stop();
                    TimeTextBlock.Text = TimeTextBlock.Text + " 😿";

                    // Player loses Gamee
                    MessageBoxResult result = MessageBox.Show("Game over?", "Game Over 😿", MessageBoxButton.YesNo, MessageBoxImage.Hand);
                    if (result == MessageBoxResult.Yes)
                    {
                        this.Quit();
                    }
                    else
                    {
                        this.Restart();
                    }

                    break;
            }
        }

        /// <summary>
        /// When the user right clicks the Minefield
        /// </summary>
        /// <param name="sender"> a sender</param>
        /// <param name="e"> a letter</param>
        private void ClickButton_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!this.Game.FirstClick)
            {
                return;
            }

            Coordinate coordinate = this.GetMouseClickCoordinates();
            State2 state2 = this.Game.Minefield.Squares[coordinate.X, coordinate.Y].State2;
            if (this.Game.Minefield.Squares[coordinate.X, coordinate.Y].Revealed)
            {
                return;
            }

            string imageName = "Image" + coordinate.Y + "_" + coordinate.X;

            // gets what sqaure to show either a flag, question mark or back to blank
            switch (state2)
            {
                case State2.Blank:
                    this.ChangeImage(imageName, "Images/Grass_Question.png");
                    this.Game.Minefield.Squares[coordinate.X, coordinate.Y].State2 = State2.Question;
                    break;
                case State2.Question:
                    this.ChangeImage(imageName, "Images/Grass_Flag.png");
                    this.Game.Minefield.Squares[coordinate.X, coordinate.Y].State2 = State2.Flag;
                    if (this.Game.Minefield.Squares[coordinate.X, coordinate.Y].State == State.IsAMine)
                    {
                        this.Game.Minefield.MinesLeft--;
                        MinesTextBlock.Text = this.Game.Minefield.MinesLeft.ToString();
                    }

                    break;
                case State2.Flag:
                    this.ChangeImage(imageName, "Images/Grass.png");
                    this.Game.Minefield.Squares[coordinate.X, coordinate.Y].State2 = State2.Blank;
                    if (this.Game.Minefield.Squares[coordinate.X, coordinate.Y].State == State.IsAMine)
                    {
                        this.Game.Minefield.MinesLeft++;
                        MinesTextBlock.Text = this.Game.Minefield.MinesLeft.ToString();
                    }

                    break;
            }
        }

        /// <summary>
        /// update the image on the screen
        /// </summary>
        /// <param name="imageName"> name of the image</param>
        /// <param name="source"> source of the image</param>
        private void ChangeImage(string imageName, string source)
        {
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            Image targetImage = this.GetImage(imageName);
            bi3.UriSource = new Uri(source, UriKind.Relative);
            bi3.EndInit();
            targetImage.Source = bi3;
        }

        /// <summary>
        /// Gets the coordinates of where ever the user clicked
        /// </summary>
        /// <returns>coordinates of mouse click</returns>
        private Coordinate GetMouseClickCoordinates()
        {
            Point mousePosition = Mouse.GetPosition(MinefieldGrid);
            double doubleX = Math.Floor(mousePosition.X);
            double doubleY = Math.Floor(mousePosition.Y);
            int x = Convert.ToInt32(doubleX);
            int y = Convert.ToInt32(doubleY);
            Coordinate coordinate = new Coordinate(x, y);

            // Size of each grid square
            coordinate.X = x / 25;

            // Size of each grid square
            coordinate.Y = y / 25;

            return coordinate;
        }

        /// <summary>
        /// shows mines on board
        /// </summary>
        private void ShowMines()
        {
            foreach (Coordinate coord in this.Game.Minefield.MineCoords)
            {
                int x = coord.X;
                int y = coord.Y;
                if (this.Game.Minefield.Squares[x, y].State == State.IsAMine)
                {
                    this.ChangeImage(this.GetImageName(coord), "Images/Bomb.jpg");
                }
            }
        }

        /// <summary>
        /// gets the name of the block on the board
        /// </summary>
        /// <param name="coordinate"> a coordinate</param>
        /// <returns> a string of image name</returns>
        private string GetImageName(Coordinate coordinate)
        {
            string imageName = "Image" + coordinate.Y + "_" + coordinate.X;
            return imageName;
        }

        /// <summary>
        /// checks to see if game has been won
        /// </summary>
        /// <param name="coord"> a coordinate</param>
        private void AfterClickCheck(Coordinate coord)
        {
            if (this.Game.Minefield.Squares[coord.X, coord.Y].Revealed == false)
            {
                this.Game.Minefield.SafeSquares--;
                if (this.Game.Minefield.SafeSquares == 0)
                {
                    MessageBox.Show("you won");
                }
            }

            this.Game.Minefield.Squares[coord.X, coord.Y].Revealed = true;
        }

        /// <summary>
        /// Shows a new game window and closes the previous one
        /// </summary>
        /// <param name="sender"> a sender</param>
        /// <param name="e"> a letter</param>
        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            this.Restart();
        }

        /// <summary>
        /// Closes the game window and opens the main window
        /// </summary>
        /// <param name="sender"> a sender</param>
        /// <param name="e"> a letter</param>
        private void MainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            this.Quit();
        }

        /// <summary>
        /// Creates a new window, opens it and closes the current
        /// </summary>
        private void Restart()
        {
            GameWindow restartWindow = new GameWindow();
            restartWindow.Show();
            this.Close();
        }

        /// <summary>
        /// Creates a new main menu window, opens it and closes the current
        /// </summary>
        private void Quit()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        /// <summary>
        /// disables checkbox if user clicks it 
        /// </summary>
        /// <param name="sender"> a sender</param>
        /// <param name="e"> a letter</param>
        private void ShowMinesCB_Checked(object sender, RoutedEventArgs e)
        {
            if (this.Game.FirstClick)
            {
                this.ShowMines();
                ShowMinesCB.IsEnabled = false;
            }
        }
    }
}
