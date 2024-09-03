using MediatR;

namespace WebApi.Commands
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
