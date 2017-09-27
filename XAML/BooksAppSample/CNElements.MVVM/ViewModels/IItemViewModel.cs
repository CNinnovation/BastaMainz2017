namespace CNElements.MVVM.ViewModels
{
    public interface IItemViewModel<T>
    {
        bool IsNew { get; }
        bool IsSelected { get; set; }
        T Item { get; set; }
    }
}
