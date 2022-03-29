using System;
using System.Collections.Generic;
using System.Text;

namespace EKRLib
{
    /// <summary>
    /// Абстрактный класс транспорта.
    /// </summary>
    public abstract class Transport
    {
        /// <summary>
        /// Модель транспорта.
        /// </summary>
        private string model;

        /// <summary>
        /// Мощность транспорта (в лошадиных силах).
        /// </summary>
        private uint power;

        /// <summary>
        /// Свойство, возвращает модель транспорта, кидает исключение при попытке задать некорректную модель.
        /// </summary>
        public string Model 
        {
            get => model;
            set
            {
                if (value.Length != 5) throw new TransportException($"Unavailable model: {value}");
                foreach (char symbol in value)
                    if (!((symbol >= 'A' && symbol <= 'Z') || (symbol >= '0' && symbol <= '9')))
                        throw new TransportException($"Unavailable model: {value}");
                model = value;
            }
        }

        /// <summary>
        /// Свойство, возвращает мощность транспорта (в лошадиных силах), 
        /// кидает исключение при попытке задать некорректную мощность.
        /// </summary>
        public uint Power
        {
            get => power;
            set
            {
                if (value < 20) throw new TransportException("Power cannot be less than 20 horsepower");
                power = value;
            }
        }

        /// <summary>
        /// Метод возвращает строковое описание объекта.
        /// </summary>
        /// <returns>Строка, строковое описание объекта.</returns>
        public override string ToString() => $"Model: {Model}, Power: {Power}";

        /// <summary>
        /// Метод возвращает звук, издаваемый транспортом.
        /// </summary>
        /// <returns>Строковое значение, звук транспорта.</returns>
        public abstract string StartEngine();

        /// <summary>
        /// Конструктор транспорта.
        /// </summary>
        /// <param name="transportModel">Модель транспорта.</param>
        /// <param name="transportPower">Мощность транспорта.</param>
        public Transport(string transportModel, uint transportPower)
        {
            Model = transportModel;
            Power = transportPower;
        }
    }
}
