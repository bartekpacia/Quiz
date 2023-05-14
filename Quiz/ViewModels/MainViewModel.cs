using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Quiz.Models;

namespace Quiz.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    ObservableCollection<QuizModel> quizzes;

    [ObservableProperty]
    string text;

    public MainViewModel()
    {
        var data = App.Db.Quizzes.ToList();
        Quizzes = new ObservableCollection<QuizModel>(data);
    }

    [RelayCommand]
    async Task Play(int id)
    {
        App.Store.currentQuizId = id;
        await Shell.Current.GoToAsync(nameof(PlayPage));
    }

    [RelayCommand]
    async Task Create(int id)
    {
        App.Store.currentQuizId = id;
        await Shell.Current.GoToAsync(nameof(CreatePage));
    }

    [RelayCommand]
    void Refresh()
    {
        var data = App.Db.Quizzes.ToList();
        Quizzes = new ObservableCollection<QuizModel>(data);
    }
}
