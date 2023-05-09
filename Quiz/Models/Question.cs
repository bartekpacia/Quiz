using System;
using Microsoft.EntityFrameworkCore;

namespace Quiz.Models
{
    [PrimaryKey("Id")]
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int CorrectAnswerId { get; set; }
        public int QuizId { get; set; }
        public QuizModel Quiz { get; set; }
        public List<Answer> Answers { get; set; }
    }
}

