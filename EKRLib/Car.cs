using System;
using System.Collections.Generic;
using System.Text;

namespace EKRLib
{
    /// <summary>
    /// Класс машины, наследуемый от транспорта.
    /// </summary>
    public class Car : Transport
    {
        /// <summary>
        /// Конструктор машины.
        /// </summary>
        /// <param name="transportModel">Модель машины.</param>
        /// <param name="transportPower">Мощность машины.</param>
        public Car(string transportModel, uint transportPower) : base(transportModel, transportPower)
        {
        }

        /// <summary>
        /// Метод возвращает строковое описание объекта.
        /// </summary>
        /// <returns>Строка, строковое описание объекта.</returns>
        public override string ToString() => "Car. " + base.ToString();

        /// <summary>
        /// Метод возаращает модель машины и звук, издаваемый машиной.
        /// </summary>
        /// <returns>Строковое значение, модель и звук машины.</returns>
        public override string StartEngine() => $"{base.Model}: Vroom";
    }
}
