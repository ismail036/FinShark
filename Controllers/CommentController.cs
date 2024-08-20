using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Interfaces;
using WebApplication5.Mappers; 
using WebApplication5.Data;
using WebApplication5.Dtos.Comments;
using WebApplication5.Dtos.Stock;
using WebApplication5.Extensions;
using WebApplication5.Helpers;

namespace WebApplication5.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentRepository   _commentRepo;
    private readonly IStockRepository     _stockRepo;
    private readonly UserManager<AppUser> _userManager;

    public CommentController(ICommentRepository commentRepo , IStockRepository stockRepo , UserManager<AppUser> userManager)
    {
        _commentRepo = commentRepo;
        _stockRepo   = stockRepo;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var comments = await _commentRepo.GetAllAsync();
        return Ok(comments);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var comment = await _commentRepo.GetByIdAsync(id);

        if (comment == null)
        {
            return NotFound();
        }
        
        return Ok(comment);
    }

    [HttpPost("{stockId:int}")]
    public async Task<IActionResult> Create([FromRoute] int stockId, CreateCommentDto commentDto)
    {
        if (!await _stockRepo.StockExists(stockId))
        {
            return BadRequest("Stock does not exist");
        }

        var username = User.GetUsername();
        var appUser = await _userManager.FindByNameAsync(username);
    
        var commentModel = CommentMapper.ToCommentFromCreate(commentDto, stockId);

        commentModel.AppUserId = appUser.Id;
        
        await _commentRepo.CreateAsync(commentModel);

        var commentDtoResult = CommentMapper.ToCommentDto(commentModel);

        return CreatedAtAction(nameof(GetById), new { id = commentDtoResult.Id }, commentDtoResult);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequestDto updateDto)
    {
        var existingComment = await _commentRepo.GetByIdAsync(id);

        if (existingComment == null)
        {
            return NotFound("Comment not found");
        }

        var updatedComment = CommentMapper.ToCommentFromUpdate(updateDto);

        await _commentRepo.UpdateAsync(id , updatedComment);

        return Ok(updatedComment);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var commentModel = await _commentRepo.DeleteAsync(id);

        if (commentModel == null)
        {
            return NotFound("Comment does not exist");
        }   

        return Ok(commentModel);
    }
}