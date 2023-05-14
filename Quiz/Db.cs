using System;
using Microsoft.Maui.Controls;
using Quiz.Models;
using Quiz.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Quiz;

public class Db : DbContext
{
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<QuizModel> Quizzes { get; set; }

    public string DbPath { get; }

    public Db(string dbPath)
    {
        DbPath = dbPath;
        Seed();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");

    public void Seed()
    {
        this.Database.EnsureDeleted();
        this.Database.EnsureCreated();

        this.Add(createQuiz1());
        this.Add(createQuiz2());
        this.SaveChanges();
    }

    private QuizModel createQuiz1()
    {
        var answers = new List<Answer>
        {
            new Answer { Content = "nie", IsCorrect = true },
            new Answer { Content = "nie" },
            new Answer { Content = "nie" },
            new Answer { Content = "nie" }
        };

        var questions = new List<Question>
        {
            new Question { Content = "TEstowe pytanie", Answers = answers }
        };

        var quiz = new QuizModel
        {
            Title = "Czy maui i wpf powinny jeszcze istnieć?",
            Questions = questions
        };

        return quiz;
    }

    private QuizModel createQuiz2()
    {
        var answers = new List<Answer>
        {
            new Answer { Content = "tak" },
            new Answer { Content = "nie", IsCorrect = true },
            new Answer { Content = "jeszcze jak", IsCorrect = true },
            new Answer { Content = "okrutnik", IsCorrect = true }
        };

        var questions = new List<Question>
        {
            new Question { Content = "Czy wiedział?", Answers = answers }
        };

        var quiz = new QuizModel
        {
            Title = "Życie i posługa św. Jana Pawła II",
            Questions = questions,
        };

        return quiz;
    }
}
