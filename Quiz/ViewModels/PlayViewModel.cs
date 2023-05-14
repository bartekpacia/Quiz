using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Quiz.Models;

namespace Quiz.ViewModels;

public partial class PlayViewModel : ObservableObject
{
    const string goodAnswer = "Warsaw";

    public PlayViewModel()
    {
        Answers = new ObservableCollection<string>();

        answers.Add("Warsaw");
        answers.Add("Cracow");
        answers.Add("Gliwice");
        answers.Add("Gdańsk");

        var currentQuizId = App.Store.currentQuizId;
        Quiz = App.Db.Quizzes.Find(currentQuizId);
        Questions = new ObservableCollection<Question>(Quiz.Questions);
        CurrentQuestion = Questions.First();
        CurrentAnswers = new ObservableCollection<Answer>(CurrentQuestion.Answers);
    }

    [ObservableProperty]
    ObservableCollection<String> answers;

    [ObservableProperty]
    int selectedAnswer;

    [RelayCommand]
    void SelectAnswer(string answer)
    {
        if (answer == goodAnswer) { }
        else { }
    }

    [ObservableProperty]
    public QuizModel quiz;

    [ObservableProperty]
    public ObservableCollection<Question> questions;

    [ObservableProperty]
    public Question currentQuestion;

    [ObservableProperty]
    public ObservableCollection<Answer> currentAnswers;
}
