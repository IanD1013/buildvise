public sealed class InheritanceVehicleExample
{
    public void RunExample()
    {
        Car sedan = new() { DoorCount = 4 };
        Car coupe = new() { DoorCount = 2 };
        Truck pickupTruck = new() { DoorCount = 2 };
        Bike Bike = new();

        sedan.OpenDoors();
        coupe.OpenDoors();
        pickupTruck.OpenDoors();
        Bike.OpenDoors();
    }

    public class Vehicle
    {
        public int DoorCount { get; init; }

        public void OpenDoors()
        {
            Console.WriteLine(
                $"{GetType().Name} opening {DoorCount} doors!");
        }
    }

    public class Automobile : Vehicle
    {
    }

    public class Car : Automobile
    {
    }

    public class Truck : Automobile
    {
    }

    public class Van : Automobile
    {
    }

    public class Bike : Vehicle
    {
        public Bike()
        {
            DoorCount = 0;
        }
    }

    public class Plane : Vehicle
    {
    }
}