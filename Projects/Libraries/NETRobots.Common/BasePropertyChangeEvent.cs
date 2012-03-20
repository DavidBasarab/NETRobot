using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace NETRobots.Common
{
    public abstract class BasePropertyChangeEvent : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void SetPropertyValue<T>(ref T currentValue, T newValue, Action<T> extraFunction = null, Action voidAfterSetAction = null) where T : class
        {
            if (currentValue == newValue) return;

            currentValue = newValue;

            PropertyHasChanged();

            if (extraFunction != null) extraFunction(newValue);

            if (voidAfterSetAction != null) voidAfterSetAction();
        }

        public virtual void SetPropertyValue<T>(ref T currentValue, T newValue, Action extraFunction) where T : class
        {
            if (currentValue == newValue) return;

            currentValue = newValue;

            PropertyHasChanged();

            if (extraFunction != null) extraFunction();
        }

        public virtual void SetStructPropertyValue<T>(ref T currentValue, T newValue, Action<T> extraFunction = null, Action voidActionAfterSetAction = null)
        {
            currentValue = newValue;

            PropertyHasChanged();

            if (extraFunction != null) extraFunction(newValue);

            if (voidActionAfterSetAction != null) voidActionAfterSetAction();
        }

        public virtual void SetStructPropertyValue<T>(ref T currentValue, T newValue, Action extraFunction)
        {
            currentValue = newValue;

            PropertyHasChanged();

            if (extraFunction != null) extraFunction();
        }

        private void PropertyHasChanged()
        {
            var currentFrame = 2;

            var frame = new StackFrame(currentFrame);

            var propertyName = string.Empty;

            while (!frame.GetMethod().Name.StartsWith("set_"))
            {
                propertyName = frame.GetMethod().Name.Substring(4);

                currentFrame++;

                frame = new StackFrame(currentFrame);
            }

            RaisePropertyChanged(propertyName);
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged == null) return;

            var args = new PropertyChangedEventArgs(propertyName);

            PropertyChanged(this, args);
        }
    }
}
