using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Dtos.Comments;

public class CreateCommentDto
{

    public string Title {get;set;} = string.Empty;
    
    public string Content {get; set; } = string.Empty;
    
}