using System;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Quiz.Models
{
    [Table("Questions")]
    public class QuestionEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Content { get; set; }
        public int CorrectAnswerId { get; set; }
    }

    public class Question : QuestionEntity
    {
        public List<Answer> Answers { get; set; }
    }
}

