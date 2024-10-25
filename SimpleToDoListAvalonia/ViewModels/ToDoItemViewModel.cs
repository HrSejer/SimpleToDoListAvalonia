using CommunityToolkit.Mvvm.ComponentModel;
using SimpleToDoListAvalonia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToDoListAvalonia.ViewModels
{
    public partial class ToDoItemViewModel : ViewModelBase
    {
        [ObservableProperty]
        public bool _isChecked;

        [ObservableProperty]
        public string? _content;

        public ToDoItemViewModel() 
        { 
        
        }

        public ToDoItemViewModel(ToDoItem item)
        { 
            IsChecked = item.IsChecked;
            Content = item.Content;
        }

        public ToDoItem GetToDoItem()
        {
            return new ToDoItem()
            {
                IsChecked = this.IsChecked,
                Content = this.Content
            };
        }

        public override string ToString()
        {
            return string.Empty;
        }

    }

    
}
