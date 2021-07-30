using ChessGameConsole.Chessboard;
using ChessGameConsole.Chessboard.Enums;

namespace ChessGameConsole.Chess
{
    class King : Piece
    {
        public King(GameBoard gameBoard, Color color) : base(color, gameBoard)
        {
        }

        public override string ToString()
        {
            return "K";
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

            // Norte
            pos.SetValues(Position.Line - 1, Position.Column);
            if(GameBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // Nordeste
            pos.SetValues(Position.Line - 1, Position.Column + 1);
            if (GameBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // Leste
            pos.SetValues(Position.Line, Position.Column + 1);
            if (GameBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // Sudeste
            pos.SetValues(Position.Line + 1, Position.Column + 1);
            if (GameBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // Sul
            pos.SetValues(Position.Line + 1, Position.Column);
            if (GameBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // Sudoeste
            pos.SetValues(Position.Line + 1, Position.Column - 1);
            if (GameBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // Oeste
            pos.SetValues(Position.Line, Position.Column - 1);
            if (GameBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // Noroeste
            pos.SetValues(Position.Line - 1, Position.Column - 1);
            if (GameBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            return mat;
        }
    }
}
