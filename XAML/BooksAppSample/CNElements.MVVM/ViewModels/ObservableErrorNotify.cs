using CNElements.MVVM.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CNElements.MVVM.ViewModels
{
    public abstract class ObservableErrorNotify : Observable, INotifyDataErrorInfo
    {
        private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        public void SetError(string errorMessage, [CallerMemberName] string propertyName = null)
        {
            if (_errors.TryGetValue(propertyName, out List<string> errorList))
            {
                errorList.Add(errorMessage);
            }
            else
            {
                _errors.Add(propertyName, new List<string> { errorMessage });
            }
            HasErrors = true;
            OnErrorsChanged(propertyName);
        }

        public void ClearErrors([CallerMemberName] string propertyName = null)
        {
            if (HasErrors)
            {          
                if (_errors.TryGetValue(propertyName, out List<string> errorList))
                {
                    _errors.Remove(propertyName);
                }
                if (_errors.Count == 0)
                {
                    HasErrors = false;
                }
                OnErrorsChanged(propertyName);
            }
        }
        public void ClearAllErrors()
        {
            if (HasErrors)
            {
                _errors.Clear();
                HasErrors = false;
                OnErrorsChanged(null);
            }
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {        
            bool err = _errors.TryGetValue(propertyName, out List<string> errorsForProperty);
            if (!err) return null;
            return errorsForProperty;
        }
        private bool hasErrors = false;
        public bool HasErrors
        {
            get => hasErrors;
            protected set
            {
                if (Set(ref hasErrors, value))
                {
                    OnErrorsChanged(propertyName: null);
                }
            }
        }
        protected void OnErrorsChanged([CallerMemberName] string propertyName = null) =>
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }
}
