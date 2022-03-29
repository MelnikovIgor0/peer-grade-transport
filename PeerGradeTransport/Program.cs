using EKRLib;
using System;
using System.Collections.Generic;
using System.IO;

namespace PeerGradeTransport
{
    /// <summary>
    /// Основной класс программы.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Метод генерирует имя модели в соответствии со спецификацией.
        /// </summary>
        /// <returns>Строку, имя модели.</returns>
        public static string GenerateModel()
        {
            List<char> availableCharacters = new();
            for (char c = 'A'; c <= 'Z'; c++) availableCharacters.Add(c);
            for (char c = '0'; c <= '9'; c++) availableCharacters.Add(c);
            Random rnd = new Random();
            string model = "";
            for (int i = 0; i < 5; i++) model += availableCharacters[rnd.Next(0, availableCharacters.Count)];
            return model;
        }

        /// <summary>
        /// Метод создает машину или лодку со случайными параметрами, вероятности создания машины и лодки равны.
        /// Также метод выводит исключения, которые произошли при попытке создания объекта.
        /// </summary>
        /// <returns>Машину или лодку, тут как повезет.</returns>
        public static Transport GenerateTransport()
        {
            Random rnd = new Random();
            Transport transport = null;
            if (rnd.NextDouble() < 0.5)
            {
                while (transport is null)
                {
                    try
                    {
                        transport = new Car(GenerateModel(), (uint)rnd.Next(10, 100));
                        break;
                    }
                    catch (TransportException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            else
            {
                while (transport is null)
                {
                    try
                    {
                        transport = new MotorBoat(GenerateModel(), (uint)rnd.Next(10, 100));
                        break;
                    }
                    catch (TransportException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return transport;
        }

        /// <summary>
        /// Метод создает массив машин и лодок случаной длины со случайными параметрами.
        /// Также метод выводит созданный объект и издаваемый им звук.
        /// </summary>
        /// <returns>Массив машин и лодок.</returns>
        public static Transport[] GenerateArrayOfTransport()
        {
            Random rnd = new Random();
            int amountTransport = rnd.Next(6, 10);
            Transport[] transports = new Transport[amountTransport];
            for (int i = 0; i < amountTransport; i++)
            {
                transports[i] = GenerateTransport();
                Console.WriteLine(transports[i]);
                Console.WriteLine(transports[i].StartEngine());
            }
            return transports;
        }

        /// <summary>
        /// Метод сохраняет все машины из списка в указанный файл.
        /// </summary>
        /// <param name="transports">Массив лодок и машин.</param>
        /// <param name="path">Путь к файлу, куда нужно сохранять.</param>
        public static void SaveCars(Transport[] transports, string path)
        {
            List<string> lines = new();
            foreach (var t in transports)
                if (t.GetType() == new Car("ABOBA", 99).GetType()) lines.Add(t.ToString());
            try
            {
                File.WriteAllLines(path, lines.ToArray(), System.Text.Encoding.Unicode);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Метод сохраняет все лодки из списка в указанный файл.
        /// </summary>
        /// <param name="transports">Массив лодок и машин.</param>
        /// <param name="path">Путь к файлу, куда нужно сохранять.</param>
        public static void SaveMotorBoats(Transport[] transports, string path)
        {
            List<string> lines = new();
            foreach (var t in transports)
                if (t.GetType() == new MotorBoat("ABOBA", 99).GetType()) lines.Add(t.ToString());
            try
            {
                File.WriteAllLines(path, lines.ToArray(), System.Text.Encoding.Unicode);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
            }
        }

        public static bool CheckRestart()
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "y") return true;
                if (line == "n") return false;
            }
        }

        /// <summary>
        /// Основной метод программы.
        /// </summary>
        /// <param name="args">Аргументы.</param>
        static void Main(string[] args)
        {
            while (true)
            {
                Transport[] transports = GenerateArrayOfTransport();
                try
                {
                    char sep = Path.DirectorySeparatorChar;
                    SaveCars(transports, $"..{sep}..{sep}..{sep}..{sep}Cars.txt");
                    SaveMotorBoats(transports, $"..{sep}..{sep}..{sep}..{sep}MotorBoats.txt");
                }
                catch (Exception)
                {
                }
                Console.WriteLine("Restart program (file will be rewritten)?(y/n)");
                if (!CheckRestart()) break;
            }
        }
    }
}
