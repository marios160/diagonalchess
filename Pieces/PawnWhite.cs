using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DiagonalChess.Pieces
{
    class PawnWhite : ChessPiece
    {
        public override void OnClick()
        {
            if (!IsOccupied(Row - 1, Column) && Row > 0)
            {
                ChessBoard.Pieces.Add(new DotPiece() { Row = Row - 1, Column = Column, Piece = this, IsBlack = false });
            }
            if(Row == 6 && !IsOccupied(Row - 2, Column))
            {
                ChessBoard.Pieces.Add(new DotPiece() { Row = Row - 2, Column = Column, Piece = this, IsBlack = false });
            }
            if (IsToHit(Row - 1, Column + 1))
            {
                ChessBoard.Pieces.Add(new CirclePiece() { Row = Row - 1, Column = Column + 1, Piece = this, IsBlack = false });
            }
            if (IsToHit(Row - 1, Column - 1))
            {
                ChessBoard.Pieces.Add(new CirclePiece() { Row = Row - 1, Column = Column - 1, Piece = this, IsBlack = false });
            }

        }
    }
}
