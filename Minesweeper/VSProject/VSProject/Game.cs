//----------------------------------------------------------------------
// <copyright file="Game.cs" company="😹👍">
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
    /// The class used to represent the game
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Game
    {

        public Game(int c, int r, int m)
        {
            columns = c;
            rows = r;
            mines = m;
        }
        /// <summary>
        /// true if the player already clicked for the first time, otherwise it is false
        /// </summary>
        public bool FirstClick;

        public bool SafetyNet;

        /// <summary>
        /// minefield object
        /// </summary>
        public Minefield Minefield;

        public int columns;

        public int rows;

        public int mines;

        public bool safeFirstClick;

        public int leftClicks;

        public void StartGame()
        {
            Minefield = new Minefield();
            Minefield.MineCount = mines;
            Minefield.Columns = columns;
            Minefield.Rows = rows;
            Minefield.MinesLeft = mines;
            Minefield.SafeSquares = columns * rows - mines;

            Minefield.CreateSquares();
            Minefield.GenerateMines();
            Minefield.SetStateOfSquares();
        }

        public void StartSafeGame(Coordinate firstClick)
        {
            Minefield = new Minefield();
            Minefield.MineCount = mines;
            Minefield.Columns = columns;
            Minefield.Rows = rows;
            Minefield.MinesLeft = mines;
            Minefield.SafeSquares = columns * rows - mines;

            Minefield.CreateSquares();
            Minefield.SetForbiddenCoordinates(firstClick);
            Minefield.GenerateMines();
            Minefield.SetStateOfSquares();
        }

        public Square GetSquare(Coordinate coordinate)
        {
            Square square = Minefield.Squares[coordinate.X, coordinate.Y];
            return square;
        }

        public void SetRevealed(Coordinate c, bool b)
        {
            Minefield.Squares[c.X, c.Y].Revealed = b;
        }

        public bool GetRevealed(Coordinate c)
        {
            if(Minefield.Squares[c.X, c.Y].Revealed == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetState2(State2 s, Coordinate c)
        {
            Minefield.Squares[c.X, c.Y].State2 = s;
        }

        public List<Coordinate> GetAllMines()
        {
            return Minefield.MineCoords;
        }

        public bool CheckWinCondition()
        {
            if(leftClicks == Minefield.SafeSquares)
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
