using System;

namespace ElevatorSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an elevator system with 3 elevators and a maximum occupancy of 10
            ElevatorSystem elevatorSystem = new ElevatorSystem(numElevators: 3, maxOccupancy: 10);

            while (true)
            {
                Console.WriteLine("Enter the floor you are currently on:");
                int currentFloor = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the floor you want to go to:");
                int targetFloor = int.Parse(Console.ReadLine());

                // Call elevator to the current floor
                elevatorSystem.CallElevator(currentFloor);

                // Set occupants on the current floor
                Console.WriteLine("Enter the number of occupants on the current floor:");
                int occupants = int.Parse(Console.ReadLine());
                elevatorSystem.SetOccupants(currentFloor, occupants);

                // Move the elevator to the target floor
                elevatorSystem.CallElevator(targetFloor);

                // Show the status of elevators
                elevatorSystem.ShowStatus();

                Console.WriteLine("Press any key to continue or 'q' to quit...");
                var input = Console.ReadLine();
                if (input.ToLower() == "q")
                    break;

                Console.Clear();
            }
        }
    }
}
