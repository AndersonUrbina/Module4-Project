namespace Vehicle_Fleet_Manager
{
    public static class Program
    {
        //Main method, entry point to the program
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Vehicle Fleet Manager");

            //Create a fleet instance
            var fleet = new Fleet();

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Vehicle");
                Console.WriteLine("2. Remove Vehicle");
                Console.WriteLine("3. Display Fleet");
                Console.WriteLine("4. Show Average Milage");
                Console.WriteLine("5. Services Due Vehicles");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine().Trim();

                switch (choice)
                { 
                    default:
                        Console.WriteLine("Invalid option. Please select a valid option.");
                        break;
                    case "1":
                        AddVehicleMenu(fleet);
                        break;
                    case "2":
                        RemoveVehicleMenu(fleet);
                        break;
                    case "3":
                        fleet.DisplayAllVehicles();
                        break;
                    case "4":
                        Console.WriteLine($"Average Mileage: {fleet.GetAverageMileage():N0} mi");
                        break;
                    case "5":
                        fleet.ServiceAllDue();
                        break;
                    case "6":
                        running = false;
                        break;
                }
            }

            //Goodbye message
            Console.WriteLine("Existing Fleet Manager. Goodbye!");
        }

        //Method to add a vehicle to the fleet
        private static void AddVehicleMenu(Fleet fleet)
        {
            Console.Write("Enter make: ");
            string make = Console.ReadLine() ?? "";

            Console.Write("Enter model: ");
            string model = Console.ReadLine() ?? "";

            Console.Write("Enter year: ");
            int year = int.TryParse(Console.ReadLine(), out var y) ? y : 0;

            Console.Write("Enter mileage: ");
            double mileage = double.TryParse(Console.ReadLine(), out var m) ? m : 0;

            var v = new Vehicle(make, model, year, mileage);
            fleet.AddVehicle(v);
            Console.WriteLine("Vehicle added Successfully.");
        }

        //Method to remove a vehicle from the fleet
        private static void RemoveVehicleMenu(Fleet fleet)
        {
            Console.Write("Enter model to remove: ");
            string model = Console.ReadLine() ?? "";
            fleet.RemoveVehicle(model);
        }
    }
}