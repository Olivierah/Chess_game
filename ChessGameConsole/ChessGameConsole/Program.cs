using System;
using ChessGameConsole.Chess;
using ChessGameConsole.Chessboard;
using ChessGameConsole.Chessboard.Enums;
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

                game.AddPiece(new Tower(game, Color.Black), new Position(0, 0));
                game.AddPiece(new Tower(game, Color.Black), new Position(1, 3));
                game.AddPiece(new King(game, Color.Black), new Position(0, 2));

                game.AddPiece(new Tower(game, Color.White), new Position(3, 5));

                Screen.PrintGameBoard(game);

            }
            catch(ChessBoardExceptions e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
