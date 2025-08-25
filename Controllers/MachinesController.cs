using Microsoft.AspNetCore.Mvc;
using MyMachineAPI.Models;
using MyMachineAPI.Data;

namespace MyMachineAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MachinesController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<Machine>> GetMachines([FromQuery] string? status)
        {
            var machines = MachineRepository.GetAll();

            if (!string.IsNullOrEmpty(status))
            {
                machines = machines.Where(m => m.Status != null && m.Status.Equals(status, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return Ok(machines);
        }

        [HttpGet("{id}")]
        public ActionResult<Machine> GetMachineById(Guid id)
        {
            var machine = MachineRepository.GetById(id);

            if (machine == null)
            {
                return NotFound();
            }

            return Ok(machine);
        }

        [HttpPost]
        public ActionResult<Machine> AddMachine([FromBody] Machine machine)
        {
            if (string.IsNullOrEmpty(machine.Name))
            {
                return BadRequest("O nome da máquina é obrigatório.");
            }

            MachineRepository.Add(machine);

            return CreatedAtAction(nameof(GetMachineById), new { id = machine.Id }, machine);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMachine(Guid id, [FromBody] Machine machine)
        {
            if (id != machine.Id)
            {
                return BadRequest("O ID na URL não corresponde ao ID no corpo da requisição.");
            }

            var existingMachine = MachineRepository.GetById(id);
            if (existingMachine == null)
            {
                return NotFound();
            }

            MachineRepository.Update(machine);

            return NoContent();
        }
    }
}
