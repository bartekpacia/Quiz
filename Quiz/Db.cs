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

    public void Seed()
    {
        this.Database.EnsureDeleted();
        this.Database.EnsureCreated();

        var quiz1 = new QuizModel
        {
            Title = "Czy maui i wpf powinny jeszcze istnieć?",
            Questions =
            {
                new Question
                {
                    Content = "Testowe pytanie",
                    Answers =
                    {
                        new Answer { Content = "nie", IsCorrect = true },
                        new Answer { Content = "nie" },
                        new Answer { Content = "nie" },
                        new Answer { Content = "nie" }
                    }
                }
            }
        };

        var quiz2 = new QuizModel
        {
            Title = "Życie i posługa św. Jana Pawła II",
            Questions =
            {
                new Question
                {
                    Content = "Czy wiedział?",
                    Answers =
                    {
                        new Answer { Content = "tak" },
                        new Answer { Content = "nie", IsCorrect = true },
                        new Answer { Content = "jeszcze jak", IsCorrect = true },
                        new Answer { Content = "okrutnik", IsCorrect = true }
                    }
                }
            }
        };

        this.Add(quiz1);
        this.Add(quiz2);
        this.SaveChanges();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");
}
