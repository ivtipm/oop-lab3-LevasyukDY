using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    /// <summary>
    /// Класс, содержащий данные о курсе валют
    /// </summary>
    public class CBRdailyResponse
    {
        /// <summary>
        /// Поле, содержащее информацию о волюте
        /// </summary>
        public CBRdailyInfo Valute { get; set; }
    }

    /// <summary>
    /// Класс, содержащий валюты и информацию о них
    /// </summary>
    public class CBRdailyInfo
    {
        /// <summary>
        /// Информация о долларе США
        /// </summary>
        public ValuteInfo USD { get; set; }

        /// <summary>
        /// Информация о евро
        /// </summary>
        public ValuteInfo EUR { get; set; }

        /// <summary>
        /// Информация о китайском юане
        /// </summary>
        public ValuteInfo CNY { get; set; }
    }

    /// <summary>
    /// Класс, содержащий название валюты и её текущее значение
    /// </summary>
    public class ValuteInfo
    {
        /// <summary>
        /// Поле, содержащее название валюты
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Поле, содержащее значение валюты
        /// </summary>
        public float Value { get; set; }
    }
}
