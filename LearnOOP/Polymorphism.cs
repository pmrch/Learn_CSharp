class Animal {
    public virtual void animalSound() {
        Console.WriteLine("The animal makes a sound");
    }
}

class Pig : Animal {
    public override void animalSound() {
        Console.WriteLine("The pig says: wee wee");
    }
}

class Dog : Animal {
    public override void animalSound() {
        Console.WriteLine("The dog says: bow wow");
    }
}