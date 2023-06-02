using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Quiz.Models;

[PrimaryKey("Id")]
public class Question
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int Index { get; set; }
    public string Content { get; set; }
    public int QuizId { get; set; }
    public QuizModel Quiz { get; set; }
    public List<Answer> Answers { get; set; }
}
