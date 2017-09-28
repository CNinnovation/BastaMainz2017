using CNElements.MVVM.Core;
using Microsoft.Extensions.Logging;
using System;

namespace CNElements.MVVM.ViewModels
{
    public abstract class EditableMasterDetailViewModel<TMasterViewModel, TItemViewModel, TItem>
        : MasterDetailViewModel<TMasterViewModel, TItemViewModel, TItem>
        where TItemViewModel : IItemViewModel<TItem>
    {
        private readonly ILogger _logger;

        public EditableMasterDetailViewModel(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<TMasterViewModel>();

            AddCommand = new RelayCommand(OnAdd);
        }

        public RelayCommand AddCommand { get; }

        public override TItemViewModel SelectedItem
        {
            get => base.SelectedItem;
            set
            {
                if (Set(ref _selectedItem, value) && value != null)
                {
                    ClearAndSetSelectedItems(_selectedItem);
                }
            }
        }

        public void OnAdd()
        {
            OnAddCore();
        }

        public abstract void OnAddCore();

        private void ClearAndSetSelectedItems(TItemViewModel newSelection)
        {
            if (newSelection == null) throw new ArgumentNullException(nameof(newSelection));

            foreach (var item in Items)
            {
                item.IsSelected = ReferenceEquals(item, newSelection);
            }
        }
    }
}
