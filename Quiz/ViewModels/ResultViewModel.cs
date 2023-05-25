using System;
using CommunityToolkit.Mvvm.ComponentModel;

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
