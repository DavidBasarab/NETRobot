using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Input;
using System.Windows.Media;
using GalaSoft.MvvmLight.Command;
using NETRobots.UI.Common;
using Spikes.ViewModels.Views;

namespace Spikes.ViewModels
{
    // Spiking this idea
    // http://wpf.2000things.com/2011/12/21/455-using-itemcontainerstyle-to-bind-data-elements-in-a-collection-to-a-grid/
    // Grid did not work trying Canvas
    // http://www.wpftutorial.net/Canvas.html

    public class MainView : BaseViewModel
    {
        private ObservableCollection<SpikeBot> _bots;
        private int _firstLeft;
        private int _firstTop;
        private string _sampleName;
        private int _secondLeft;
        private int _secondTop;

        public MainView()
        {
            BuildSampleData();
        }

        public ObservableCollection<SpikeBot> Bots
        {
            get { return _bots; }
            set { SetPropertyValue(ref _bots, value); }
        }

        public string SampleName
        {
            get { return _sampleName; }
            set { SetPropertyValue(ref _sampleName, value); }
        }

        public int FirstLeft
        {
            get { return _firstLeft; }
            set { SetStructPropertyValue(ref _firstLeft, value); }
        }

        public int SecondLeft
        {
            get { return _secondLeft; }
            set { SetStructPropertyValue(ref _secondLeft, value); }
        }

        public int FirstTop
        {
            get { return _firstTop; }
            set { SetStructPropertyValue(ref _firstTop, value); }
        }

        public int SecondTop
        {
            get { return _secondTop; }
            set { SetStructPropertyValue(ref _secondTop, value); }
        }

        public ICommand StartSim { get; set; }

        protected override void RegisterForMessages()
        {
            StartSim = new RelayCommand(OnStartSim);
        }

        protected override void SetDesignTimeInfo()
        {
            SampleName = "Design TIME!!!";

            FirstLeft = 75;
            FirstTop = 120;

            SecondLeft = 10;
            SecondTop = 8;
        }

        private void BuildSampleData()
        {
            SampleName = "Design Time Information";

            var bots = new List<SpikeBot> {new SpikeBot(Brushes.Green), new SpikeBot(Brushes.Blue)};

            Bots = new ObservableCollection<SpikeBot>(bots);
        }

        private void OnStartSim()
        {
            Action simProcess = ProcessSimulation;

            simProcess.BeginInvoke(null, null);
        }

        private void ProcessSimulation()
        {
            for (var i = 0; i < 1000; i++)
            {
                Thread.Sleep(100);

                foreach (var spikeBot in Bots) spikeBot.Move();
            }
        }
    }
}