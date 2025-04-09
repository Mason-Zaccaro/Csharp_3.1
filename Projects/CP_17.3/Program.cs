using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace CP_17._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var image = new BitmapImage())
            {
                image.Load("images/input.bmp");
                image.Save("images/output.bmp");
            } // Dispose() будет вызван автоматически здесь
        }
    }
    public class BitmapImage : IDisposable
    {
        private Bitmap _bitmap;
        private bool _disposed = false;

        // Метод для загрузки изображения из файла
        public void Load(string path)
        {
            EnsureNotDisposed();

            // Освобождаем предыдущее изображение, если оно есть
            _bitmap?.Dispose();
            _bitmap = new Bitmap(path);
        }

        // Метод для сохранения изображения в файл
        public void Save(string path)
        {
            EnsureNotDisposed();

            if (_bitmap == null)
                throw new InvalidOperationException("Изображение не загружено");

            _bitmap.Save(path, ImageFormat.Bmp);
        }

        // Реализация IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Освобождаем управляемые ресурсы
                    _bitmap?.Dispose();
                }
                _disposed = true;
            }
        }

        private void EnsureNotDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(BitmapImage));
        }
    }
}
