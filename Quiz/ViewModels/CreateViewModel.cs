using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Quiz.Models;

namespace Quiz.ViewModels;

public partial class CreateViewModel : ObservableObject
{
    [ObservableProperty]
    public QuizModel quiz = new QuizModel();

    [ObservableProperty]
    public ObservableCollection<Question> questions = new ObservableCollection<Question>();

    public CreateViewModel()
    {
        App.DbService.Add(new QuizModel { Title = "Test" });
        App.DbService.SaveChanges();

        Quiz = App.DbService.Quizzes.First();
    }

    [RelayCommand]
    public void AddQuestion()
    {
        Questions.Add(new Question { Content = "Hello" });
        Quiz.Questions = Questions.ToList<Question>();
    }

    [RelayCommand]
    public void SaveQuiz()
    {
        App.DbService.Add(Quiz);
    }
}
