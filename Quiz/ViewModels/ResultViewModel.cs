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

        [RelayCommand]
        public async Task GoToMainPage()
        {
            var mainViewModel =
                Application.Current.MainPage.Handler.MauiContext.Services.GetService<MainViewModel>();

            App.Current.MainPage = new NavigationPage(new MainPage(mainViewModel));

            // FIXME: For unknown reason, the line below doesn't do anything
            //await Shell.Current.GoToAsync(nameof(MainPage));
        }
    }
}
