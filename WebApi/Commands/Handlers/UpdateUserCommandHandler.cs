using MediatR;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Commands.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly AppDbContext _context;

        public UpdateUserCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.Id);
            if (user == null)
            {
                return false;
            }

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.Address = request.Address;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
