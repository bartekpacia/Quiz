using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Quiz.ViewModels
{
    public partial class ResultViewModel : ObservableObject
    {
        public ResultViewModel()
        {
            message =
                $"Correct answers {App.Store.correctAnswers}/{App.Store.totalQuestions}, time left: {App.Store.timeLeft}";
        }

        [ObservableProperty]
        string message;
    }
}
