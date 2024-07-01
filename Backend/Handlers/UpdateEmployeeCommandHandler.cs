using MediatR;
using AutoMapper;
using EmployeeManagement.Data;
using EmployeeManagement.Commands;
using EmployeeManagement.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Handlers
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeViewModel>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EmployeeViewModel> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(request.Id);

            if (employee == null)
            {
                return null;
            }

            _mapper.Map(request.EmployeeViewModel, employee);
            _context.Entry(employee).State = EntityState.Modified;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<EmployeeViewModel>(employee);
        }
    }
}
