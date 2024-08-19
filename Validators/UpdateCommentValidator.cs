using FluentValidation;
using WebApplication5.Dtos.Comments;

namespace WebApplication5.Validators;

public class UpdateCommentValidator : AbstractValidator<UpdateCommentRequestDto>
{
    public UpdateCommentValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MinimumLength(5).WithMessage("Title must be at least 5 characters.")
            .MaximumLength(280).WithMessage("Title cannot be more than 280 characters.");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Content is required.")
            .MinimumLength(5).WithMessage("Content must be at least 5 characters.")
            .MaximumLength(280).WithMessage("Content cannot be more than 280 characters.");
    }
}