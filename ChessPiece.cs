using DiagonalChess.Pieces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace DiagonalChess
{
    public abstract class ChessPiece : INotifyPropertyChanged
    {
        public bool IsBlack { get; set; }

        public ChessPieceTypes Type { get; set; }

        private int _row;
        public int Row
        {
            get { return _row; }
            set
            {
                _row = value;
                OnPropertyChanged("Row");
            }
        }

        private int _column;
        public int Column
        {
            get { return _column; }
            set
            {
                _column = value;
                OnPropertyChanged("Column");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public string ImageSource
        {
            get { return "../Resources/" + (IsBlack ? "Black" : "White") + Type.ToString() + ".png"; }
        }

        public bool IsOccupied(int row, int col)
        {
            if (ChessBoard.Pieces.Where(p => p.Row == row && p.Column == col && p.Type != ChessPieceTypes.Dot).Count() == 0)
                return false;
            return true;
        }

        public bool IsToHit(int row, int col)
        {
            if(IsOccupied(row,col))
                if (ChessBoard.Pieces.Where(p => p.Row == row && p.Column == col).FirstOrDefault().IsBlack != IsBlack)
                    return true;
            return false;
        }

        public abstract void OnClick();



    }
}
