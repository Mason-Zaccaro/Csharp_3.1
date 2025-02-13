using System;

namespace Task3
{
    public class PersonFactory : IFactory<Person>
    {
        public Person Create()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter age: ");
            int age;
            int.TryParse(Console.ReadLine(), out age);
            return new Person { Name = name, Age = age };
        }
    }
}
