using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Quiz.ViewModels;

public partial class PlayViewModel : ObservableObject
{
    // TODO: Quiz properties
    //  * List of all quizes

    // Current question

    const string goodAnswer = "Warsaw";

    public PlayViewModel()
    {
        Answers = new ObservableCollection<string>();

        answers.Add("Warsaw");
        answers.Add("Cracow");
        answers.Add("Gliwice");
        answers.Add("Gdańsk");
    }

    [ObservableProperty]
    ObservableCollection<String> answers;

    [ObservableProperty]
    int selectedAnswer;

    [RelayCommand]
    void SelectAnswer(string answer)
    {
        if (answer != goodAnswer) { }
        else { }
    }
}
