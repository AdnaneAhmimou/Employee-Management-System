using MediatR;
using AutoMapper;
using EmployeeManagement.Data;
using EmployeeManagement.ViewModels;
using EmployeeManagement.Queries;

namespace EmployeeManagement.Handlers
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeViewModel>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetEmployeeByIdQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EmployeeViewModel> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(request.Id);

            if (employee == null)
            {
                return null;
            }
            return _mapper.Map<EmployeeViewModel>(employee);
        }
    }
}
