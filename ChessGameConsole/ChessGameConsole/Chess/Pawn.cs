using ChessGameConsole.Chessboard;
using ChessGameConsole.Chessboard.Enums;

namespace ChessGameConsole.Chess
{
    class Pawn : Piece
    {
        private ChessMatch Match;

        public Pawn(GameBoard gameBoard, Color color, ChessMatch match) : base(color, gameBoard)
        {
            Match = match;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool CanMove(Position pos)
        {
            Piece p = GameBoard.piece(pos);
            return p != null && p.Color != Color;
        }

        private bool Free(Position pos)
        {
            return GameBoard.piece(pos) == null;
        }

        public override bool[,] PossiblesMovments()
        {
            bool[,] mat = new bool[GameBoard.Lines, GameBoard.Columns];

            Position pos = new Position(0, 0);

            if(Color == Color.White)
            {
                pos.SetValues(Position.Line - 1, Position.Column);
                if(GameBoard.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetValues(Position.Line - 2, Position.Column);
                if (GameBoard.ValidPosition(pos) && Free(pos) && MoveCount == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetValues(Position.Line - 1, Position.Column - 1);
                if (GameBoard.ValidPosition(pos) && CanMove(pos)) 
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetValues(Position.Line - 1, Position.Column + 1);
                if (GameBoard.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                // Jogada especial En passant
                if(Position.Line == 3)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if(GameBoard.ValidPosition(left) && CanMove(left) && GameBoard.piece(left) == Match.VulnerableEnPassant)
                    {
                        mat[left.Line - 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (GameBoard.ValidPosition(right) && CanMove(right) && GameBoard.piece(right) == Match.VulnerableEnPassant)
                    {
                        mat[right.Line - 1, right.Column] = true;
                    }
                }
            }
            else
            {
                pos.SetValues(Position.Line + 1, Position.Column);
                if (GameBoard.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetValues(Position.Line + 2, Position.Column);
                if (GameBoard.ValidPosition(pos) && Free(pos) && MoveCount == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetValues(Position.Line + 1, Position.Column - 1);
                if (GameBoard.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetValues(Position.Line + 1, Position.Column + 1);
                if (GameBoard.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                // Jogada especial En passant
                if (Position.Line == 4)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (GameBoard.ValidPosition(left) && CanMove(left) && GameBoard.piece(left) == Match.VulnerableEnPassant)
                    {
                        mat[left.Line + 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (GameBoard.ValidPosition(right) && CanMove(right) && GameBoard.piece(right) == Match.VulnerableEnPassant)
                    {
                        mat[right.Line + 1, right.Column] = true;
                    }
                }
            }
            return mat;
        }
    }
}
