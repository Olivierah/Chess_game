using System.Collections.Generic;
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
        private HashSet<Piece> Pieces;
        private HashSet<Piece> Captured;
        public bool Check { get; private set; }


        public ChessMatch()
        {
            Board = new GameBoard(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            Check = false;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            AddPiece();
        }

        public Piece PerformMove(Position origin, Position destiny)
        {
            Piece p = Board.RemovePiece(origin);
            p.MovementIncrement();
            Piece CapturedPiece =  Board.RemovePiece(destiny);
            Board.AddPiece(p, destiny);
            if(CapturedPiece != null)
            {
                Captured.Add(CapturedPiece);
            }
            // Jogada especial Roque Pequeno
            if (p is King && destiny.Column == origin.Column + 2)
            {
                Position towerOrigin = new Position(origin.Line, origin.Column + 3);
                Position towerDestiny = new Position(origin.Line, origin.Column + 1);
                Piece towerPiece = Board.RemovePiece(towerOrigin);
                towerPiece.MovementIncrement();
                Board.AddPiece(towerPiece, towerDestiny);
            }

            // Jogada especial Roque Grande
            if (p is King && destiny.Column == origin.Column - 2)
            {
                Position towerOrigin = new Position(origin.Line, origin.Column - 4);
                Position towerDestiny = new Position(origin.Line, origin.Column - 1);
                Piece towerPiece = Board.RemovePiece(towerOrigin);
                towerPiece.MovementIncrement();
                Board.AddPiece(towerPiece, towerDestiny);
            }

            return CapturedPiece;
        }

        public void Move(Position origin, Position destiny)
        {
            Piece capturedPiece = PerformMove(origin, destiny);

            if (VerifyCheck(CurrentPlayer))
            {
                RollbackMove(origin, destiny, capturedPiece);
                throw new ChessBoardExceptions("Você não pode se colocar em xeque!");
            }

            if (VerifyCheck(Adversary(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

            if (VerifyCheckmate(Adversary(CurrentPlayer)))
            {
                Finished = true;
            }
            else
            {
                Turn++;
                SwapPlayer();
            }
        }

        public void RollbackMove(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece p = Board.RemovePiece(destiny);
            p.MovementDecrement();
            if (capturedPiece != null)
            {
                Board.AddPiece(capturedPiece, destiny);
                Captured.Remove(capturedPiece);
            }
            Board.AddPiece(p, origin);

            // Jogada especial Roque Pequeno
            if (p is King && destiny.Column == origin.Column + 2)
            {
                Position towerOrigin = new Position(origin.Line, origin.Column + 3);
                Position towerDestiny = new Position(origin.Line, origin.Column + 1);
                Piece towerPiece = Board.RemovePiece(towerDestiny);
                towerPiece.MovementDecrement();
                Board.AddPiece(towerPiece, towerOrigin);
            }

            // Jogada especial Roque Grande
            if (p is King && destiny.Column == origin.Column - 2)
            {
                Position towerOrigin = new Position(origin.Line, origin.Column - 4);
                Position towerDestiny = new Position(origin.Line, origin.Column - 1);
                Piece towerPiece = Board.RemovePiece(towerDestiny);
                towerPiece.MovementDecrement();
                Board.AddPiece(towerPiece, towerOrigin);
            }
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

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece x in Captured)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> PieceInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Pieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        private Color Adversary(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece King(Color color)
        {
            foreach(Piece p in PieceInGame(color))
            {
                if (p is King)
                {
                    return p;
                }
            }
            return null;
        }

        public bool VerifyCheck(Color color)
        {
            Piece K = King(color);
            if(K == null)
            {
                throw new ChessBoardExceptions($"O tabuleiro não possui um rei da cor {color}");
            }
            foreach(Piece p in PieceInGame(Adversary(color)))
            {
                bool[,] mat = p.PossiblesMovments();
                if(mat[K.Position.Line, K.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool VerifyCheckmate(Color color)
        {
            if (!VerifyCheck(color))
            {
                return false;
            }
            foreach(Piece p in PieceInGame(color))
            {
                bool[,] mat = p.PossiblesMovments();
                for (int l=0; l<Board.Lines; l++)
                {
                    for(int c=0; c<Board.Columns; c++)
                    {
                        if(mat[l, c])
                        {
                            Position origin = p.Position;
                            Position destiny = new Position(l, c);
                            Piece capturedPiece = PerformMove(origin, destiny);
                            bool testCheck = VerifyCheck(color);
                            RollbackMove(origin, destiny, capturedPiece);
                            if (!testCheck)
                            {
                                return false;
                            }
                        }
                    }
                } 
            }
            return true;
        }


        public void PutNewPiece(char column, int line, Piece piece)
        {
            Board.AddPiece(piece, new ChessPosition(column, line).ToPosition());
            Pieces.Add(piece);
        }

        private void AddPiece()
        {
            PutNewPiece('a', 1, new Tower(Board, Color.White));
            PutNewPiece('b', 1, new Horse(Board, Color.White));
            PutNewPiece('c', 1, new Bishop(Board, Color.White));
            PutNewPiece('d', 1, new Queen(Board, Color.White));
            PutNewPiece('e', 1, new King(Board, Color.White, this));
            PutNewPiece('f', 1, new Bishop(Board, Color.White));
            PutNewPiece('g', 1, new Horse(Board, Color.White));
            PutNewPiece('h', 1, new Tower(Board, Color.White));
            PutNewPiece('a', 2, new Pawn(Board, Color.White));
            PutNewPiece('b', 2, new Pawn(Board, Color.White));
            PutNewPiece('c', 2, new Pawn(Board, Color.White));
            PutNewPiece('d', 2, new Pawn(Board, Color.White));
            PutNewPiece('e', 2, new Pawn(Board, Color.White));
            PutNewPiece('f', 2, new Pawn(Board, Color.White));
            PutNewPiece('g', 2, new Pawn(Board, Color.White));
            PutNewPiece('h', 2, new Pawn(Board, Color.White));


            PutNewPiece('a', 8, new Tower(Board, Color.Black));
            PutNewPiece('b', 8, new Horse(Board, Color.Black));
            PutNewPiece('c', 8, new Bishop(Board, Color.Black));
            PutNewPiece('d', 8, new Queen(Board, Color.Black));
            PutNewPiece('e', 8, new King(Board, Color.Black, this));
            PutNewPiece('f', 8, new Bishop(Board, Color.Black));
            PutNewPiece('g', 8, new Horse(Board, Color.Black));
            PutNewPiece('h', 8, new Tower(Board, Color.Black));
            PutNewPiece('a', 7, new Pawn(Board, Color.Black));
            PutNewPiece('b', 7, new Pawn(Board, Color.Black));
            PutNewPiece('c', 7, new Pawn(Board, Color.Black));
            PutNewPiece('d', 7, new Pawn(Board, Color.Black));
            PutNewPiece('e', 7, new Pawn(Board, Color.Black));
            PutNewPiece('f', 7, new Pawn(Board, Color.Black));
            PutNewPiece('g', 7, new Pawn(Board, Color.Black));
            PutNewPiece('h', 7, new Pawn(Board, Color.Black));

        }
    }
}
