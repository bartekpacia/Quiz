using Microsoft.EntityFrameworkCore;

namespace Quiz.Models;

[PrimaryKey("Id")]
public class Answer
{
    public int Id { get; set; }
    public int Index { get; set; }
    public string Content { get; set; }
    public int QuestionId { get; set; }
    public bool IsCorrect { get; set; } = false;
}
