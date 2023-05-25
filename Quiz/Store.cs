using System;
using Quiz.Models;

// global State

public class Store
{
    public Store() { }

    public List<QuizModel> Quizzes;
    public int currentQuizId = 1;

    public int correctAnswers;
    public int totalQuestions;
    public int timeLeft;
    public string quizName;

    public void RefetchQuzizes() { }
}
