public sealed class HeadToHead
{
    public void RunExample()
    {
        Automobile sedan = new Sedan();
        Automobile coupe = new Coupe();
        Automobile pickupTruck = new PickupTruck();
        Automobile van = new Van();

        ComposedVehicle composedSedan = new(
            new ConfigurableEngine(1.8f),
            new Dictionary<DoorPosition, IDoor>
            {
                { DoorPosition.FrontDriverSide, new StandardSwingingDoor() },
                { DoorPosition.FrontPassengerSide, new StandardSwingingDoor() },
                { DoorPosition.RearDriverSide, new StandardSwingingDoor() },
                { DoorPosition.RearPassengerSide, new StandardSwingingDoor() }
            });
        ComposedVehicle composedCoupe = new(
            new ConfigurableEngine(1.8f),
            new Dictionary<DoorPosition, IDoor>
            {
                { DoorPosition.FrontDriverSide, new StandardSwingingDoor() },
                { DoorPosition.FrontPassengerSide, new StandardSwingingDoor() }
            });
        ComposedVehicle composedPickupTruck = new(
            new V8Engine(),
            new Dictionary<DoorPosition, IDoor>
            {
                { DoorPosition.FrontDriverSide, new StandardSwingingDoor() },
                { DoorPosition.FrontPassengerSide, new StandardSwingingDoor() },
            });
        ComposedVehicle composedPickup2Truck = new(
            new V8Engine(),
            new Dictionary<DoorPosition, IDoor>
            {
                { DoorPosition.FrontDriverSide, new StandardSwingingDoor() },
                { DoorPosition.FrontPassengerSide, new StandardSwingingDoor() },
                { DoorPosition.RearDriverSide, new StandardSwingingDoor() },
                { DoorPosition.RearPassengerSide, new StandardSwingingDoor() }
            });
        ComposedVehicle composedVan = new(
            new ConfigurableEngine(3.6f),
            new Dictionary<DoorPosition, IDoor>
            {
                { DoorPosition.FrontDriverSide, new StandardSwingingDoor() },
                { DoorPosition.FrontPassengerSide, new StandardSwingingDoor() },
                { DoorPosition.RearDriverSide, new SlidingDoor() },
                { DoorPosition.RearPassengerSide, new SlidingDoor() }
            });
    }

    public enum DoorPosition
    {
        FrontDriverSide,
        FrontPassengerSide,
        RearDriverSide,
        RearPassengerSide
    }

    //
    // Inheritance
    //
    public abstract class Vehicle
    {
    }

    public abstract class Automobile : Vehicle
    {
        public abstract void StartEngine();

        public abstract void OpenDoor(DoorPosition doorPosition);
    }

    public abstract class ConfigAutomobile : Vehicle
    {
        private readonly string _engineType;

        protected ConfigAutomobile(string engineType)
        {
            _engineType = engineType;
        }

        public void StartEngine()
        {
            StartEngine(_engineType);
        }

        public abstract void OpenDoor(DoorPosition doorPosition);

        protected static void StartEngine(string engineType)
        {
            Console.WriteLine($"Starting {engineType} engine!");
        }
    }

    public abstract class Car : Automobile
    {
        public override void StartEngine()
        {
            Console.WriteLine("Car starting engine 1.8L engine!");
        }
    }

    public class Sedan : Car
    {
        public override void OpenDoor(DoorPosition doorPosition)
        {
            Console.WriteLine($"Sedan opening {doorPosition} door!");
        }
    }

    public class Coupe : Car
    {
        public override void OpenDoor(DoorPosition doorPosition)
        {
            if (doorPosition == DoorPosition.RearDriverSide ||
                doorPosition == DoorPosition.RearPassengerSide)
            {
                throw new InvalidOperationException("Coupes only have two doors!");
            }

            Console.WriteLine($"Coupe opening {doorPosition} door!");
        }
    }

    public class PickupTruck : Automobile
    {
        public override void StartEngine()
        {
            Console.WriteLine("Truck starting engine 3.6L engine!");
        }

        public override void OpenDoor(DoorPosition doorPosition)
        {
            if (doorPosition == DoorPosition.RearDriverSide ||
                doorPosition == DoorPosition.RearPassengerSide)
            {
                throw new InvalidOperationException("Coupes only have two doors!");
            }

            Console.WriteLine($"Truck opening {doorPosition} door!");
        }
    }

    public class Van : Automobile
    {
        public override void StartEngine()
        {
            Console.WriteLine("Van starting engine 3.6L engine!");
        }

        public override void OpenDoor(DoorPosition doorPosition)
        {
            if (doorPosition == DoorPosition.RearDriverSide ||
                doorPosition == DoorPosition.RearPassengerSide)
            {
                Console.WriteLine($"Van sliding open {doorPosition} door!");
            }
            else
            {
                Console.WriteLine($"Van swinging open {doorPosition} door!");
            }
        }
    }

    //
    // Composition
    //
    public interface IEngine
    {
        void Start();
    }

    public class V8Engine : IEngine
    {
        public void Start()
        {
            Console.WriteLine("Big ol' V8 engine starting!");
        }
    }

    public class ConfigurableEngine : IEngine
    {
        private readonly float _displacementInLiters;

        public ConfigurableEngine(float displacementInLiters)
        {
            _displacementInLiters = displacementInLiters;
        }

        public void Start()
        {
            Console.WriteLine($"Starting {_displacementInLiters}L engine!");
        }
    }

    public interface IDoor
    {
        void Open();
    }

    public class StandardSwingingDoor : IDoor
    {
        public void Open()
        {
            Console.WriteLine($"Swinging opening door!");
        }
    }

    public class SlidingDoor : IDoor
    {
        public void Open()
        {
            Console.WriteLine($"Sliding opening door!");
        }
    }

    public sealed class ComposedVehicle
    {
        private readonly IEngine _engine;
        private readonly IReadOnlyDictionary<DoorPosition, IDoor> _doors;

        public ComposedVehicle(IEngine engine, Dictionary<DoorPosition, IDoor> doors)
        {
            _engine = engine;
            _doors = doors;
        }

        public void StartEngine()
        {
            _engine.Start();
        }

        public void OpenDoor(DoorPosition doorPosition)
        {
            if (!_doors.TryGetValue(doorPosition, out IDoor? door))
            {
                throw new InvalidOperationException(
                    $"There is no door at position {doorPosition}!");
            }

            Console.WriteLine($"Opening {doorPosition} door...");
            door.Open();
        }
    }


    //
    // Can they co-exist?
    //
    public abstract class EngineSwapCoupe : Coupe
    {
        private readonly IEngine _engine;

        protected EngineSwapCoupe(IEngine engine)
        {
            _engine = engine;
        }

        public override void StartEngine()
        {
            _engine.Start();
        }
    }

}