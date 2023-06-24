using System;
using System.Collections.Generic;

namespace ElevatorSimulation
{
    public class ElevatorSystem
    {
        private List<Elevator> elevators;

        public ElevatorSystem(int numElevators, int maxOccupancy)
        {
            elevators = new List<Elevator>();

            for (int i = 0; i < numElevators; i++)
            {
                var elevator = new Elevator(maxOccupancy);
                elevators.Add(elevator);
            }
        }

        public void CallElevator(int floor)
        {
            Elevator nearestElevator = null;
            int minDistance = int.MaxValue;

            foreach (var elevator in elevators)
            {
                if (!elevator.IsMoving && Math.Abs(elevator.CurrentFloor - floor) < minDistance)
                {
                    nearestElevator = elevator;
                    minDistance = Math.Abs(elevator.CurrentFloor - floor);
                }
            }

            if (nearestElevator != null)
            {
                nearestElevator.MoveToFloor(floor);
            }
        }

        public void SetOccupants(int floor, int occupants)
        {
            foreach (var elevator in elevators)
            {
                if (elevator.CurrentFloor == floor)
                {
                    while (elevator.Occupancy < occupants)
                    {
                        elevator.AddOccupant();
                    }

                    while (elevator.Occupancy > occupants)
                    {
                        elevator.RemoveOccupant();
                    }
                }
            }
        }

        public void ShowStatus()
        {
            foreach (var elevator in elevators)
            {
                Console.WriteLine($"Elevator at floor {elevator.CurrentFloor}, " +
                                  $"occupancy: {elevator.Occupancy}/{elevator.MaxOccupancy}, " +
                                  $"moving: {elevator.IsMoving}, direction: {elevator.CurrentDirection}");
            }
        }
    }
}
