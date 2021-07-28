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
                ChessPosition pos = new ChessPosition('c', 7);
                Console.WriteLine(pos);
                Console.WriteLine(pos.ToPosition());
                Console.ReadLine();


            }
            catch(ChessBoardExceptions e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
