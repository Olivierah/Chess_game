using ChessGameConsole.Chessboard;
using ChessGameConsole.Chessboard.Enums;

namespace ChessGameConsole.Chess
{
    class Queen : Piece
    {
        public Queen(GameBoard gameBoard, Color color) : base(color, gameBoard)
        {
        }

        public override string ToString()
        {
            return "Q";
        }

        private bool CanMove(Position pos)
        {
            Piece p = GameBoard.piece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossiblesMovments()
        {
            bool[,] mat = new bool[GameBoard.Lines, GameBoard.Columns];

            Position pos = new Position(0, 0);

            //Norte
            pos.SetValues(Position.Line - 1, Position.Column);
            while (GameBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (GameBoard.piece(pos) != null && GameBoard.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line - 1;
            }

            //Sul
            pos.SetValues(Position.Line + 1, Position.Column);
            while (GameBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (GameBoard.piece(pos) != null && GameBoard.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line + 1;
            }

            //Leste
            pos.SetValues(Position.Line, Position.Column + 1);
            while (GameBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (GameBoard.piece(pos) != null && GameBoard.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column + 1;
            }

            //Oeste
            pos.SetValues(Position.Line, Position.Column - 1);
            while (GameBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (GameBoard.piece(pos) != null && GameBoard.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column - 1;
            }

            // Nordeste
            pos.SetValues(Position.Line - 1, Position.Column - 1);
            while (GameBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (GameBoard.piece(pos) != null && GameBoard.piece(pos).Color != Color)
                {
                    break;
                }
                pos.SetValues(pos.Line - 1, pos.Column - 1);
            }

            // Sudeste
            pos.SetValues(Position.Line + 1, Position.Column + 1);
            while (GameBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (GameBoard.piece(pos) != null && GameBoard.piece(pos).Color != Color)
                {
                    break;
                }
                pos.SetValues(pos.Line + 1, pos.Column + 1);
            }

            // Sudoeste
            pos.SetValues(Position.Line + 1, Position.Column - 1);
            while (GameBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (GameBoard.piece(pos) != null && GameBoard.piece(pos).Color != Color)
                {
                    break;
                }
                pos.SetValues(pos.Line + 1, pos.Column - 1);
            }

            // Noroeste
            pos.SetValues(Position.Line - 1, Position.Column + 1);
            while (GameBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (GameBoard.piece(pos) != null && GameBoard.piece(pos).Color != Color)
                {
                    break;
                }
                pos.SetValues(pos.Line - 1, pos.Column + 1);
            }
            return mat;
        }
    }
}
