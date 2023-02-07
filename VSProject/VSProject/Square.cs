using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSProject
{
    // Reveals how many mines there are around a square or if it is a mine
    enum State
    {
        NoMines = 0,
        OneMine = 1, 
        TwoMines = 2,
        ThreeMines = 3,
        FourMines = 4,
        FiveMines = 5,
        SixMines = 6,
        SevenMines = 7,
        EightMines = 8,
        IsAMine = 9
    }
    // Reveals if the square has a flag or a question mark
    enum State2
    {
        Blank = 0,
        Question = 1,
        Flag = 2
    }

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
