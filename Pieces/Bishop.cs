using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;


namespace DiagonalChess.Pieces
{
    class Bishop : ChessPiece
    {
        public override void OnClick()
        {


            SetDot(1, -1);
            SetDot(-1, 1);
            SetDot(1, 1);
            SetDot(-1, -1);


            //if (!IsOccupied(Row - 1, Column) && Row > 0)
            //{
            //    ChessBoard.Pieces.Add(new DotPiece() { Row = Row - 1, Column = Column, Piece = this, IsBlack = false });
            //}
            //if(Row == 6 && !IsOccupied(Row - 2, Column))
            //{
            //    ChessBoard.Pieces.Add(new DotPiece() { Row = Row - 2, Column = Column, Piece = this, IsBlack = false });
            //}
            //if (IsToHit(Row - 1, Column + 1))
            //{
            //    ChessBoard.Pieces.Add(new CirclePiece() { Row = Row - 1, Column = Column + 1, Piece = this, IsBlack = false });
            //}
            //if (IsToHit(Row - 1, Column - 1))
            //{
            //    ChessBoard.Pieces.Add(new CirclePiece() { Row = Row - 1, Column = Column - 1, Piece = this, IsBlack = false });
            //}

        }

        public void SetDot(int x, int y)
        {
            Point point = new Point(x, y);
            int row = Row + point.Y;
            int col = Column + point.X;

            do
            {
                if (col > 7)
                {
                    point.X = -1;
                    col -= 2;
                    continue;
                }
                if (row < 0)
                {
                    point.Y = 1;
                    row += 2;
                    continue;
                }
                if (col < 0)
                {
                    point.X = 1;
                    col += 2;
                    continue;
                }
                if (row > 7)
                {
                    point.Y = -1;
                    row -= 2;
                    continue;
                }

                ChessBoard.Pieces.Add(new DotPiece() { Row = row, Column = col, Piece = this, IsBlack = IsBlack });
                row += point.Y;
                col += point.X;
            } while (!IsOccupied(row, col));
        }

    }
}
