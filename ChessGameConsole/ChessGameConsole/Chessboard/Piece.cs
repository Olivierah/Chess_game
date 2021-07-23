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

        public Piece(Position position, Color color, int moveCount, GameBoard gameBoard)
        {
            Position = position;
            Color = color;
            MoveCount = 0;
            GameBoard = gameBoard;
        }
    }
}
