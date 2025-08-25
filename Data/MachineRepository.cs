using MyMachineAPI.Models;

namespace MyMachineAPI.Data
{
    public static class MachineRepository
    {
        private static readonly List<Machine> _machines = new List<Machine>();

        public static List<Machine> GetAll()
        {
            return _machines;
        }

        public static Machine? GetById(Guid id)
        {
            return _machines.FirstOrDefault(m => m.Id == id);
        }

        public static void Add(Machine machine)
        {
            machine.Id = Guid.NewGuid();
            _machines.Add(machine);
        }

        public static void Update(Machine updatedMachine)
        {
            var existingMachine = GetById(updatedMachine.Id);
            if (existingMachine != null)
            {
                existingMachine.Location = updatedMachine.Location;
                existingMachine.Status = updatedMachine.Status;
            }
        }
    }
}