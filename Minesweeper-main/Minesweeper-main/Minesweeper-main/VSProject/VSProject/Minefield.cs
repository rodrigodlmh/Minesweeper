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
    class Minefield
    {
        // Variable that holds the amount of rows and columns the grid is going to have on the medium difficulty
        public int Max = 16;

        // Variable that holds the maximum amount of mines for the medium difficulty
        public int MineCount = 40;

        // variable that holds the amount of safe squares to click on on medium difficulty
        public int safeSquares = 216;

        // variable that shows the amount of mines left in the minefield 
        public int minesLeft = 40;

        // List used to store coordinates where mines cannot be placed (the player's first click or places where there's already a mine)
        public List<Coordinate> ForbiddenCoordinates;
        
        // 2d array used to store all squares
        public Square[,] squares;

        // List used to store the locations of all mines
        public List<Coordinate> mineCoords;

        // Random object to generate random numbers
        Random random = new Random();

        // Method that creates all square objects
        public void CreateSquares()
        {
            // Create the 2d array with the size of the grid (16x16)
            this.squares = new Square[this.Max, this.Max];

            // Loop Max (16) times
            for (int i = 0; i < this.Max; i++)
            {
                // Nested Loop (16) times
                for (int j = 0; j < this.Max; j++)
                {
                    // Create objects of square on the 2d array
                    this.squares[i, j] = new Square();

                    // Set the location of the square to a new coordinate object
                    this.squares[i, j].Location = new Coordinate();
                    
                    // Set the x and y components of the coordinate object
                    this.squares[i, j].Location.x = i;
                    this.squares[i, j].Location.y = j;
                }
            }
        }

        // Method to randomly generate all mines
        public void GenerateMines()
        {
            // Create the list that stores the coordinates of all mines
            this.mineCoords = new List<Coordinate>();

            // Loop 40 times
            int i = 0;
            while (i < this.MineCount)
            {
                // Create a new coordinate object
                Coordinate coordinate = new Coordinate();

                // Randomly generate the x and y components of that coordinate
                coordinate.x = this.GenerateRandomNumber();
                coordinate.y = this.GenerateRandomNumber();

                // Bool that stores whether the coordinate generated is forbidden or not
                bool Forbidden = false;

                // Loop through the forbiddenCoordinates to check if the randomly generated coordinate is valid
                foreach (Coordinate coord in this.ForbiddenCoordinates)
                {
                    if ((coordinate.x == coord.x) && (coordinate.y == coord.y))
                    {
                        // Set Forbidden to true
                        Forbidden = true;
                        
                        // Stop checking 
                        break;
                    }
                }

                // If the coordinate is not forbidden
                if (!Forbidden)
                {
                    // Add the coordinates generated to the list of coordinates of mines
                    this.mineCoords.Add(coordinate);

                    // Add the coordinates generated to the forbidden coordinates so that we dont spawn another mine there
                    this.ForbiddenCoordinates.Add(coordinate);
                    
                    // Set the state of the square of thoso coordinates to IsAMine
                    this.squares[coordinate.x, coordinate.y].state = State.IsAMine;
                    
                    // Since we successfully generated a mine, we increment i.
                    i++;
                }
            }
        }

        // Generates random number and returns it
        int GenerateRandomNumber()
        {
            int randomNumber = this.random.Next(0, this.Max - 1);
            return randomNumber;
        }

        public void SetStateOfSquares()
        {
            // List of all squares surrounding all mines
            // (one square might be added more than once depending on how many mines are around it)
            List<Coordinate> mines = new List<Coordinate>();

            // loop through the coordinates of the mine
            foreach (Coordinate coordinate in this.mineCoords)
            {
                // get coordinates of mine
                int x = coordinate.x;
                int y = coordinate.y;

                // get 8 surrounding squares and add them to the list
                mines.Add(new Coordinate(x - 1, y - 1)); // top left
                mines.Add(new Coordinate(x, y - 1)); // top
                mines.Add(new Coordinate(x + 1, y - 1)); // top right
                mines.Add(new Coordinate(x - 1, y)); // left
                mines.Add(new Coordinate(x + 1, y)); // right
                mines.Add(new Coordinate(x - 1, y + 1)); // bottom left
                mines.Add(new Coordinate(x, y + 1)); // bottom
                mines.Add(new Coordinate(x + 1, y + 1)); // bottom right
            }

            // loop through the list of all the squares surrounding all mines
            foreach (Coordinate mine in mines)
            {
                // check if coordinates are valid (are not outside the minefield)
                if (!(mine.x < 0 || mine.x > 15 || mine.y < 0 || mine.y > 15))
                {
                    // Only chenge state of square if it isn't a mine or already has 8 mines around it
                    if (this.squares[mine.x, mine.y].state == State.EightMines)
                    {
                    }
                    else if (this.squares[mine.x, mine.y].state == State.IsAMine)
                    {
                    }
                    else
                    {
                        this.squares[mine.x, mine.y].state++;
                    }
                }
            }
        }

        /// Sets the list of coordinates in which we cant spawn a mine
        public void SetForbiddenCoordinates(Coordinate firstClick)
        {
            // create list
            this.ForbiddenCoordinates = new List<Coordinate>();
            
            // get coordinates of first click
            int x = firstClick.x;
            int y = firstClick.y;
            
            // get all surrounding squares of that coordinate and add them to the list
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

        public List<Coordinate> GetSurroundingCoordinates(Coordinate coordinate)
        {
            int x = coordinate.x;
            int y = coordinate.y;
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

        public bool IsCoordinateValid(Coordinate coordinate)
        {
            if (coordinate.x < this.Max && coordinate.x >= 0 && coordinate.y < this.Max && coordinate.y >= 0)
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
