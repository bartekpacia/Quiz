using System;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Quiz.Models
{
    [Table("QuizModel")]
    public class QuizModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        [OneToMany]
        public List<Question> question { get; set; }
    }
}

