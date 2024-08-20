using api.Models;
using WebApplication5.Dtos.Comments;
using WebApplication5.Dtos.Stock;

namespace WebApplication5.Mappers;

public static class CommentMapper
{

    public static CommentDto ToCommentDto(Comment commentModel)
    {
        return new CommentDto
        {
            Id = commentModel.Id,
            Title = commentModel.Title,
            Content = commentModel.Content,
            CreatedOn = commentModel.CreatedOn,
            CreatedBy = commentModel.AppUser.UserName,
            StockId = commentModel.StockId,
        };
    }
    
    public static Comment ToCommentFromCreate(CreateCommentDto commentDto , int stockId)
    {
        return new Comment
        {
            Title = commentDto.Title,
            Content = commentDto.Content,
            StockId = stockId,
        };
    }
    
    public static Comment ToCommentFromUpdate(UpdateCommentRequestDto commentDto)
    {
        return new Comment
        {
            Title = commentDto.Title,
            Content = commentDto.Content,
        };
    }
    
}