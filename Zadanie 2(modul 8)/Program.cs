using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_2_modul_8_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите путь к директории: ");
            string directoryPath = Console.ReadLine();

            try
            {
                long size = GetDirectorySize(directoryPath);
                Console.WriteLine($"Размер папки '{directoryPath}' составляет {size} байт.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static long GetDirectorySize(string path)
        {
            // Валидация пути
            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException($"Папка не существует: {path}");
            }

            long totalSize = 0;

            // Получаем список всех файлов в текущей директории
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                totalSize += new FileInfo(file).Length; // Добавляем размер файла
            }

            // Рекурсивно обрабатываем все вложенные директории
            string[] directories = Directory.GetDirectories(path);
            foreach (string directory in directories)
            {
                totalSize += GetDirectorySize(directory); // Рекурсивный вызов
            }

            return totalSize;
        }
    }
}
