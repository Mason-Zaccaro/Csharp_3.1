﻿namespace Task3
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public override string ToString() => $"Person: {Name}, {Age} years old";
    }
}
