using System;
using ChessGameConsole.Chessboard;
using ChessGameConsole.Chessboard.Enums;

namespace ChessGameConsole
{
    class Screen
    {
        public static void PrintGameBoard(GameBoard game)
        {
            for (int l = 0; l < game.Lines; l++)
            {
                System.Console.Write(8 - l + " ");
                for (int c = 0; c < game.Columns; c++)
                {
                    if(game.piece(l,c) == null)
                    {
                        System.Console.Write($"- ");
                    }
                    else
                    {
                       PrintPiece(game.piece(l,c));
                       Console.Write(" ");
                    }
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine("  A B C D E F G H");
        }

        public static void PrintPiece(Piece piece)
        {
            if(piece.Color == Color.White)
            {
                System.Console.Write(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }
    }
}
