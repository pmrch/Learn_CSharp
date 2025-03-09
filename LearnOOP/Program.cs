namespace LearnOOP;

class Program
{
    static void Main(string[] args)
    {
        Car myCar = new Car();
        myCar.honk();

        Console.WriteLine($"{myCar.brand} {myCar.modelName}\n");

        Animal myAnimal = new Animal();
        Animal myPig = new Pig();
        Animal myDog = new Dog();

        myAnimal.animalSound();
        myPig.animalSound();
        myDog.animalSound();

        Console.WriteLine();

        cPig myPig2 = new cPig();
        myPig2.animalSound();

        Console.WriteLine();

        DemoClass myObj = new DemoClass();
        myObj.myMethod();
        myObj.myOtherMethod();

        Console.WriteLine();

        Level myVar = Level.Medium;
        Console.WriteLine(myVar);
        Console.WriteLine();
        
        // We can also output the number value from enum
        int  myNum = (int) Months.April;
        Console.WriteLine(myNum);
        Console.WriteLine();

        // We can use it for value checking too
        switch (myVar) {
            case Level.Low: Console.WriteLine("Low Level"); break;
            case Level.Medium: Console.WriteLine("Medium Level"); break;
            case Level.High: Console.WriteLine("High Level"); break;
        }
    }
}
