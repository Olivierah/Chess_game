using ChessGameConsole.Chessboard;

namespace ChessGameConsole
{
    class Screen
    {
        public static void PrintGameBoard(GameBoard game)
        {
            for (int l = 0; l < game.Lines; l++)
            {
                for (int c = 0; c < game.Columns; c++)
                {
                    if(game.piece(l,c) == null)
                    {
                        System.Console.Write($"- ");
                    }
                    else
                    {
                        System.Console.Write($"{game.piece(l, c)} ");
                    }
                }
                System.Console.WriteLine();
            }

        }
    }
}
