using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Dispatching;
using Quiz.Models;

namespace Quiz.ViewModels;

public partial class PlayViewModel : ObservableObject
{
    public PlayViewModel()
    {
        var currentQuizId = App.Store.currentQuizId;
        Quiz = App.Db.Quizzes.Find(currentQuizId);
        Questions = new ObservableCollection<Question>(Quiz.Questions);
        CurrentQuestion = Questions[CurrentQuestionIndex];
        CurrentAnswers = new ObservableCollection<Answer>(CurrentQuestion.Answers);
    }

    [RelayCommand]
    void SelectionChanged(int id)
    {
        var found = CurrentAnswers.FirstOrDefault(answer => answer.Id == id);
        var i = CurrentAnswers.IndexOf(found);

        CurrentAnswers[i].IsSelected = !CurrentAnswers[i].IsSelected;
        CurrentAnswers = new ObservableCollection<Answer>(CurrentAnswers);
    }

    private bool CheckCorrectnes()
    {
        foreach (var answer in CurrentAnswers)
        {
            if (answer.IsCorrect != answer.IsSelected)
            {
                return false;
            }
        }
        return true;
    }

    [RelayCommand]
    async Task GoToNextPage()
    {
        var isCorrect = CheckCorrectnes();
        if (isCorrect)
            CorrectAnswered.Add(isCorrect);

        CurrentQuestionIndex++;

        if (Questions.Count > CurrentQuestionIndex)
        {
            CurrentQuestion = Questions[CurrentQuestionIndex];
            CurrentAnswers = new ObservableCollection<Answer>(CurrentQuestion.Answers);
        }
        else
        {
            Console.WriteLine("Going to Results Page!");
            await GoToResult();
        }
    }

    [ObservableProperty]
    public ObservableCollection<bool> correctAnswered = new ObservableCollection<bool>();

    [ObservableProperty]
    public int currentQuestionIndex = 0;

    [ObservableProperty]
    public QuizModel quiz;

    [ObservableProperty]
    public ObservableCollection<Question> questions;

    [ObservableProperty]
    public Question currentQuestion;

    [ObservableProperty]
    public ObservableCollection<Answer> currentAnswers;

    async private Task GoToResult()
    {
        App.Store.correctAnswers = CorrectAnswered.Count;
        App.Store.totalQuestions = Quiz.Questions.Count;
        App.Store.quizName = Quiz.Title;

        await Shell.Current.GoToAsync(nameof(ResultPage));
    }
}
