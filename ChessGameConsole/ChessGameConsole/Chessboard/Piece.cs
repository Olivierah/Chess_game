using ChessGameConsole.Chessboard;
using ChessGameConsole.Chessboard.Enums;

namespace ChessGameConsole.Chessboard
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int  MoveCount { get; protected set; }
        public GameBoard GameBoard { get; protected set; }

        public Piece()
        {
        }

        public Piece(Color color, GameBoard gameBoard)
        {
            Position = null;
            Color = color;
            GameBoard = gameBoard;
            MoveCount = 0;
        }

        public void MovementIncrement()
        {
            MoveCount++;
        }

        public bool VerifyPossiblesMovments()
        {
            bool[,] mat = PossiblesMovments();
            for (int l=0; l<GameBoard.Lines; l++)
            {
                for(int c=0; c<GameBoard.Columns; c++)
                {
                    if(mat[l, c] == true)
                    {
                        return true;
                    }
                    
                }
            }
            return false;
        }

        public bool CanMoveTo(Position pos)
        {
            return PossiblesMovments()[pos.Line, pos.Column];
        }

        public abstract bool[,] PossiblesMovments();

    }
}
