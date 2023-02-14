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

    /// <summary>
    /// Reveals how many mines there are around a square or if it is a mine
    /// </summary>
    public enum State
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

    /// <summary>
    /// Reveals if the square has a flag or a question mark
    /// </summary>
    public enum State2
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
    public class Square
    {
        /// <summary>
        /// state variable
        /// </summary>
        public State State = State.NoMines;

        /// <summary>
        /// state variable
        /// </summary>
        public State2 State2 = State2.Blank;

        /// <summary>
        /// Has the player already left-clicked (revealed) the square
        /// </summary>
        public bool Revlealed = false;

        /// <summary>
        /// Location of square
        /// </summary>
        public Coordinate Location;
    }
}
