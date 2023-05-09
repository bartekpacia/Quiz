using Microsoft.EntityFrameworkCore;

namespace Quiz.Models
{
    [PrimaryKey("Id")]
    public class Answer
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int QuestionId { get; set; }
    }
}
