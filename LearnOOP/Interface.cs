interface IAnimal {
    void animalSound();
    //void run();
}

class cPig : IAnimal {
    public void animalSound() {
        Console.WriteLine("The pig says: wee wee");
    }
}

interface IFirstMultiInterface {
    void myMethod();
}

interface ISecondMultiInterface {
    void myOtherMethod();
}

// Implement multiple interfaces
class DemoClass : IFirstMultiInterface, ISecondMultiInterface {
    public void myMethod()
    {
        Console.WriteLine("Some text...");
    }

    public void myOtherMethod() {
        Console.WriteLine("Some other text...");
    }
}