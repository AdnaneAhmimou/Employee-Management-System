using MediatR;
using EmployeeManagement.Data;
using EmployeeManagement.Commands;

namespace EmployeeManagement.Handlers
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly AppDbContext _context;

        public DeleteEmployeeCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(request.Id);

            if (employee == null)
            {
                return false;
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
