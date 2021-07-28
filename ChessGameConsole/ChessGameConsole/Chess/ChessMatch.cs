using System;
using ChessGameConsole.Chessboard;
using ChessGameConsole.Chessboard.Enums;

namespace ChessGameConsole.Chess
{
    class ChessMatch
    {
        public GameBoard Board { get; private set; }
        private int Turn;
        private Color CurrentPlayer;
        public bool Finished { get; private set; }


        public ChessMatch()
        {
            Board = new GameBoard(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            AddPiece();
        }

        public void PerformMove(Position origin, Position destiny)
        {
            Piece p = Board.RemovePiece(origin);
            p.MovementIncrement();
            Piece CapturedPiece =  Board.RemovePiece(destiny);
            Board.AddPiece(p, destiny);
        }

        private void AddPiece()
        {
            Board.AddPiece(new Tower(Board, Color.White), new ChessPosition('c', 1).ToPosition());
            Board.AddPiece(new Tower(Board, Color.White), new ChessPosition('c', 2).ToPosition());
            Board.AddPiece(new Tower(Board, Color.White), new ChessPosition('d', 2).ToPosition());
            Board.AddPiece(new Tower(Board, Color.White), new ChessPosition('e', 2).ToPosition());
            Board.AddPiece(new Tower(Board, Color.White), new ChessPosition('e', 1).ToPosition());

            Board.AddPiece(new King(Board, Color.White), new ChessPosition('d', 1).ToPosition());

            Board.AddPiece(new Tower(Board, Color.Black), new ChessPosition('c', 7).ToPosition());
            Board.AddPiece(new Tower(Board, Color.Black), new ChessPosition('c', 8).ToPosition());
            Board.AddPiece(new Tower(Board, Color.Black), new ChessPosition('d', 7).ToPosition());
            Board.AddPiece(new Tower(Board, Color.Black), new ChessPosition('e', 7).ToPosition());
            Board.AddPiece(new Tower(Board, Color.Black), new ChessPosition('e', 8).ToPosition());

            Board.AddPiece(new King(Board, Color.Black), new ChessPosition('d', 8).ToPosition());

        }
    }
}
