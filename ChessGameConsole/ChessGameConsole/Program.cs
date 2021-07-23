using System;
using ChessGameConsole.Chessboard;
using ChessGameConsole.Chess;

namespace ChessGameConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBoard game = new GameBoard(8, 8);

            game.AddPiece(new Tower(game, Chessboard.Enums.Color.Black), new Position(0, 0));

            Screen.PrintGameBoard(game);


        }
    }
}
