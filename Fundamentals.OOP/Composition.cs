public sealed class Composition
{
    public void RunExample()
    {
        // we can use the idea of composition to create an object
        // that is made up of other objects! this models an
        // "is made up of" relationship (whereas inheritance
        // models an "is a" relationship)

        // let's use composition to model a desktop computer!
        // we'll need:
        // - a case
        // - a motherboard
        // - a power supply
        // - a hard drive
        // - some RAM
        // - a graphics card
        // ... you get the idea :)

        // NOTE: we forgot to make a CPU! that's
        // probably an important part of a computer!
        Computer myComputer = new Computer(new Case(), new Motherboard(), new PowerSupply(), new HardDrive(sizeInTb: 16), new Ram(sizeInGb: 64), new GraphicsCard());
        myComputer.PowerOn();
    }

    public sealed class Case
    {
        public void PressPowerButton()
        {
            Console.WriteLine("Power button pressed");
        }
    }

    public sealed class Motherboard
    {
        public void Boot()
        {
            Console.WriteLine("Booting...");
        }
    }

    public sealed class PowerSupply
    {
        public void TurnOn()
        {
            Console.WriteLine("Power supply turned on");
        }
    }

    public sealed class HardDrive
    {
        private readonly int _sizeInTb;

        public HardDrive(int sizeInTb)
        {
            _sizeInTb = sizeInTb;
        }

        public void ReadData()
        {
            Console.WriteLine(
                $"Reading data from hard drive with capacity of {_sizeInTb} TB.");
        }
    }

    public sealed class Ram
    {
        private readonly int _sizeInGb;

        public Ram(int sizeInGb)
        {
            _sizeInGb = sizeInGb;
        }

        public void Load()
        {
            Console.WriteLine(
                $"Loading data into RAM with capacity of {_sizeInGb} GB.");
        }
    }

    public sealed class GraphicsCard
    {
        public void Render()
        {
            Console.WriteLine("Rendering graphics");
        }
    }

    public sealed class Computer
    {
        private readonly Case _theCase;
        private readonly Motherboard _motherboard;
        private readonly PowerSupply _powerSupply;
        private readonly HardDrive _hardDrive;
        private readonly Ram _ram;
        private readonly GraphicsCard _graphicsCard;

        public Computer(
            Case theCase,
            Motherboard motherboard,
            PowerSupply powerSupply,
            HardDrive hardDrive,
            Ram ram,
            GraphicsCard graphicsCard)
        {
            _theCase = theCase;
            _motherboard = motherboard;
            _powerSupply = powerSupply;
            _hardDrive = hardDrive;
            _ram = ram;
            _graphicsCard = graphicsCard;
        }

        public void PowerOn()
        {
            _theCase.PressPowerButton();
            _powerSupply.TurnOn();
            _motherboard.Boot();
            _ram.Load();
            _hardDrive.ReadData();
            _graphicsCard.Render();
        }
    }
}