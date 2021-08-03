using ChessGameConsole.Chessboard;
using ChessGameConsole.Chessboard.Enums;

namespace ChessGameConsole.Chess
{
    class King : Piece
    {

        private ChessMatch Match;
        public King(GameBoard gameBoard, Color color, ChessMatch match) : base(color, gameBoard)
        {
            Match = match;
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

        private bool TowerCastleTest(Position pos)
        {
            Piece p = GameBoard.piece(pos);
            return p != null && p is Tower && p.Color == Color && p.MoveCount == 0;
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

            // Jogada especial: Roque 
            if (MoveCount==0 && !Match.Check)
            {
                // Roque Pequeno
                Position tower1 = new Position(Position.Line, Position.Column + 3);
                if (TowerCastleTest(tower1))
                {
                    Position p1 = new Position(Position.Line, Position.Column + 1);
                    Position p2 = new Position(Position.Line, Position.Column + 2);
                    if (GameBoard.piece(p1) == null && GameBoard.piece(p2) == null)
                    {
                        mat[Position.Line, Position.Column + 2] = true;
                    }
                }
                // Roque Grande
                Position tower2 = new Position(Position.Line, Position.Column - 4);
                if (TowerCastleTest(tower2))
                {
                    Position p1 = new Position(Position.Line, Position.Column - 1);
                    Position p2 = new Position(Position.Line, Position.Column - 2);
                    Position p3 = new Position(Position.Line, Position.Column - 3);
                    if (GameBoard.piece(p1) == null && GameBoard.piece(p2) == null && GameBoard.piece(p3) == null)
                    {
                        mat[Position.Line, Position.Column - 2] = true;
                    }
                }
            }


            return mat;
        }
    }
}
