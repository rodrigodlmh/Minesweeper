//----------------------------------------------------------------------
// <copyright file="Square.cs" company="😹👍">
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

    // Reveals how many mines there are around a square or if it is a mine
    enum State
    {
        /// <summary>
        /// 0 represents no mines
        /// </summary>
        NoMines = 0,

        /// <summary>
        /// 1 represents 1 mines
        /// </summary>
        OneMine = 1,

        /// <summary>
        /// 2 represents 2 mines
        /// </summary>
        TwoMines = 2,

        /// <summary>
        /// 3 represents 3 mines
        /// </summary>
        ThreeMines = 3,

        /// <summary>
        /// 4 represents 4 mines
        /// </summary>
        FourMines = 4,

        /// <summary>
        /// 5 represents 5 mines
        /// </summary>
        FiveMines = 5,

        /// <summary>
        /// 6 represents 6 mines
        /// </summary>
        SixMines = 6,

        /// <summary>
        /// 7 represents 7 mines
        /// </summary>
        SevenMines = 7,

        /// <summary>
        /// 8 represents 8 mines
        /// </summary>
        EightMines = 8,

        /// <summary>
        /// 9 represents 9 mines
        /// </summary>
        IsAMine = 9
    }

    // Reveals if the square has a flag or a question mark
    enum State2
    {
        /// <summary>
        /// 0 represents uncovered block
        /// </summary>
        Blank = 0,

        /// <summary>
        /// 1 represents  question mark
        /// </summary>
        Question = 1,

        /// <summary>
        /// 2 represents flagged block
        /// </summary>
        Flag = 2
    }

    /// <summary>
    /// The class used to represent a square
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    class Square
    {
        // state variables
        public State state = State.NoMines;
        public State2 state2 = State2.Blank;

        // Has the player already left-clicked (revealed) the square
        public bool revlealed = false;
        
        // Location of square
        public Coordinate Location;
    }
}
