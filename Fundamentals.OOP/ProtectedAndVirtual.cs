public sealed class ProtectedAndVirtual
{
    public void RunExample()
    {
        // what if we don't want our base class
        // to have methods that EVERYONE can use?
        // what if we want to limit it?
        // ... protected!

        DerivedClass derivedClass = new DerivedClass();
        derivedClass.PrintInDerivedClass();

        DerivedClass2 derivedClass2 = new DerivedClass2();
        derivedClass2.PrintInDerivedClass();
        derivedClass2.VirtualPrintInBaseClass();
    }

    class BaseClass2
    {
        protected void PrintInBaseClass()
        {
            Console.WriteLine("PrintInBaseClass");
        }

        // we can also use the virtual keyword to give us
        // a hybrid between abstract and non-abstract.
        // ... what does that even mean?!
        public virtual void VirtualPrintInBaseClass()
        {
            Console.WriteLine("VirtualPrintInBaseClass");
        }
    }

    class DerivedClass2 : BaseClass2
    {
        public void PrintInDerivedClass()
        {
            Console.WriteLine("PrintInDerivedClass... then base!");
            PrintInBaseClass();
        }

        public override void VirtualPrintInBaseClass()
        {
            Console.WriteLine("VirtualPrintInBaseClass in the derived class");
            Console.WriteLine("... and now we'll call the base class method!");
            base.VirtualPrintInBaseClass(); // in this case must use "base"
        }
    }

    /// <summary>
    /// /////////////////////////////////////////////////////////////////////////////
    /// </summary>
    abstract class AbstractBaseClass
    {
        protected void ProtectedPrintInBaseClass()
        {
            Console.WriteLine("ProtectedPrintInBaseClass");
        }

        protected abstract void ProtectedAbstractPrint();
    }

    class DerivedClass : AbstractBaseClass
    {
        public void PrintInDerivedClass()
        {
            Console.WriteLine("We're in the derived class!");
            ProtectedPrintInBaseClass();
            Console.WriteLine("We're leaving the method in the derived class!");
        }

        protected override void ProtectedAbstractPrint()
        {
            Console.WriteLine("ProtectedAbstractPrint");
        }
    }
}