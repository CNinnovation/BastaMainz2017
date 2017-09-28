using CNElements.MVVM.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CNElements.MVVM.ViewModels
{
    public abstract class MasterDetailViewModel<TMasterViewModel, TItemViewModel, TItem> : ViewModel
        where TItemViewModel : IItemViewModel<TItem>
    {
        public MasterDetailViewModel()
        {
            RefreshCommand = new RelayCommand(OnRefresh);
        }

        private readonly ObservableCollection<TItemViewModel> _items = new ObservableCollection<TItemViewModel>();
        public ObservableCollection<TItemViewModel> Items => _items;

        protected TItemViewModel _selectedItem;
        public virtual TItemViewModel SelectedItem
        {
            get => _selectedItem;
            set => Set(ref _selectedItem, value);
        }

        protected void SetItemRange(IEnumerable<TItemViewModel> items)
        {
            Items.Clear();
            foreach (TItemViewModel item in items)
            {
                Items.Add(item);
            }
            if (Items.Count > 0)
            {
                SelectedItem = Items[0];
            }
        }

        public RelayCommand RefreshCommand { get; }

        protected async void OnRefresh()
        {
            await LoadAsync();
        }

        public async Task LoadAsync()
        {
            using (StartInProgress())
            {
                await LoadCoreAsync();
            }
        }

        public abstract Task LoadCoreAsync();


    }
}
