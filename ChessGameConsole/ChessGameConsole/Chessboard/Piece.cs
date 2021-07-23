using ChessGameConsole.Chessboard;
using ChessGameConsole.Chessboard.Enums;

namespace ChessGameConsole.Chessboard
{
    class Piece
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
    }
}
