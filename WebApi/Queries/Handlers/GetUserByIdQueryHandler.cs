using MediatR;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Queries.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User?>
    {
        private readonly AppDbContext _context;

        public GetUserByIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users.FindAsync(request.Id);
        }
    }
}
