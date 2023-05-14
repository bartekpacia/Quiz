using System;
using Quiz.Models;

// global State

public class Store
{
    public Store() { }

    public List<QuizModel> Quizzes;
    public int currentQuizId = 1;

    public void RefetchQuzizes() { }
}
