using ChessGameConsole.Chessboard.Exceptions;

namespace ChessGameConsole.Chessboard
{
    class GameBoard
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;

        public GameBoard()
        {
        }

        public GameBoard(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[lines, columns];
        }

        public Piece piece(int lines, int columns)
        {
            return Pieces[lines, columns];
        }

        public Piece piece(Position pos)
        {
            return Pieces[pos.Line, pos.Column];
        }

        public bool PieceCheck(Position pos)
        {
            ValidatePosition(pos);
            return piece(pos) != null;
        }

        public void AddPiece(Piece p, Position pos)
        {
            if (PieceCheck(pos))
            {
                throw new ChessBoardExceptions("Já existe uma peça na posição atual.");
            }
            Pieces[pos.Line, pos.Column] = p;
            p.Position = pos;
        }

        public Piece RemovePiece(Position pos)
        {
            if(piece(pos) == null)
            {
                return null;
            }
            Piece aux = piece(pos);
            aux.Position = null;
            Pieces[pos.Line, pos.Column] = null;
            return aux;
        }

        public bool ValidPosition(Position pos) 
        {
            if (pos.Line < 0 || pos.Line >= Lines || pos.Column < 0 || pos.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position pos)
        {
            if (!ValidPosition(pos))
            {
                throw new ChessBoardExceptions("Posição inválida!");
            }
        }
    }
}
