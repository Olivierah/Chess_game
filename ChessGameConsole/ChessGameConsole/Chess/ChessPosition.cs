﻿using ChessGameConsole.Chessboard;

namespace ChessGameConsole.Chess
{
    class ChessPosition
    {
        public char Column { get; set; }
        public int Line { get; set; }

        public ChessPosition()
        {
        }

        public ChessPosition(char column, int line)
        {
            Column = column;
            Line = line;
        }

        public Position ToPosition()
        {
            return new Position(8 - Line, Column - 'a');
        }

        public override string ToString()
        {
            return ""
                + Column
                + Line;
        }
    }
}
