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
        }

        public void SetDot(int x, int y)
        {
            Point point = new Point(x, y);
            int row = Row + point.Y;
            int col = Column + point.X;

            while (!IsOccupied(row, col))
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
            }
            if (IsToHit(row, col))
            {
                ChessBoard.Pieces.Add(new CirclePiece() { Row = row, Column = col, Piece = this, IsBlack = IsBlack });
            }
        }

    }
}
