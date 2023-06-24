using System;

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
}
