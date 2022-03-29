using System;
using System.Collections.Generic;
using System.Text;

namespace EKRLib
{
    /// <summary>
    /// Класс лодки, наследуемый от транспорта.
    /// </summary>
    public class MotorBoat : Transport
    {
        /// <summary>
        /// Конструктор лодки.
        /// </summary>
        /// <param name="transportModel">Модель лодки.</param>
        /// <param name="transportPower">Мощность лодки.</param>
        public MotorBoat(string transportModel, uint transportPower) : base(transportModel, transportPower)
        {
        }

        /// <summary>
        /// Метод возвращает строковое описание объекта.
        /// </summary>
        /// <returns>Строка, строковое описание объекта.</returns>
        public override string ToString() => "Motorboat. " + base.ToString();

        /// <summary>
        /// Метод возаращает модель лодки и звук, издаваемый лодкой.
        /// </summary>
        /// <returns>Строковое значение, модель и звук лодки.</returns>
        public override string StartEngine() => $"{base.Model}: Brrrbrr";
    }
}
