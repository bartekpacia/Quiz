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
        Init();
    }

    public void Init()
    {
        var ans = new List<Answer>
        {
            new Answer { Content = "nie", IsCorrect = true },
            new Answer { Content = "nie" },
            new Answer { Content = "nie" },
            new Answer { Content = "nie" }
        };
        var ques = new List<Question>
        {
            new Question { Content = "TEstowe pytanie", Answers = ans }
        };
        var quiz = new QuizModel
        {
            Title = "Czy maui i wpf powinny jeszcze istnieć?",
            Questions = ques
        };

        this.Database.EnsureDeleted();
        this.Database.EnsureCreated();

        this.Add(quiz);
        this.SaveChanges();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");
}
