using System;
using System.Collections.Generic;

namespace ElevatorSimulation
{
    public enum Direction
    {
        Up,
        Down
    }

    public class Elevator
    {
        public int CurrentFloor { get; private set; }
        public Direction CurrentDirection { get; private set; }
        public bool IsMoving { get; private set; }
        public int Occupancy { get; private set; }
        public int MaxOccupancy { get; private set; }

        public Elevator(int maxOccupancy)
        {
            CurrentFloor = 1;
            CurrentDirection = Direction.Up;
            IsMoving = false;
            Occupancy = 0;
            MaxOccupancy = maxOccupancy;
        }

        public void MoveToFloor(int targetFloor)
        {
            if (targetFloor == CurrentFloor)
                return;

            IsMoving = true;
            CurrentDirection = targetFloor > CurrentFloor ? Direction.Up : Direction.Down;

            Console.WriteLine($"Elevator is moving {CurrentDirection.ToString().ToLower()} from floor {CurrentFloor} to floor {targetFloor}");

            while (CurrentFloor != targetFloor)
            {
                if (CurrentDirection == Direction.Up)
                    CurrentFloor++;
                else
                    CurrentFloor--;

                Console.WriteLine($"Elevator is now at floor {CurrentFloor}");
            }

            IsMoving = false;
        }

        public void AddOccupant()
        {
            if (Occupancy < MaxOccupancy)
                Occupancy++;
        }

        public void RemoveOccupant()
        {
            if (Occupancy > 0)
                Occupancy--;
        }
    }

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

    class Program
    {
        static void Main(string[] args)
        {
            // Create an elevator system with 3 elevators and a maximum occupancy of 10
            ElevatorSystem elevatorSystem = new ElevatorSystem(numElevators: 3, maxOccupancy: 10);

            // Call elevator to floor 5
            elevatorSystem.CallElevator(5);

            // Set 3 occupants on floor 3
            elevatorSystem.SetOccupants(3, 3);

            // Show the status of elevators
            elevatorSystem.ShowStatus();
        }
    }
}
