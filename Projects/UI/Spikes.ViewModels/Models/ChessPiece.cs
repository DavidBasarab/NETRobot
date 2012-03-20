using NETRobots.Common;

namespace Spikes.ViewModels.Models
{
    public class ChessPiece : BasePropertyChangeEvent
    {
        private int _column;
        private int _row;
        private string _text;

        public ChessPiece(string text, int row, int column)
        {
            Text = text;
            Row = row;
            Column = column;
        }

        public string Text
        {
            get { return _text; }
            set { SetPropertyValue(ref _text, value); }
        }

        public int Row
        {
            get { return _row; }
            set { SetStructPropertyValue(ref _row, value); }
        }

        public int Column
        {
            get { return _column; }
            set { SetStructPropertyValue(ref _column, value); }
        }
    }
}