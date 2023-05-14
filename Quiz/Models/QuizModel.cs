using Microsoft.EntityFrameworkCore;

namespace Quiz.Models
{
    [PrimaryKey("Id")]
    public class QuizModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Question> Questions;
    }
}
