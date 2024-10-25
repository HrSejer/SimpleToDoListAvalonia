using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using DynamicData;
using SimpleToDoListAvalonia.Models;
using SimpleToDoListAvalonia.Services;
using SimpleToDoListAvalonia.ViewModels;
using SimpleToDoListAvalonia.Views;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleToDoListAvalonia;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private readonly MainViewModel _mainViewModel = new MainViewModel();

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = _mainViewModel
            };

            desktop.ShutdownRequested += DesktopOnShutdownRequested;

        }

        base.OnFrameworkInitializationCompleted();
    }

    private bool _canClose;
    private async void DesktopOnShutdownRequested(object? sender, ShutdownRequestedEventArgs e)
    {
        e.Cancel = !_canClose;

        if (!_canClose)
        {
            var itemsToSave = _mainViewModel.ToDoItems.Select(item => item.GetToDoItem()).ToList();

            Trace.WriteLine($"Saving {itemsToSave.Count} items...");
            foreach (var item in itemsToSave)
            {
                Trace.WriteLine($"Item Content: {item.Content}, IsChecked: {item.IsChecked}");
            }

            await ToDoListFileService.SaveToFileAsync(itemsToSave);

            _canClose = true;
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.Shutdown();
            }
        }
    }
}
