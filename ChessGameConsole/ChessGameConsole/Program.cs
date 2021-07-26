using System;
using ChessGameConsole.Chess;
using ChessGameConsole.Chessboard;
using ChessGameConsole.Chessboard.Exceptions;

namespace ChessGameConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                GameBoard game = new GameBoard(8, 8);

                game.AddPiece(new Tower(game, Chessboard.Enums.Color.Black), new Position(0, 0));
                game.AddPiece(new King(game, Chessboard.Enums.Color.Black), new Position(0, 9));

                Screen.PrintGameBoard(game);
            }
            catch(ChessBoardExceptions e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
