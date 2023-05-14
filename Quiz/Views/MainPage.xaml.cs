using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Quiz.ViewModels;

namespace Quiz;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
