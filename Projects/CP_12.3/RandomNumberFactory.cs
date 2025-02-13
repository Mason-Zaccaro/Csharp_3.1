using System;

namespace Task3
{
    public class RandomNumberFactory : IFactory<int>
    {
        private Random random = new Random();
        public int Create()
        {
            return random.Next(0, 100); // случайное число от 0 до 99
        }
    }
}
