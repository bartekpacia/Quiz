using System;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Quiz.Models
{
    [Table("Answers")]
    public class Answer
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Content { get; set; }
        public int QuestionId { get; set; }
    }
}
