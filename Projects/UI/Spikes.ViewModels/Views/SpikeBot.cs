using System;
using System.Windows.Media;
using NETRobots.UI.Common;

namespace Spikes.ViewModels.Views
{
    public class SpikeBot : BaseViewModel
    {
        private Brush _botColor;
        private int _left;
        private Random _random;
        private int _top;

        public SpikeBot(SolidColorBrush botColor)
        {
            BotColor = botColor;
        }

        public Brush BotColor
        {
            get { return _botColor; }
            set { SetPropertyValue(ref _botColor, value); }
        }

        public int Left
        {
            get { return _left; }
            set
            {
                SetStructPropertyValue(ref _left, value < 0 ? 0 : value);
            }
        }

        public int Top
        {
            get { return _top; }
            set
            {
                SetStructPropertyValue(ref _top, value > 500 ? 500 : value < 0 ? 0 : value);
            }
        }

        private Random Random
        {
            get { return _random ?? (_random = new Random()); }
        }

        protected override void RegisterForMessages() {}

        protected override void SetDesignTimeInfo() {}

        public void Move()
        {
            Left += Random.Next(100) % 2;// *-1 * (Random.Next(100) % 2);
            Top += Random.Next(100) % 2;// *-1 * (Random.Next(100) % 2);
        }
    }
}