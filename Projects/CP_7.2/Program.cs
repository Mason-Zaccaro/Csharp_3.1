using System.Collections.Generic;
using System;

namespace _7._2_КТ
{
    public abstract class Animal
    {
        public string Name { get; set; }

        public abstract void SayHello();
    }

    public class Dog : Animal
    {
        public override void SayHello()
        {
            Console.WriteLine($"Привет! Меня зовут {Name}.");
        }
    }

    public class Cat : Animal
    {
        public override void SayHello()
        {
            Console.WriteLine($"Привет! Меня зовут {Name}.");
        }
    }

    public class Program
    {
        public static void ProcessAnimals(List<Animal> animals, Action<Animal> action)
        {
            foreach (var animal in animals)
            {
                action(animal);
            }
        }

        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>
            {
                new Dog { Name = "Шарик" },
                new Cat { Name = "Тиша" },
                new Dog { Name = "Барбос" }
            };

            Console.WriteLine("Приветствие от всех животных:");
            ProcessAnimals(animals, animal => animal.SayHello());

            Console.WriteLine("\nПример ковариантности:");
            ProcessAnimals(animals, animal => Console.WriteLine($"Животное: {animal.Name}"));

            Console.WriteLine("\nПример контрвариантности:");
            ProcessAnimals(animals, animal =>
            {
                if (animal is Dog dog)
                {
                    Console.WriteLine($"Собака: {dog.Name}");
                }
            });
        }
    }
}