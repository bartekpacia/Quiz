using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Quiz.ViewModels;

namespace Quiz;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    async Task OnNavigated(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(PlayPage));
    }

    private void OnCounterIncrement(object sender, EventArgs e)
    {
        count++;

        UpdateButton();
    }

    private void OnCounterDecrement(object sender, EventArgs e)
    {
        count--;

        UpdateButton();
    }

    private void UpdateButton()
    {
        if (count == 1)
        {
            CounterLabel.Text = $"Clicked {count} time";
        }
        else
        {
            CounterLabel.Text = $"Clicked {count} times";
        }
    }
}
