using System;
using System.Collections.Generic;
using System.Text;

namespace DiagonalChess.Pieces
{
    class PawnBlack : ChessPiece
    {

        public override void OnClick()
        {
            if (!IsOccupied(Row + 1, Column) && Row < 7)
            {
                ChessBoard.Pieces.Add(new DotPiece() { Row = Row + 1, Column = Column, Piece = this, IsBlack = true });
            }
            if (Row == 1 && !IsOccupied(Row + 2, Column))
            {
                ChessBoard.Pieces.Add(new DotPiece() { Row = Row + 2, Column = Column, Piece = this, IsBlack = true });
            }
            if (IsToHit(Row + 1, Column + 1))
            {
                ChessBoard.Pieces.Add(new CirclePiece() { Row = Row + 1, Column = Column + 1, Piece = this, IsBlack = true });
            }
            if (IsToHit(Row + 1, Column - 1))
            {
                ChessBoard.Pieces.Add(new CirclePiece() { Row = Row + 1, Column = Column - 1, Piece = this, IsBlack = true });
            }

        }
    }
}
