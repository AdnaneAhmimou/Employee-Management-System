using MediatR;
using EmployeeManagement.ViewModels;

namespace EmployeeManagement.Commands
{
    public class CreateEmployeeCommand : IRequest<EmployeeViewModel>
    {
        public CreateEmployeeCommand(EmployeeViewModel employeeViewModel)
        {
            EmployeeViewModel = employeeViewModel;
        }

        public EmployeeViewModel EmployeeViewModel { get; set; }
    }
}