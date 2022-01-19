using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiagonalChess
{
    class CirclePiece : ChessPiece
    {
        public ChessPiece Piece { get; set; }
        public CirclePiece()
        {
            Type = ChessPieceTypes.Circle;
        }
        public new string ImageSource
        {
            get { return "../Resources/Circle.png"; }
        }

        public override void OnClick()
        {
            ChessBoard.Pieces.Remove(ChessBoard.Pieces.Where(p => p.Row == Row && p.Column == Column).FirstOrDefault());
            Piece.Row = this.Row;
            Piece.Column = this.Column;
            ChessBoard.WhiteTurn = !ChessBoard.WhiteTurn;
        }
    }
}
