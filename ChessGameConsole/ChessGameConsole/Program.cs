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
                ChessMatch match = new ChessMatch();

                while (!match.Finished)
                {
                    Console.Clear();
                    Screen.PrintGameBoard(match.Board);

                    Console.Write("\nOrigem: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();
                    Console.Write("Destiny: ");
                    Position destiny = Screen.ReadChessPosition().ToPosition();

                    match.PerformMove(origin, destiny);
                }
                
                Screen.PrintGameBoard(match.Board);

            }
            catch(ChessBoardExceptions e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
