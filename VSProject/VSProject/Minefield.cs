//----------------------------------------------------------------------
// <copyright file="Minefield.cs" company="😹👍">
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

    /// <summary>
    /// The class used to generate the minefield 
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Minefield
    {
        /// <summary>
        /// Variable that holds the amount of rows and columns the grid is going to have on the medium difficulty
        /// </summary>
        public int Max = 16;

        /// <summary>
        /// Variable that holds the maximum amount of mines for the medium difficulty
        /// </summary>
        public int MineCount = 40;

        /// <summary>
        /// variable that holds the amount of safe Squares to click on on medium difficulty
        /// </summary>
        public int SafeSquares = 216;

        /// <summary>
        /// variable that shows the amount of mines left in the minefield 
        /// </summary>
        public int MinesLeft = 40;

        /// <summary>
        /// List used to store coordinates where mines cannot be placed (the player's first click or places where there's already a mine)
        /// </summary>
        public List<Coordinate> ForbiddenCoordinates;

        /// <summary>
        /// 2d array used to store all Squares
        /// </summary>
        public Square[,] Squares;

        /// <summary>
        /// List used to store the locations of all mines
        /// </summary>
        public List<Coordinate> MineCoords;

        /// <summary>
        ///  Random object to generate random numbers
        /// </summary>
        public Random Random = new Random();

        /// <summary>
        ///  Method that creates all square objects
        /// </summary>
        public void CreateSquares()
        {
            // Create the 2d array with the size of the grid (16x16)
            this.Squares = new Square[this.Max, this.Max];

            // Loop Max (16) times
            for (int i = 0; i < this.Max; i++)
            {
                // Nested Loop (16) times
                for (int j = 0; j < this.Max; j++)
                {
                    // Create objects of square on the 2d array
                    this.Squares[i, j] = new Square();

                    // Set the location of the square to a new coordinate object
                    this.Squares[i, j].Location = new Coordinate();
                    
                    // Set the X and Y components of the coordinate object
                    this.Squares[i, j].Location.X = i;
                    this.Squares[i, j].Location.Y = j;
                }
            }
        }

        /// <summary>
        /// Method to randomly generate all mines
        /// </summary>
        public void GenerateMines()
        {
            // Create the list that stores the coordinates of all mines
            this.MineCoords = new List<Coordinate>();

            // Loop 40 times
            int i = 0;
            while (i < this.MineCount)
            {
                // Create a new coordinate object
                Coordinate coordinate = new Coordinate();

                // Randomly generate the X and Y components of that coordinate
                coordinate.X = this.GenerateRandomNumber();
                coordinate.Y = this.GenerateRandomNumber();

                // Bool that stores whether the coordinate generated is forbidden or not
                bool forbidden = false;

                // Loop through the forbiddenCoordinates to check if the randomly generated coordinate is valid
                foreach (Coordinate coord in this.ForbiddenCoordinates)
                {
                    if ((coordinate.X == coord.X) && (coordinate.Y == coord.Y))
                    {
                        // Set Forbidden to true
                        forbidden = true;
                        
                        // Stop checking 
                        break;
                    }
                }

                // If the coordinate is not forbidden
                if (!forbidden)
                {
                    // Add the coordinates generated to the list of coordinates of mines
                    this.MineCoords.Add(coordinate);

                    // Add the coordinates generated to the forbidden coordinates so that we dont spawn another mine there
                    this.ForbiddenCoordinates.Add(coordinate);
                    
                    // Set the state of the square of thoso coordinates to IsAMine
                    this.Squares[coordinate.X, coordinate.Y].State = State.IsAMine;
                    
                    // Since we successfully generated a mine, we increment i.
                    i++;
                }
            }
        }

        /// <summary>
        /// Generates random number and returns it
        /// </summary>
        /// <returns> a integer value</returns>
        public int GenerateRandomNumber()
        {
            int randomNumber = this.Random.Next(0, this.Max - 1);
            return randomNumber;
        }

        /// <summary>
        /// Set State Of Squares
        /// </summary>
        public void SetStateOfSquares()
        {
            // List of all Squares surrounding all mines
            // (one square might be added more than once depending on how many mines are around it)
            List<Coordinate> mines = new List<Coordinate>();

            // loop through the coordinates of the mine
            foreach (Coordinate coordinate in this.MineCoords)
            {
                // get coordinates of mine
                int x = coordinate.X;
                int y = coordinate.Y;

                // get 8 surrounding Squares and add them to the list
                mines.Add(new Coordinate(x - 1, y - 1)); // top left
                mines.Add(new Coordinate(x, y - 1)); // top
                mines.Add(new Coordinate(x + 1, y - 1)); // top right
                mines.Add(new Coordinate(x - 1, y)); // left
                mines.Add(new Coordinate(x + 1, y)); // right
                mines.Add(new Coordinate(x - 1, y + 1)); // bottom left
                mines.Add(new Coordinate(x, y + 1)); // bottom
                mines.Add(new Coordinate(x + 1, y + 1)); // bottom right
            }

            // loop through the list of all the Squares surrounding all mines
            foreach (Coordinate mine in mines)
            {
                // check if coordinates are valid (are not outside the minefield)
                if (!(mine.X < 0 || mine.X > 15 || mine.Y < 0 || mine.Y > 15))
                {
                    // Only chenge state of square if it isn't a mine or already has 8 mines around it
                    if (this.Squares[mine.X, mine.Y].State == State.EightMines)
                    {
                    }
                    else if (this.Squares[mine.X, mine.Y].State == State.IsAMine)
                    {
                    }
                    else
                    {
                        this.Squares[mine.X, mine.Y].State++;
                    }
                }
            }
        }

        /// <summary>
        /// Sets the list of coordinates in which we cant spawn a mine
        /// </summary>
        /// <param name="firstClick"> the first click</param>
        public void SetForbiddenCoordinates(Coordinate firstClick)
        {
            // create list
            this.ForbiddenCoordinates = new List<Coordinate>();
            
            // get coordinates of first click
            int x = firstClick.X;
            int y = firstClick.Y;
            
            // get all surrounding Squares of that coordinate and add them to the list
            this.ForbiddenCoordinates.Add(new Coordinate(x - 1, y - 1)); // top left
            this.ForbiddenCoordinates.Add(new Coordinate(x, y - 1)); // top
            this.ForbiddenCoordinates.Add(new Coordinate(x + 1, y - 1)); // top right
            this.ForbiddenCoordinates.Add(new Coordinate(x - 1, y)); // left
            this.ForbiddenCoordinates.Add(new Coordinate(x + 1, y)); // right
            this.ForbiddenCoordinates.Add(new Coordinate(x - 1, y + 1)); // bottom left
            this.ForbiddenCoordinates.Add(new Coordinate(x, y + 1)); // bottom
            this.ForbiddenCoordinates.Add(new Coordinate(x + 1, y + 1)); // bottom right
            this.ForbiddenCoordinates.Add(firstClick);
        }

        /// <summary>
        /// get coordinates around a square
        /// </summary>
        /// <param name="coordinate"> a coordinate</param>
        /// <returns>A list of coordinates</returns>
        public List<Coordinate> GetSurroundingCoordinates(Coordinate coordinate)
        {
            int x = coordinate.X;
            int y = coordinate.Y;
            List<Coordinate> coordinates = new List<Coordinate>();

            coordinates.Add(new Coordinate(x - 1, y - 1)); // top left
            coordinates.Add(new Coordinate(x, y - 1)); // top
            coordinates.Add(new Coordinate(x + 1, y - 1)); // top right
            coordinates.Add(new Coordinate(x - 1, y)); // left
            coordinates.Add(new Coordinate(x + 1, y)); // right
            coordinates.Add(new Coordinate(x - 1, y + 1)); // bottom left
            coordinates.Add(new Coordinate(x, y + 1)); // bottom
            coordinates.Add(new Coordinate(x + 1, y + 1)); // bottom right
            return coordinates;
        }

        /// <summary>
        /// checks if coordinate is valid
        /// </summary>
        /// <param name="coordinate"> a coordinate</param>
        /// <returns>A boolean</returns>
        public bool IsCoordinateValid(Coordinate coordinate)
        {
            if (coordinate.X < this.Max && coordinate.X >= 0 && coordinate.Y < this.Max && coordinate.Y >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
