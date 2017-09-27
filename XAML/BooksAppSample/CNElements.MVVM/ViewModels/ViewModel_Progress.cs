using CNElements.MVVM.Core;
using System;
using System.Threading;

namespace CNElements.MVVM.ViewModels
{
    public abstract partial class ViewModel : Observable
    {
        internal class StateSetter : IDisposable
        {
            private Action _end;
            public StateSetter(Action start, Action end)
            {
                start?.Invoke();
                _end = end;
            }
            public void Dispose()
            {
                _end?.Invoke();
            }
        }

        protected void SetInProgress(bool set = true)
        {
            if (set)
            {
                Interlocked.Increment(ref _inProgressCounter);
                OnPropertyChanged(nameof(InProgress));
            }
            else
            {
                Interlocked.Decrement(ref _inProgressCounter);
                OnPropertyChanged(nameof(InProgress));
            }
        }

        public IDisposable StartInProgress() =>
            new StateSetter(
                () => SetInProgress(),
                () => SetInProgress(false));

        private int _inProgressCounter = 0;

        public bool InProgress => _inProgressCounter != 0;
    }
}
