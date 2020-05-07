using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    /// <summary>
    /// Класс, содержащий информацию о погоде
    /// </summary>
    public class WeatherResponse
    {
        /// <summary>
        /// Поле, содержащее информацию о температуре
        /// </summary>
        public TemperatureInfo Main { get; set; }

        /// <summary>
        /// Поле, содержащее название города
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Поле, содержащее информацию о ветре
        /// </summary>
        public WindInfo Wind { get; set; }
    }

    /// <summary>
    /// Класс, содержащий информацию о температуре
    /// </summary>
    public class TemperatureInfo
    {
        /// <summary>
        /// Поле, содержащее текущую температуру
        /// </summary>
        public float Temp { get; set; }
    }

    /// <summary>
    /// Класс, содержащий информацию о ветре
    /// </summary>
    public class WindInfo
    {
        /// <summary>
        /// Поле, содержащее текущее значение ветра
        /// </summary>
        public double Speed { get; set; }
    }
}
