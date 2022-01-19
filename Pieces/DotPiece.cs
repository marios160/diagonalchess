using System;
using System.Collections.Generic;
using System.Text;

namespace DiagonalChess
{
    class DotPiece : ChessPiece
    {
        public ChessPiece Piece { get; set; }
        public DotPiece()
        {
            Type = ChessPieceTypes.Dot;
        }
        public new string ImageSource
        {
            get { return "../Resources/Dot.png"; }
        }


        public override void OnClick()
        {
            Piece.Row = this.Row;
            Piece.Column = this.Column;
            ChessBoard.WhiteTurn = !ChessBoard.WhiteTurn;
        }
    }
}
