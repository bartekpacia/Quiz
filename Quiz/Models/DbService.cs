using System;
using Quiz.Models;
using Quiz.ViewModels;
using SQLite;
using SQLiteNetExtensions.Extensions;

namespace Quiz
{

    public class Repository
    {
        public const SQLite.SQLiteOpenFlags Flags =
             // open the database in read/write mode
             SQLite.SQLiteOpenFlags.ReadWrite |
             // create the database if it doesn't exist
             SQLite.SQLiteOpenFlags.Create |
             // enable multi-threaded database access
             SQLite.SQLiteOpenFlags.SharedCache;


        public SQLiteConnection conn;
        string dbPath;

        public SQLiteConnection getDb()
        {
            return conn;
        }

        public Repository(string dbPath)
        {
            this.dbPath = dbPath;

            conn = new SQLiteConnection(dbPath, true);

            conn.CreateTable<Answer>();
            conn.CreateTable<QuestionEntity>();
            conn.CreateTable<QuizModel>();
        }

        public bool CreateAnswer(Answer answer)
        {
            int id = conn.Insert(answer);

            return Convert.ToBoolean(id);
        }

        public List<Answer> GetAnswers()
        {
            conn = new SQLiteConnection(dbPath);
            return conn.Table<Answer>().ToList();
        }

        public Question GetQuestionById(int id)
        {

            var ans = conn.Query<Answer>($"SELECT * FROM Questions WHERE Id = {id}");
            var question = (Question)conn.Get<QuestionEntity>(1);


            question.Answers = ans.ToList();


            return question;
        }

        public bool CreateQuestions(Question question)
        {
            int count = conn.Insert(question);

            return Convert.ToBoolean(count);
        }
    }
}

