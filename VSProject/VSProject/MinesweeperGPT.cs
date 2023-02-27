//----------------------------------------------------------------------
// <copyright file="MinesweeperGPT.cs" company="😹👍">
//     copyright  header 
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
    /// the computer player
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class MinesweeperGPT
    {
        /// <summary>
        /// the minefield for the user to interact with to be able to play 
        /// </summary>
        public Minefield GameMinefield;

        /// <summary>
        /// the coordiates that the computer player has already revealed are going to be stored in a list 
        /// </summary>
        public List<Coordinate> RevealedCoords;

        /// <summary>
        /// the coordinate that is being checked/used 
        /// </summary>
        public Coordinate CurrentCoord;

        /// <summary>
        /// the coordinates of the squares surrounding a single square
        /// </sumamry>
        public List<Coordinate> SurroundingCoords;

        /// <summary>
        /// a array of all the flag coordinates the computer player has placed
        /// </summary>
        //private Coordinate[] Flags;


        



        /// <summary>
        /// Initializes a new instance of the <see cref="MinesweeperGPT"/> class 
        /// </summary>
        /// <param name="mf"> the minefield</param>
        public MinesweeperGPT(Minefield mf)
        {
            GameMinefield = mf;
            RevealedCoords = new List<Coordinate>();
        }

        /// <summary>
        /// Gets random coordinate to click
        /// </sumamry>
        /// <param name="coordinate"> chooses a coordinate to pick and interact with</param>
        public Coordinate RandomizeSelection()
        {
            //Runs until lost or won
            bool valid = false;
            while(!valid)    
            {
                Coordinate selection = Coordinate.GetRandomCoordinate(GameMinefield.Columns, GameMinefield.Rows);
                if (GameMinefield.Squares[selection.X, selection.Y].Revealed)
                {
                    valid = false;
                }
                else
                {
                    RevealedCoords.Add(selection);
                    GameMinefield.Squares[selection.X, selection.Y].Revealed = true;
                    return selection;
                }
            }
            return null;
        }

        /// <summary>
        /// takes in a coordinate and checks if that coordinate is in the revealedCoord list
        /// </summary>
        /// <returns> a bool</returns>
        public bool PrevChecked(Coordinate coord)
        {
            return RevealedCoords.Contains(coord);
        }


        //Returns the number of surrounding Green Squares
        public int SurroundingGreen(Coordinate coordinate)
        {
            int gNumber = 0;
            for (int xNum = coordinate.X - 1; xNum <= coordinate.X + 1; xNum++)
            {
                for (int yNum = coordinate.Y - 1; yNum <= coordinate.Y + 1; yNum++)
                {
                    if (CheckInBounds(new Coordinate(xNum, yNum)))
                    {
                        State s = this.GameMinefield.Squares[xNum, yNum].State;
                        if (this.GameMinefield.Squares[xNum, yNum].Revealed != true)
                        {
                            gNumber++;
                        }
                    }
                }
            }
            return gNumber;
        }

        // Returns number of surrounding flagged squares
        public int SurroundingFlagged(Coordinate coordinate)
        {
            int fNumber = 0;
            for (int xNum = coordinate.X - 1; xNum <= coordinate.X + 1; xNum++)
            {
                for (int yNum = coordinate.Y - 1; yNum <= coordinate.Y + 1; yNum++)
                {
                    if (CheckInBounds(new Coordinate(xNum, yNum)) == true)
                    {
                        State2 s = this.GameMinefield.Squares[xNum, yNum].State2;
                        if (this.GameMinefield.Squares[xNum, yNum].Revealed != true)
                        {
                            if (s == State2.Flag)
                            {
                                fNumber++;
                            }
                            if(fNumber == GetStateNumber(coordinate))
                            {
                                break;
                            }
                        }
                    }
                }
            }
            return fNumber;
        }

        // Gets the number square is
        public int GetStateNumber(Coordinate coordinate)
        {
            int sNumber = 0;
            State s = this.GameMinefield.Squares[coordinate.X, coordinate.Y].State;
            switch (s)
            {
                case State.NoMines:
                    sNumber = 0;
                    break;
                case State.OneMine:
                    sNumber = 1;
                    break;
                case State.TwoMines:
                    sNumber = 2;
                    break;
                case State.ThreeMines:
                    sNumber = 3;
                    break;
                case State.FourMines:
                    sNumber = 4;
                    break;
                case State.FiveMines:
                    sNumber = 5;
                    break;
                case State.SixMines:
                    sNumber = 6;
                    break;
                case State.SevenMines:
                    sNumber = 7;
                    break;
                case State.EightMines:
                    sNumber = 8;
                    break;
            }
            return sNumber;

        }

        // gives any coordinates that are green to flag
        public List<Coordinate> FlagCoords(Coordinate coord)
        {
            if (SurroundingCoords != null)
            {
                SurroundingCoords.Clear();
            }
            else
            {
                SurroundingCoords = new List<Coordinate>();
            }
            for (int xNum = coord.X - 1; xNum <= coord.X + 1; xNum++)
            {
                for (int yNum = coord.Y - 1; yNum <= coord.Y + 1; yNum++)
                {
                    if (CheckInBounds(new Coordinate(xNum, yNum)))
                    {
                        if ((GameMinefield.Squares[xNum, yNum].Revealed != true) && !CheckFlagged(new Coordinate(xNum, yNum)) && RevealedCoords.Contains(new Coordinate(xNum, yNum)) == false)
                        {
                            CurrentCoord = new Coordinate(xNum, yNum);
                            SurroundingCoords.Add(CurrentCoord);
                        }
                    }
                }
            }
            return SurroundingCoords;
        }

        // Uncovers any coordinates that are green and recalls the probability method
        public List<Coordinate> UncoverCoords(Coordinate coord)
        {
            if (SurroundingCoords != null)
            {
                SurroundingCoords.Clear();
            }
            else
            {
                SurroundingCoords = new List<Coordinate>();
            }
            for (int xNum = coord.X - 1; xNum <= coord.X + 1; xNum++)
            {
                for (int yNum = coord.Y - 1; yNum <= coord.Y + 1; yNum++)
                {
                    if (CheckInBounds(new Coordinate(xNum, yNum)))
                    {
                        if ((this.GameMinefield.Squares[xNum, yNum].Revealed != true) && !CheckFlagged(new Coordinate(xNum, yNum)))
                        {
                            CurrentCoord = new Coordinate(xNum, yNum);
                            SurroundingCoords.Add(CurrentCoord);
                        }
                    }
                }
            }
            return SurroundingCoords;
        }

        // Checks if the coordinates given are in bounds
        public bool CheckInBounds(Coordinate coord)
        {
            bool In = this.GameMinefield.IsCoordinateValid(coord);
            return In;
        }

        // Check the state2 if the square is flagged or not returns true if yes false no
        public bool CheckFlagged(Coordinate coord)
        {
            bool In = false;
            State2 s = this.GameMinefield.Squares[coord.X, coord.Y].State2;

            if(s == State2.Flag)
            {
                In = true;
            }
            else
            {
                In = false;
            }
            return In;
        }

        // Return the precentage the in which we can deterime the location of mines around it
        public int MinePercent(Coordinate coord)
        {
            int percent = 0;
            List<Coordinate> revealedCoords = RevealedCoords;
            if ((this.GameMinefield.Squares[coord.X, coord.Y].Revealed == true) && (revealedCoords.Contains(coord) == false))
            {
                int sNum = GetStateNumber(coord);
                // If square blank
                if (sNum != 0)
                {
                    int sFlag = SurroundingFlagged(coord);
                    int sGrass = SurroundingGreen(coord);
                    if (!(sFlag == 0 && sGrass == 8)) 
                    {
                        if (!(sNum == sFlag && sGrass == 0))
                        {

                            // If 100% probability OR If grass equals squares
                            if ((sFlag + sGrass == sNum) || (sNum == sGrass))
                            {
                                // Flag all blanks
                                percent = 100;
                                RevealedCoords.Add(coord);
                            }

                            // If flags equal square but there are still grass
                            else if (sNum == sFlag && sGrass > 0)
                            {
                                // uncover all blanks
                                percent = 101;
                                RevealedCoords.Add(coord);
                            }
                            else
                            {
                                percent = getPercent(sNum, sFlag, sGrass);

                            }
                        }
                        else
                        {
                            RevealedCoords.Add(coord);
                        }
                    }
                }
            }
            return percent;
        }

        //when the sGrass divids it automatically converts to zero that why I had to make a method
        public int getPercent(int sNumber, int sFlag, int sGreen)
        {
            double i = sNumber;
            i = i - sFlag;
            i = i / sGreen;
            i = i * 100;

            return (int)i;
        }

        public Coordinate FindHighestCoordPercent(int columns, int rows)
        {
            Coordinate woo = new Coordinate(0, 0);
            int percent = 0;
            int percent2 = 0;

            for (int xNum = 0; xNum < columns; xNum++)
            {
                for (int yNum = 0; yNum < rows; yNum++)
                {
                    // If it isnt in the revealedCoords
                    if (this.GameMinefield.Squares[xNum, yNum].Revealed == true)
                    {
                        if (GetStateNumber(new Coordinate(xNum, yNum)) != 0)
                        {
                            // If not in Revealed Coords
                            List<Coordinate> revealedCoords = RevealedCoords;
                            if (revealedCoords.Contains(new Coordinate(xNum, yNum)) == false)
                            {
                                percent2 = MinePercent(new Coordinate(xNum, yNum));
                                // If 100% sure then we dont need to find a higher one
                                if (percent2 == 100)
                                {
                                    woo = new Coordinate(xNum, yNum);
                                    return woo;
                                }
                                // If the new percent has a higher chance of bomb than other change
                                if (percent2 > percent)
                                {
                                    percent = percent2;
                                    woo = new Coordinate(xNum, yNum);
                                }
                            }
                        }
                    }
                }
            }
            return woo;
        }
    }
}
