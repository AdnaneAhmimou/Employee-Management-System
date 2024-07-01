using MediatR;
using EmployeeManagement.ViewModels;


namespace EmployeeManagement.Commands
{
    public class UpdateEmployeeCommand : IRequest<EmployeeViewModel>
{
    public UpdateEmployeeCommand(Guid id, EmployeeViewModel employeeViewModel)
    {
        Id = id;
        EmployeeViewModel = employeeViewModel;
    }

    public Guid Id { get; set; }
    public EmployeeViewModel EmployeeViewModel { get; set; }
}
}