public sealed class Interfaces
{
    public void RunExample()
    {
        // interfaces in C# are a way to define a contract or API
        // things that implement the interface must
        // implement ALL of the members of the interface
        Car coupe = new(2);
        Car sedan = new(4);

        TestIgnition(coupe);
        TestIgnition(sedan);

        TestDoors(coupe);
        TestDoors(sedan);
    }

    void TestIgnition(IMotorized motorized)
    {
        motorized.StartEngine();
        Console.WriteLine($"Engine is running: {motorized.IsEngineRunning}");

        motorized.StopEngine();
        Console.WriteLine($"Engine is running: {motorized.IsEngineRunning}");
    }

    void TestDoors(IHasDoors hasDoors)
    {
        for (int i = 0; i < hasDoors.NumberOfDoors; i++)
        {
            hasDoors.OpenDoor(i);
            Console.WriteLine($"Door {i} is open: {hasDoors.IsDoorOpen(i)}");
        }
    }

    public class Car : IHasDoors, IMotorized
    {
        private readonly bool[] _doors;

        public Car(int numberOfDoors)
        {
            // NOTE: we're not doing any error checking here
            // or in the rest of this class...
            _doors = new bool[numberOfDoors];
        }

        public bool IsEngineRunning { get; private set; }

        public int NumberOfDoors => _doors.Length;

        public void OpenDoor(int doorIndex)
        {
            _doors[doorIndex] = true;
        }

        public void CloseDoor(int doorIndex)
        {
            _doors[doorIndex] = false;
        }

        public bool IsDoorOpen(int doorIndex)
        {
            return _doors[doorIndex];
        }

        public void StartEngine()
        {
            if (IsEngineRunning)
            {
                return;
            }

            IsEngineRunning = true;
            Console.WriteLine("Engine started!");
        }

        public void StopEngine()
        {
            if (!IsEngineRunning)
            {
                return;
            }

            IsEngineRunning = false;
            Console.WriteLine("Engine stopped!");
        }

    }

    public class Room : IHasDoors
    {
        private readonly bool[] _doors;

        public Room(int numberOfDoors)
        {
            // NOTE: we're not doing any error checking here
            // or in the rest of this class...
            _doors = new bool[numberOfDoors];
        }

        public int NumberOfDoors => _doors.Length;

        public void OpenDoor(int doorIndex)
        {
            _doors[doorIndex] = true;
        }

        public void CloseDoor(int doorIndex)
        {
            _doors[doorIndex] = false;
        }

        public bool IsDoorOpen(int doorIndex)
        {
            return _doors[doorIndex];
        }
    }


    public class Bicycle
    {
    }

    public class Motorcycle : IMotorized
    {
        public bool IsEngineRunning { get; private set; }

        public void StartEngine()
        {
            if (IsEngineRunning)
            {
                return;
            }

            IsEngineRunning = true;
            Console.WriteLine("Engine started!");
        }

        public void StopEngine()
        {
            if (!IsEngineRunning)
            {
                return;
            }

            IsEngineRunning = false;
            Console.WriteLine("Engine stopped!");
        }
    }
    
    public interface IHasDoors
    {
        int NumberOfDoors { get; }

        void OpenDoor(int doorIndex);

        void CloseDoor(int doorIndex);

        bool IsDoorOpen(int doorIndex);
    }
    
    public interface IMotorized
    {
        bool IsEngineRunning { get; }

        void StartEngine();

        void StopEngine();
    }
}
