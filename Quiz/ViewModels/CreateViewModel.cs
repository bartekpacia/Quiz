using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Quiz.Models;

namespace Quiz.ViewModels;

public partial class CreateViewModel : ObservableObject
{
    int questionCurrentIndex = 0;

    void setQuestions()
    {
        if (Quiz.Questions != null)
        {
            Questions = new ObservableCollection<Question>(Quiz.Questions);
        }
    }

    [ObservableProperty]
    public string errorMessage;

    [ObservableProperty]
    public QuizModel quiz = new QuizModel();

    [ObservableProperty]
    public ObservableCollection<Question> questions = new ObservableCollection<Question>();

    public CreateViewModel()
    {
        Quiz = App.Db.Quizzes.Find(App.Store.currentQuizId) ?? new QuizModel();

        setQuestions();
    }

    [RelayCommand]
    void AddQuestion()
    {
        questionCurrentIndex++;

        var emptyAnswers = new List<Answer>();

        for (int i = 0; i < 4; i++)
        {
            emptyAnswers.Add(new Answer() { Content = $"Answer {i}", Index = i });
        }

        Questions.Add(
            new Question
            {
                Content = "New question",
                Answers = emptyAnswers,
                Index = questionCurrentIndex
            }
        );
        Quiz.Questions = Questions.ToList<Question>();
    }

    [RelayCommand]
    void RemoveQuestion(int index)
    {
        var itemToRemove = Questions.Single(item => item.Index == index);
        Questions.Remove(itemToRemove);

        Quiz.Questions = Questions.ToList<Question>();
    }

    [RelayCommand]
    async void SaveQuiz()
    {
        foreach (var q in Quiz.Questions)
        {
            int i = 0;
            int empty = 0;

            foreach (var a in q.Answers)
            {
                if (a.IsCorrect)
                {
                    i++;
                }
                if (a.Content.Length == 0)
                {
                    empty++;
                }
            }

            if (i > 0)
            {
                ErrorMessage = "Every question need at least one correct answer";
                return;
            }
            if (empty > 0)
            {
                ErrorMessage = "Answer can not be empty";
                return;
            }
        }

        if (Quiz.Questions.Count == 0)
        {
            ErrorMessage = "You can't create empty quiz";

            return;
        }

        if (Quiz.Id != 0)
        {
            App.Db.Update(Quiz);
        }
        else
        {
            App.Db.Add(Quiz);
        }

        App.Db.SaveChanges();

        await Shell.Current.GoToAsync(nameof(MainPage));
    }
}
