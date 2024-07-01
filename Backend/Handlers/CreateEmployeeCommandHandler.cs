using MediatR;
using AutoMapper;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using System.Threading;
using System.Threading.Tasks;
using EmployeeManagement.Commands;

namespace EmployeeManagement.Handlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeViewModel>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EmployeeViewModel> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<Employee>(request.EmployeeViewModel);
            employee.Id = Guid.NewGuid();
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<EmployeeViewModel>(employee);
        }
    }
}
