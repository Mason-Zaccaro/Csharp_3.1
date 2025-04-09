using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP_17._1
{
    class Program
    {
        static void Main()
        {
            string filePath = "example.txt";

            // Запись тестовых данных в файл для демонстрации
            File.WriteAllText(filePath, "Test");

            using (var reader = new FileReader(filePath))
            {
                string content = reader.ReadToEnd();
                Console.WriteLine("Содержимое файла:");
                Console.WriteLine(content);
            } // Здесь автоматически вызывается Dispose()
        }
    }
    public class FileReader : IDisposable
    {
        private StreamReader _reader;
        private bool _disposed = false;

        public FileReader(string filePath)
        {
            _reader = new StreamReader(filePath);
        }

        public string ReadLine()
        {
            if (_disposed)
                throw new ObjectDisposedException("FileReader");

            return _reader.ReadLine();
        }

        public string ReadToEnd()
        {
            if (_disposed)
                throw new ObjectDisposedException("FileReader");

            return _reader.ReadToEnd();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing && _reader != null)
                {
                    _reader.Dispose();
                }
                _disposed = true;
            }
        }

        FileReader()
        {
            Dispose(false);
        }
    }
}
