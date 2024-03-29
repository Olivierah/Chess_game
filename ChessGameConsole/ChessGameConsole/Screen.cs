﻿using System;
using System.Collections.Generic;
using ChessGameConsole.Chess;
using ChessGameConsole.Chessboard;
using ChessGameConsole.Chessboard.Enums;

namespace ChessGameConsole
{
    class Screen
    {

        public static void PrintMatch(ChessMatch match)
        {
            PrintGameBoard(match.Board);
            Console.WriteLine();
            PrintCapturedPieces(match);
            Console.WriteLine($"\nTurno: {match.Turn}");
            if (!match.Finished)
            {
                Console.WriteLine($"Aguardando jogada: {match.CurrentPlayer}");
                if (match.Check)
                {
                    Console.WriteLine("XEQUE!");
                }
            }
            else
            {
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine($"Vencedor: {match.CurrentPlayer}");
            }
        }

        public static void PrintCapturedPieces(ChessMatch match)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            PrintSet(match.CapturedPieces(Color.White));
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintSet(match.CapturedPieces(Color.Black));
            Console.ForegroundColor = aux;
        }

        public static void PrintSet(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach(Piece x in set)
            {
                Console.Write(x + " ");
            }
            Console.Write("]\n");
        }

        public static void PrintGameBoard(GameBoard game)
        {
            for (int l = 0; l < game.Lines; l++)
            {
                Console.Write(8 - l + " ");
                for (int c = 0; c < game.Columns; c++)
                {
                    PrintPiece(game.piece(l, c));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void PrintGameBoard(GameBoard game, bool[,] possiblesMovments)
        {
            ConsoleColor OriginalBackground = Console.BackgroundColor;
            ConsoleColor AlteredBackground = ConsoleColor.DarkGray;

            for (int l = 0; l < game.Lines; l++)
            {
                Console.Write(8 - l + " ");
                for (int c = 0; c < game.Columns; c++)
                {
                    if (possiblesMovments [l, c])
                    {
                        Console.BackgroundColor = AlteredBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = OriginalBackground;
                    }
                    PrintPiece(game.piece(l, c));
                    Console.BackgroundColor = OriginalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static ChessPosition ReadChessPosition()
        {
            string str = Console.ReadLine();
            char column = str[0];
            int line = int.Parse(str[1] + "");
            return new ChessPosition(column, line);
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write($"- ");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }  
    }
}
