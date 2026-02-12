using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Fleet_Manager
{
    internal class Fleet
    {
        //Create a list to hold vehicles
        private readonly List<Vehicle> _vehicles = new();

        //Method to add a vehicle
        public void AddVehicle(Vehicle v)
        {
            if (v == null)
                throw new ArgumentNullException(nameof(v));
            _vehicles.Add(v);
        }

        //Void to remove vehicles
        public void RemoveVehicle(string model)
        {
            var toRemove = _vehicles.FirstOrDefault(v =>
            v.Model.Equals(model, StringComparison.OrdinalIgnoreCase));

            if (toRemove != null)
            {
                _vehicles.Remove(toRemove);
                Console.WriteLine($"Vehicle '{model}' removed from the fleet.");
            }
            else
            {
                Console.WriteLine($"Vehicle '{model}' not found.");
            }
        }

        //Double to display average mileage
        public double GetAverageMileage() => _vehicles.Count == 0 ? 0 : _vehicles.Average(v => v.Mileage);

        //Void to display the vehicles
        public void DisplayAllVehicles()
        {
            //control for an empty list
            if (_vehicles.Count == 0)
            {
                Console.WriteLine("No vehicles in the fleet.");
                return;
            }

            //foreach through the list of vehicles
            Console.WriteLine("=== Fleet Summary ===");

            foreach (var v in _vehicles)
            {
                Console.WriteLine(v.GetSummary());
            }
        }

        //Void to service all vehicles that are due for service
        public void ServiceAllDue()
        {
            int serviced = 0;
            foreach (var v in _vehicles)
            {
                if (v.NeedsService())
                {
                    serviced++;
                    v.PerfomService();
                }
            }
            Console.WriteLine($"{serviced} vehicle(s) serviced.");
        }
    }
}