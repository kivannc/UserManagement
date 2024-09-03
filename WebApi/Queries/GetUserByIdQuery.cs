using MediatR;
using WebApi.Models;

namespace WebApi.Queries
{
    public class GetUserByIdQuery : IRequest<User?>
    {
        public int Id { get; set; }
    }
}
