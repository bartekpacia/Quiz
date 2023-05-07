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

    private void OnCounterIncrement(object sender, EventArgs e)
    {
        count++;
        CounterLabel.Text = $"Counter: {count}";
    }

    private void OnCounterDecrement(object sender, EventArgs e)
    {
        count--;
        CounterLabel.Text = $"Counter: {count}";
    }
}
