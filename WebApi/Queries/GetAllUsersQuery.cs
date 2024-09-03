using MediatR;
using WebApi.Models;

namespace WebApi.Queries
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {
    }
}
