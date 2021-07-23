using System;
using ChessGameConsole.Chessboard;

namespace ChessGameConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBoard game = new GameBoard(8, 8);

            Screen.PrintGameBoard(game);


        }
    }
}
