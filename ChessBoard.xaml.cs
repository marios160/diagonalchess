using DiagonalChess.Pieces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiagonalChess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ChessBoard : Window
    {
        private const int RowCount = 8;
        private const int ColCount = 8;
        public static bool WhiteTurn = true;

        public static ObservableCollection<ChessPiece> Pieces { get; set; }
        public ChessBoard()
        {
            Pieces = new ObservableCollection<ChessPiece>();
            InitializeComponent();
            DataContext = Pieces;
            CreateBoard();
            NewGame();

        }
        private void CreateBoard()
        {
            for (var row = 0; row < RowCount; row++)
            {
                var isBlack = row % 2 == 1;
                for (int col = 0; col < ColCount; col++)
                {
                    var square = new Rectangle { Fill = isBlack ? Brushes.Black : Brushes.White };
                    SquaresGrid.Children.Add(square);
                    isBlack = !isBlack;
                }
            }
        }

        private void Square_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ChessPiece piece = (e.Source as Image).DataContext as ChessPiece;
            if((WhiteTurn && piece.IsBlack) || (!WhiteTurn && !piece.IsBlack))
            {
                return;
            }
            foreach (ChessPiece item in Pieces.ToList())
            {
                if (item.Type == ChessPieceTypes.Dot)
                    Pieces.Remove(item);
                else if (item.Type == ChessPieceTypes.Circle)
                    Pieces.Remove(item);
            }
            piece.OnClick();

        }

        private void NewGame()
        {
            //Pieces.Add(new ChessPiece() { Row = 0, Column = 0, Type = ChessPieceTypes.Tower, IsBlack = true });
            //Pieces.Add(new ChessPiece() { Row = 0, Column = 1, Type = ChessPieceTypes.Knight, IsBlack = true });
            Pieces.Add(new Bishop() { Row = 0, Column = 2, Type = ChessPieceTypes.Bishop, IsBlack = true });
            //Pieces.Add(new ChessPiece() { Row = 0, Column = 3, Type = ChessPieceTypes.Queen, IsBlack = true });
            //Pieces.Add(new ChessPiece() { Row = 0, Column = 4, Type = ChessPieceTypes.King, IsBlack = true });
            Pieces.Add(new Bishop() { Row = 0, Column = 5, Type = ChessPieceTypes.Bishop, IsBlack = true });
            //Pieces.Add(new ChessPiece() { Row = 0, Column = 6, Type = ChessPieceTypes.Knight, IsBlack = true });
            //Pieces.Add(new ChessPiece() { Row = 0, Column = 7, Type = ChessPieceTypes.Tower, IsBlack = true });

            Enumerable
                .Range(0, 8)
                .Select(x => new PawnBlack()
                {
                    Row = 1,
                    Column = x,
                    IsBlack = true,
                    Type = ChessPieceTypes.Pawn
                })
                .ToList()
                .ForEach(Pieces.Add);

            //Pieces.Add(new ChessPiece() { Row = 7, Column = 0, Type = ChessPieceTypes.Tower, IsBlack = false });
            //Pieces.Add(new ChessPiece() { Row = 7, Column = 1, Type = ChessPieceTypes.Knight, IsBlack = false });
            Pieces.Add(new Bishop() { Row = 7, Column = 2, Type = ChessPieceTypes.Bishop, IsBlack = false });
            //Pieces.Add(new ChessPiece() { Row = 7, Column = 3, Type = ChessPieceTypes.Queen, IsBlack = false });
            //Pieces.Add(new ChessPiece() { Row = 7, Column = 4, Type = ChessPieceTypes.King, IsBlack = false });
            Pieces.Add(new  Bishop() { Row = 7, Column = 5, Type = ChessPieceTypes.Bishop, IsBlack = false });
            //Pieces.Add(new ChessPiece() { Row = 7, Column = 6, Type = ChessPieceTypes.Knight, IsBlack = false });
            //Pieces.Add(new ChessPiece() { Row = 7, Column = 7, Type = ChessPieceTypes.Tower, IsBlack = false });

            Enumerable.Range(0, 8).Select(x => new PawnWhite()
            {
                Row = 6,
                Column = x,
                IsBlack = false,
                Type = ChessPieceTypes.Pawn
            }).ToList().ForEach(Pieces.Add);

        }
    }
}
