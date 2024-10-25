using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace SimpleToDoListAvalonia.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public ObservableCollection<ToDoItemViewModel> ToDoItems { get; } = new ObservableCollection<ToDoItemViewModel>();

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AddItemCommand))]
    private string? _newItemContent;

    private bool CanAddItem() => !string.IsNullOrWhiteSpace(NewItemContent);
    
    [RelayCommand (CanExecute = nameof(CanAddItem))]
    private void AddItem()
    {
        var newItem = new ToDoItemViewModel()
        {
            Content = NewItemContent,
            IsChecked = false
        };

        ToDoItems.Add(newItem);
        NewItemContent = null;
    }

    [RelayCommand]
    private void RemoveItem(ToDoItemViewModel item)
    {
        ToDoItems.Remove(item);
    }
}
