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
                    try
                    {
                        Console.Clear();
                        Screen.PrintMatch(match);

                        Console.Write("\nOrigem: ");
                        Position origin = Screen.ReadChessPosition().ToPosition();
                        match.ValidateOrigin(origin);

                        bool[,] possiblesMovments = match.Board.piece(origin).PossiblesMovments();

                        Console.Clear();
                        Screen.PrintGameBoard(match.Board, possiblesMovments);

                        Console.Write("\nDestino: ");
                        Position destiny = Screen.ReadChessPosition().ToPosition();
                        match.ValidateDestiny(origin, destiny);

                        match.Move(origin, destiny);
                    }
                    catch(ChessBoardExceptions e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Screen.PrintGameBoard(match.Board);

            }
            catch(ChessBoardExceptions e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
