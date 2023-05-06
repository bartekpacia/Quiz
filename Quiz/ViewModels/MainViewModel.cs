using System;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Quiz.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    string text;

    [RelayCommand]
    async Task Play()
    {
        await Shell.Current.GoToAsync(nameof(PlayPage));
    }

    [RelayCommand]
    async Task Create()
    {
        await Shell.Current.GoToAsync(nameof(CreatePage));
    }
}
