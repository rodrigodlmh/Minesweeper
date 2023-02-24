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
        /// <summary>
        /// true if the player already clicked for the first time, otherwise it is false
        /// </summary>
        public bool FirstClick;

        /// <summary> 
        /// determines whether the first click is guaranteed to be safe or not. 
        /// </summary>
        public bool SafetyNet;

        /// <summary>
        /// minefield object
        /// </summary>
        public Minefield Minefield;

        /// <summary>
        /// the computer player 
        /// </summary>
        public MinesweeperGPT GPT;

        /// <summary>
        /// the number of columns that the grid will have
        /// </summary>
        public int Columns;

        /// <summary>
        /// the number of rows that the grid will have
        /// </summary>
        public int Rows;

        /// <summary> 
        /// the number of bombs that the grid will have
        /// </summary>
        public int Mines;

        public int Player;

        /// <summary>
        /// determines if the user will have a guaranteed first click or not. 
        /// </summary>
        public bool SafeFirstClick;

        /// <summary>
        /// counter that goes up 1 every time the user clicks the left button of their mouse 
        /// </summary>
        public int LeftClicks;

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class 
        /// </summary>
        /// <param name="r"> the number of rows to put in the board</param>
        /// <param name="c"> the number of columns to put in the board</param>
        /// <param name="m"> the number of mines to put in the board</param> 
        public Game(int r, int c, int m, int player)
        {
            this.Rows = r;
            this.Columns = c;
            this.Mines = m;
            this.Player = player;
        }

        /// <summary> 
        /// a constructor for the class that sets up the board
        /// </summary>
        public void StartGame()
        {
            this.Minefield = new Minefield();
            this.Minefield.MineCount = this.Mines;
            this.Minefield.Rows = this.Rows;
            this.Minefield.Columns = this.Columns;
            this.Minefield.MinesLeft = this.Mines;
            this.Minefield.SafeSquares = (this.Columns * this.Rows) - this.Mines;

            this.Minefield.CreateSquares();
            this.Minefield.GenerateMines();
            this.Minefield.SetStateOfSquares();
        }

        /// <summary> 
        /// starts s safe version of the game where the first click will always be safe
        /// </summary>
        /// <param name="firstClick"> gets the coordinate of the click click on the game board</param>
        public void StartSafeGame(Coordinate firstClick)
        {
            this.Minefield = new Minefield();
            this.Minefield.MineCount = this.Mines;
            this.Minefield.Rows = this.Rows;
            this.Minefield.Columns = this.Columns;
            this.Minefield.MinesLeft = this.Mines;
            this.Minefield.SafeSquares = (this.Columns * this.Rows) - this.Mines;

            this.Minefield.CreateSquares();
            this.Minefield.SetForbiddenCoordinates(firstClick);
            this.Minefield.GenerateMines();
            this.Minefield.SetStateOfSquares();

            if (Player > 0)
            {
                GPT = new MinesweeperGPT(this.Minefield);
            }
        }

        /// <summary>
        /// gets a specific square out of the game board given the coordinates 
        /// </summary>
        /// <param name="coordinate"> the coordinates given to be able to find the square</param>
        /// <returns> returns the square the user was trying to find and access</returns>
        public Square GetSquare(Coordinate coordinate)
        {
            Square square = this.Minefield.Squares[coordinate.X, coordinate.Y];
            return square;
        }

        /// <summary>
        /// method to change the revealed status of a square
        /// </summary>
        /// <param name="c"> the coordinates of the square that the  revealed status needs to be changed for</param>
        /// <param name="b"> the status that we want the square's revealed status to change to.</param>
        public void SetRevealed(Coordinate c, bool b)
        {
            this.Minefield.Squares[c.X, c.Y].Revealed = b;
        }

        /// <summary>
        /// method to check if a square is revealed or not
        /// </summary>
        /// <param name="c"> the coordinates of the square who we want to check its revealed status.</param>
        /// <returns> return the revealed status of the square/ it can either be true or false</returns>
        public bool GetRevealed(Coordinate c)
        {
            if (this.Minefield.Squares[c.X, c.Y].Revealed == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// change the state/image that a block is displaying 
        /// </summary>
        /// <param name="s"> the state that we want to change the current state of the square to</param>
        /// <param name="c"> the coordinates of the square that we want the state of. </param>
        public void SetState2(State2 s, Coordinate c)
        {
            this.Minefield.Squares[c.X, c.Y].State2 = s;
        }

        /// <summary>
        /// get the coordinates of all the mines on the game grid
        /// </summary>
        /// <returns> a list of all the coordinates in the game board</returns>
        public List<Coordinate> GetAllMines()
        {
            return this.Minefield.MineCoords;
        }

        /// <summary>
        /// checks to see if the user has won the game yet
        /// </summary>
        /// <returns>returns true if the player has won the game otherwise it will return false.</returns>
        public bool CheckWinCondition()
        {
            if (this.LeftClicks == this.Minefield.SafeSquares)
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
