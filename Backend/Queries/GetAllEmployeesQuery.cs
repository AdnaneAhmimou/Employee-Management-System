using MediatR;
using EmployeeManagement.ViewModels;

namespace EmployeeManagement.Queries
{
    public class GetAllEmployeesQuery : IRequest<List<EmployeeViewModel>>
    {
    }
}