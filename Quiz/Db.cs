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
            new Answer
            {
                Id = 9,
                Content = "nie",
                IsCorrect = true
            },
            new Answer { Id = 10, Content = "nie" },
            new Answer { Id = 11, Content = "nie" },
            new Answer { Id = 12, Content = "nie" }
        };

        var questions = new List<Question>
        {
            new Question
            {
                Id = 1,
                Content = "TEstowe pytanie",
                Answers = answers
            }
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
        var answers1 = new List<Answer>
        {
            new Answer { Id = 1, Content = "tak" },
            new Answer
            {
                Id = 2,
                Content = "nie",
                IsCorrect = true
            },
            new Answer
            {
                Id = 3,
                Content = "jeszcze jak",
                IsCorrect = true
            },
            new Answer
            {
                Id = 4,
                Content = "okrutnik",
                IsCorrect = true
            }
        };

        var answers2 = new List<Answer>
        {
            new Answer { Id = 5, Content = "mało" },
            new Answer
            {
                Id = 6,
                Content = "dużo",
                IsCorrect = true
            },
            new Answer
            {
                Id = 7,
                Content = "10 ton",
                IsCorrect = true
            },
            new Answer { Id = 8, Content = "5 kg" }
        };

        var questions = new List<Question>
        {
            new Question
            {
                Id = 2,
                Content = "Czy wiedział?",
                Answers = answers1
            },
            new Question
            {
                Id = 3,
                Content = "Ile ton kremówek spożył?",
                Answers = answers2
            }
        };

        var quiz = new QuizModel
        {
            Title = "Życie i posługa św. Jana Pawła II",
            Questions = questions,
        };

        return quiz;
    }
}
