using CNElements.MVVM.Core;

namespace CNElements.MVVM.ViewModels
{
    public abstract partial class ViewModel : Observable
    {
        private bool _hasError;
        public bool HasError
        {
            get => _hasError;
            set => Set(ref _hasError, value);
        }

        public void SetError(string error)
        {
            ErrorMessage = error;
            HasError = true;
        }

        public void ClearError()
        {
            ErrorMessage = string.Empty;
            HasError = false;
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            protected set => Set(ref _errorMessage, value);
        }
    }
}
