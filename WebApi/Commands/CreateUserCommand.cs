using MediatR;

namespace WebApi.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
    }

}
