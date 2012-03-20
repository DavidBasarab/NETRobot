using System.Collections.Generic;
using System.Collections.ObjectModel;
using NETRobots.UI.Common;
using Spikes.ViewModels.Models;

namespace Spikes.ViewModels
{
    // Spiking this idea
    // http://wpf.2000things.com/2011/12/21/455-using-itemcontainerstyle-to-bind-data-elements-in-a-collection-to-a-grid/

    public class MainView : BaseViewModel
    {
        private ObservableCollection<ChessPiece> _chessPieces;
        private string _sampleName;

        public MainView()
        {
            BuildSampleData();
        }

        public string SampleName
        {
            get { return _sampleName; }
            set { SetPropertyValue(ref _sampleName, value); }
        }

        public ObservableCollection<ChessPiece> ChessPieces
        {
            get { return _chessPieces; }
            set { SetPropertyValue(ref _chessPieces, value); }
        }

        protected override void RegisterForMessages() {}

        protected override void SetDesignTimeInfo()
        {
            BuildSampleData();
        }

        private void BuildSampleData()
        {
            SampleName = "Design Time Information";

            var sampleList = new List<ChessPiece>
                                 {
                                     new ChessPiece("QR-Blk", 1, 1),
                                     new ChessPiece("QN-Blk", 1, 2),
                                     new ChessPiece("QB-Blk", 1, 3),
                                     new ChessPiece("Q-Blk", 1, 4),
                                     new ChessPiece("K-Blk", 1, 5),
                                     new ChessPiece("KB-Blk", 1, 6),
                                     new ChessPiece("KN-Blk", 1, 7),
                                     new ChessPiece("KR-Blk", 1, 8),
                                     new ChessPiece("P1-Blk", 2, 1),
                                     new ChessPiece("P2-Blk", 2, 2),
                                     new ChessPiece("P3-Blk", 2, 3),
                                     new ChessPiece("P4-Blk", 2, 4),
                                     new ChessPiece("P5-Blk", 2, 5),
                                     new ChessPiece("P6-Blk", 2, 6),
                                     new ChessPiece("P7-Blk", 2, 7),
                                     new ChessPiece("P8-Blk", 2, 8)
                                 };

            ChessPieces = new ObservableCollection<ChessPiece>(sampleList);
        }
    }
}