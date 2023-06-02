using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Quiz.Models;

[PrimaryKey("Id")]
public class Answer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int Index { get; set; }
    public string Content { get; set; }
    public int QuestionId { get; set; }
    public bool IsCorrect { get; set; } = false;
    public bool IsSelected { get; set; } = false;
}
