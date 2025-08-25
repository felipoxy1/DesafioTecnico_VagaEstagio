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

        [HttpPost]
        public ActionResult<Machine> AddMachine([FromBody] Machine machine)
        {
            if (string.IsNullOrEmpty(machine.Name))
            {
                return BadRequest("O nome da maquina e obrigatorio.");
            }
            MachineRepository.Add(machine);
            return CreatedAtAction(nameof(GetMachines), new { id = machine.Id }, machine);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMachine(Guid id, [FromBody] Machine machine)
        {
            if (id != machine.Id)
            {
                return BadRequest("O ID da maquina nao corresponde.");
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