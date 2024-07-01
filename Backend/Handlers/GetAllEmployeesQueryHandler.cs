using MediatR;
using AutoMapper;
using EmployeeManagement.Data;
using EmployeeManagement.ViewModels;
using EmployeeManagement.Queries;
using Microsoft.EntityFrameworkCore;
namespace EmployeeManagement.Handlers
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, List<EmployeeViewModel>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetAllEmployeesQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<EmployeeViewModel>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _context.Employees.ToListAsync(cancellationToken);
            return _mapper.Map<List<EmployeeViewModel>>(employees);
        }
    }
}
