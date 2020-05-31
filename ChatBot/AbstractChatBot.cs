using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    /// <summary>
    /// Абстрактный класс для переопределения метода Answer
    /// </summary>
    public abstract class AbstractChatBot
    {
        /// <summary>
        /// Абстрактный метод
        /// </summary>
        /// <param name="userQuestion"></param>
        /// <returns> Ответ на пользовательский вопрос </returns>
        public abstract string Answer(string userQuestion);
    }
}
