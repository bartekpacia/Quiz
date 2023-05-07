using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Quiz.ViewModels;

// TODO: Move the model classes elsewhere

public class QuizModel
{
    public List<QuestionModel> questions;
}

public class QuestionModel
{
    public List<String> answers;
    public int validAnswerIndex;
}

public partial class CreateViewModel : ObservableObject
{
    public CreateViewModel()
    {
        Quizes = new ObservableCollection<QuizModel>();

        var quizModel = new QuizModel();
        Quizes.Add(quizModel);
    }

    [ObservableProperty]
    ObservableCollection<QuizModel> quizes;
}
