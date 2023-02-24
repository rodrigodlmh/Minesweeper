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
        public List<Coordinate> RevealedCoordinates;

        /// <summary>
        /// the coordinate that is being checked/used 
        /// </summary>
        public Coordinate CurrentCoordinate;

        /// <summary>
        /// the coordinates of the squares surrounding a single square
        /// </sumamry>
        public List<Coordinate> SurroundingCoordinates;

        /// <summary>
        /// a array of all the flag coordinates the computer player has placed
        /// </summary>
        private Coordinate[] Flags;

        /// <summary>
        /// Initializes a new instance of the <see cref="MinesweeperGPT"/> class 
        /// </summary>
        /// <param name="mf"> the minefield</param>
        public MinesweeperGPT(Minefield mf)
        {
            GameMinefield = mf;
            RevealedCoordinates = new List<Coordinate>();
        }

        /// <summary>
        /// Gets random coordinate to click
        /// </sumamry>
        /// <param name="coordinate"> chooses a coordinate to pick and interact with</param>
        public Coordinate RandomizeSelection()
        {
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
                    RevealedCoordinates.Add(selection);
                    GameMinefield.Squares[selection.X, selection.Y].Revealed = true;
                    return selection;
                }
            }
            return null;
        }

        /// <summary>
        /// the selection of how smart the computer player is going to be 
        /// </summary>
        /// <returns> a coordinate</returns>
        public Coordinate SmartSelection()
        {
            return null;
        }

        
        private void Spread(Coordinate coordinate)
        {
        int grassCount = 0;
        int stateNumber;
            /*
            Coordinate A = new coordinate(coordinate.X - 1, coordinate.Y - 1);
            Coordinate B = new coordinate(coordinate.X, coordinate.Y - 1);
            Coordinate C = new coordinate(coordinate.X + 1, coordinate.Y - 1);
            Coordinate D = new coordinate(coordinate.X - 1, coordinate.Y);
            Coordinate E = new coordinate(coordinate.X + 1, coordinate.Y);
            Coordinate F = new coordinate(coordinate.X - 1, coordinate.Y + 1);
            Coordinate G = new coordinate(coordinate.X, coordinate.Y + 1);
            Coordinate H = new coordinate(coordinate.X + 1, coordinate.Y + 1);
            
            
            if (this.GameMinefield.IsCoordinateValid(coordinate))
                {
                    for (int xNum = coordinate.X - 1; xNum <= coordinate.X + 1; xNum++)
                    {
                        for (int yNum = coordinate.Y - 1; yNum <= coordinate.Y + 1; yNum++)
                        {
                            // if outside Minefield area BORDERS!! OR ALREADY REVEALED
                            if (this.GameMinefield.IsCoordinateValid(new Coordinate(xNum, yNum)))
                            {
                                if (this.GameMinefield.Squares[xNum, yNum].Revealed != true)
                                { 
                                    if(surroudingNum(Coordinate coordinate) == stateNum){
                                        try to flag everything around itself
                                        add the coordinates to the list
                                    }
                                    else{
                                        call itself with any surronding numbers
                                    }
                                }
                            }
                        }
                    }
                }*/
            /*
             * method that gets the number of coordinates that isn't revealed returns a number 
             * */

            /*
             * 
             * */
        }

        public int SurroundingNumbers(Coordinate coordinate)
        {
            int number = 0;
            for (int xNum = coordinate.X - 1; xNum <= coordinate.X + 1; xNum++)
            {
                for (int yNum = coordinate.Y - 1; yNum <= coordinate.Y + 1; yNum++)
                {
                    /*State
                    if (this.GameMinefield.Squares[xNum, yNum].Revealed != true || this.Game.Minefield.Squares[xNum, yNum].State2 == State2.Flagged)
                    {
                        
                    }*/
                }
            }
            return number;
        }
    }
}
