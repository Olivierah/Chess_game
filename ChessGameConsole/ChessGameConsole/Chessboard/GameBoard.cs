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
    }
}
