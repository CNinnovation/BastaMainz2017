using CNElements.MVVM.Core;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CNElements.MVVM.ViewModels
{
    public enum ItemState
    {
        Read,
        Edit,
        New,
    }

    public abstract class ItemViewModel<T> : ViewModel, IItemViewModel<T>
    {
        public ItemViewModel(T item, bool isNew = false)
        {
            Item = item;
            if (isNew)
            {
                SetItemState(ItemState.New);
            }
            else
            {
                SetItemState(ItemState.Read);
            }
            IsSelected = false;

            _deleteCommand = new RelayCommand(OnDelete);
            _editModeCommand = new RelayCommand(OnEditMode);
            _cancelCommand = new RelayCommand(OnCancel);
            _saveCommand = new RelayCommand(OnSave);
        }

        private T _item;
        public T Item
        {
            get => _item;
            set => Set(ref _item, value);
        }

        private ItemState _itemState;
        public ItemState State => _itemState;

        protected void SetItemState(ItemState state)
        {
            _itemState = state;
            OnPropertyChanged(nameof(IsNew));
            OnPropertyChanged(nameof(IsEditMode));
        }

        private bool _isSelected;
        public virtual bool IsSelected
        {
            get => _isSelected;
            set => Set(ref _isSelected, value);
        }

        public bool IsNew => State == ItemState.New;
        public bool IsEditMode => (State == ItemState.Edit || State == ItemState.New) && !InProgress;


        private RelayCommand _deleteCommand;
        public ICommand DeleteCommand => _deleteCommand;

        private RelayCommand _editModeCommand;
        public ICommand EditModeCommand => _editModeCommand;

        private RelayCommand _cancelCommand;
        public RelayCommand CancelCommand => _cancelCommand;
        private RelayCommand _saveCommand;
        public RelayCommand SaveCommand => _saveCommand;

        public async void OnDelete()
        {
            try
            {
                await OnDeleteCoreAsync();
            }
            catch (Exception ex)
            {
                SetError(ex.Message);
            }
        }
        public abstract Task OnDeleteCoreAsync();
        public virtual void OnEditMode()
        {
            SetItemState(ItemState.Edit);
        }

        public async void OnCancel()
        {
            using (StartInProgress())
            {
                await OnCancelCoreAsync();
            }
            SetItemState(ItemState.Read);
        }

        protected abstract Task OnCancelCoreAsync();

        public async void OnSave()
        {
            using (StartInProgress())
            {
                await OnSaveCoreAsync();
            }
            SetItemState(ItemState.Read);
        }
        protected abstract Task OnSaveCoreAsync();

    }
}
