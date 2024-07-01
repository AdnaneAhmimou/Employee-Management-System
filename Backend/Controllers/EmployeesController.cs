using Microsoft.AspNetCore.Mvc;
using MediatR;
using EmployeeManagement.Commands;
using EmployeeManagement.Queries;
using EmployeeManagement.ViewModels;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeViewModel>>> GetEmployees()
        {
            var query = new GetAllEmployeesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeViewModel>> GetEmployee(Guid id)
        {
            var query = new GetEmployeeByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeViewModel>> PostEmployee(EmployeeViewModel employeeViewModel)
        {
            var command = new CreateEmployeeCommand(employeeViewModel); // Pass employeeDto to the command
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetEmployee), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(Guid id, EmployeeViewModel employeeDto)
        {
            var command = new UpdateEmployeeCommand(id, employeeDto); // Pass id and employeeDto to the command
            try
            {
                await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            var command = new DeleteEmployeeCommand { Id = id };
            try
            {
                await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }
    }
}
