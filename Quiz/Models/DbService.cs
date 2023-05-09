using System;
using Microsoft.Maui.Controls;
using Quiz.Models;
using Quiz.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Quiz.Models
{


    public class DbService : DbContext
    {
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuizModel> Quizzes { get; set; }

        public string DbPath { get; }

        public DbService(string dbPath)
        {
            DbPath = dbPath;
            Init();
        }

        public void Init()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");



    }

}
