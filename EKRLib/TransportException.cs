using System;
using System.Collections.Generic;
using System.Text;

namespace EKRLib
{
    /// <summary>
    /// Класс исключения, произошедшего с транспортом.
    /// </summary>
    [Serializable]
    public class TransportException : Exception
    {
        /// <summary>
        /// Конструктор исключения без параметра.
        /// </summary>
        public TransportException() { }

        /// <summary>
        /// Конструктор исключения.
        /// </summary>
        /// <param name="message">Сообщение исключения.</param>
        public TransportException(string message) : base("Transport exception: " + message) { }

        /// <summary>
        /// Конструктор исключения.
        /// </summary>
        /// <param name="message">Сообщение исключения.</param>
        /// <param name="inner">Вложенное исключение.</param>
        public TransportException(string message, Exception inner) : base("Transport exception: " + message, inner) { }
        
        /// <summary>
        /// Конструктор исключения.
        /// </summary>
        /// <param name="info">Информация.</param>
        /// <param name="context">Контекст.</param>
        protected TransportException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
