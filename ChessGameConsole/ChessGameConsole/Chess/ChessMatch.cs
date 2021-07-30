using System;
using ChessGameConsole.Chessboard;
using ChessGameConsole.Chessboard.Enums;
using ChessGameConsole.Chessboard.Exceptions;

namespace ChessGameConsole.Chess
{
    class ChessMatch
    {
        public GameBoard Board { get; private set; }
        public int Turn { get; private set; }
        public  Color CurrentPlayer { get; private set; }
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

        public void Move(Position origin, Position destiny)
        {
            PerformMove(origin, destiny);
            Turn++;
            SwapPlayer();
        }

        public void ValidateOrigin(Position pos)
        {
            if(Board.piece(pos) == null)
            {
                throw new ChessBoardExceptions("Não existe peça na posição selecionada.");
            }
            if(CurrentPlayer != Board.piece(pos).Color)
            {
                throw new ChessBoardExceptions("A Peça selecionada não pertence a você.");
            }
            if (!Board.piece(pos).VerifyPossiblesMovments())
            {
                throw new ChessBoardExceptions("Não há movimentos possíveis para a peça selecionada");
            }
        }

        public void ValidateDestiny(Position origin, Position destiny)
        {
            if (!Board.piece(origin).CanMoveTo(destiny))
            {
                throw new ChessBoardExceptions("Posição de destino inválida!");
            }
        }

        private void SwapPlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
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
