namespace DataTransferObject.Security
{
    using FluentValidation;
    using MediatR;
    using System.ComponentModel.DataAnnotations;

    public class LoginDto : IRequest<Response>
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class LoginValidator : AbstractValidator<LoginDto>
    {

    }
}
