using MediatR;
using EmployeeManagement.ViewModels;

namespace EmployeeManagement.Queries
{
    public class GetEmployeeByIdQuery : IRequest<EmployeeViewModel>
    {
        public Guid Id { get; set; }

        public GetEmployeeByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}