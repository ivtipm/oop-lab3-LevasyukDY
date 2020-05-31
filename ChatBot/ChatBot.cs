using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using Newtonsoft.Json;

namespace ChatBot
{
    /// <summary>
    /// Класс, содержащий методы для работы с чат-ботом.
    /// Здесь обработчики всех команд для чат-бота.
    /// </summary>
    public class ChatBot : AbstractChatBot
    {
        static string userName;  // имя пользователя
        static string tasksPath; // путь к файлу с текущими задачами
        string path;             // путь к файлу с историей сообщений
        static readonly List<string> tasks = new List<string>(); // хранение задач
        readonly List<string> history = new List<string>();      // хранение истории

        readonly List<Regex> regecies = new List<Regex>
        {
            new Regex(@"добавить задачу(\w*)"),
            new Regex(@"удалить задачу(\w*)"),
            new Regex(@"задачи"),
            new Regex(@"погода"),
            new Regex(@"курсы валют"),
            new Regex(@"привет\s?\,?\s?б{1}о{1}т{1}"),
            new Regex(@"(?:который час\??|сколько времени\??)"),
            new Regex(@"(?:какое сегодня число\??|число\??)"),
            new Regex(@"как дела\??"),
            new Regex(@"(?:спасибо|благодарю)"),
            new Regex(@"(?:умножь(\s)?(\d+)(\s)?на(\s)?(\d+))"),
            new Regex(@"(?:раздели(\s)?(\d+)(\s)?на(\s)?(\d+))"),
            new Regex(@"(?:сложи(\s)?(\d+)(\s)?и(\s)?(\d+))"),
            new Regex(@"(?:вычти(\s)?(\d+)(\s)?из(\s)?(\d+))")
        };

        Func<string, string> funcBuf; // буфер

        readonly List<Func<string, string>> func = new List<Func<string, string>>
        {
            AddTask,
            DeleteTask,
            CurrentTasks,
            WeatherPls,
            CBRdailyPls,
            HelloBot,
            HowTime,
            HowDate,
            HowAreYou,
            ThankYou,
            MulPls,
            DivPls,
            PlusPls,
            SubPls
        };

        /// <summary>
        /// Приветстивие
        /// </summary>
        /// <param name="question"></param>
        /// <returns> "Привет, " + userName + "!" </returns>
        static string HelloBot(string question)
        {
            return "Привет, " + userName + "!";
        }

        /// <summary>
        /// Ответ на вопрос "Который час?"
        /// </summary>
        /// <param name="question"></param>
        /// <returns> "Сейчас: " + DateTime.Now.ToString("HH:mm") </returns>
        static string HowTime(string question)
        {
            return "Сейчас: " + DateTime.Now.ToString("HH:mm");
        }

        /// <summary>
        /// Ответ на вопрос "Какое сегодня число?"
        /// </summary>
        /// <param name="question"></param>
        /// <returns> "Сегодня: " + DateTime.Now.ToString("dd.MM.yy") </returns>
        static string HowDate(string question)
        {
            return "Сегодня: " + DateTime.Now.ToString("dd.MM.yy");
        }

        /// <summary>
        /// Ответ на вопрос "Как дела?"
        /// </summary>
        /// <param name="question"></param>
        /// <returns> "Порядок!" или "Просто чудесно :)" </returns>
        static string HowAreYou(string question)
        {
            Random rnd = new Random();
            int value = rnd.Next();
            if (value % 2 == 0)
                return "Порядок!";
            else
            {
                return "Просто чудесно :)";
            }
        }

        /// <summary>
        /// Ответ на "Спасибо"
        /// </summary>
        /// <param name="question"></param>
        /// <returns> "Рад был помочь!" </returns>
        static string ThankYou(string question)
        {
            return "Рад был помочь!";
        }

        /// <summary>
        /// Умножение
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        static string MulPls(string question)
        {
            question = question.Replace(" ", ""); // удаляем все пробелы из вопроса
            question = question.Substring(question.LastIndexOf('ь') + 1); // убираем слово "умножь"
            string[] words = question.Split(new char[] { 'н', 'а' }, 
            StringSplitOptions.RemoveEmptyEntries); // разбиваем строку на две подстроки
            try
            {
                int num1 = Convert.ToInt32(words[0]);
                int num2 = Convert.ToInt32(words[1]);
                return (num1 * num2).ToString();
            }
            catch
            {
                return "Извините, не могу разобрать. Повторите, пожалуйста, ввод.";
            }
        }

        /// <summary>
        /// Деление
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        static string DivPls(string question)
        {
            question = question.Replace(" ", ""); // удаляем все пробелы из вопроса
            question = question.Substring(question.LastIndexOf('и') + 1); // убираем слово "раздели"
            string[] words = question.Split(new char[] { 'н', 'а' },
            StringSplitOptions.RemoveEmptyEntries); // разбиваем строку на две подстроки
            try
            {
                float num1 = Convert.ToInt32(words[0]);
                float num2 = Convert.ToInt32(words[1]);
                return (num1 / num2).ToString();
            }
            catch
            {
                return "Извините, не могу разобрать. Повторите, пожалуйста, ввод.";
            }
        }

        /// <summary>
        /// Сложение
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        static string PlusPls(string question)
        {
            question = question.Replace(" ", ""); // удаляем все пробелы из вопроса
            question = question.Substring(question.LastIndexOf('ж') + 2); // убираем слово "сложи"
            string[] words = question.Split(new char[] { 'и' },
            StringSplitOptions.RemoveEmptyEntries); // разбиваем строку на две подстроки
            try
            {
                int num1 = Convert.ToInt32(words[0]);
                int num2 = Convert.ToInt32(words[1]);
                return (num1 + num2).ToString();
            }
            catch
            {
                return "Извините, не могу разобрать. Повторите, пожалуйста, ввод.";
            }
        }

        /// <summary>
        /// Вычитание
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        static string SubPls(string question)
        {
            question = question.Replace(" ", ""); // удаляем все пробелы из вопроса
            question = question.Substring(question.LastIndexOf('т') + 2); // убираем слово "вычти"
            string[] words = question.Split(new char[] { 'и', 'з' },
            StringSplitOptions.RemoveEmptyEntries); // разбиваем строку на две подстроки
            try
            {
                int num1 = Convert.ToInt32(words[0]);
                int num2 = Convert.ToInt32(words[1]);
                return (num2 - num1).ToString();
            }
            catch
            {
                return "Извините, не могу разобрать. Повторите, пожалуйста, ввод.";
            }
        }

        /// <summary>
        /// Вывод текущих задач из файла
        /// </summary>
        /// <param name="question"></param>
        /// <returns> Список задач </returns>
        static string CurrentTasks(string question)
        {
            tasksPath = userName + "_tasks.txt"; // путь к файлу с задачами

            if (File.Exists(tasksPath)) // проверка на наличие файла
            {
                // считываем все строки из файла
                String[] str = File.ReadAllLines(tasksPath, Encoding.GetEncoding(1251));
                    
                string finalLine = "";
                for (int i = 0; i <= str.Length - 1; i++)
                {
                    finalLine += str[i] + Environment.NewLine;
                }

                return "Твои задачи на сегодня:" + Environment.NewLine + finalLine;
                    
            }
            else return "Сначала добавь что-нибудь!";
        }

        /// <summary>
        /// Добавление новой задачи
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        static string AddTask(string question)
        {
            tasksPath = userName + "_tasks.txt"; // путь к файлу с задачами
            if (question.Length >= 16)
            {
                String[] task = new String[] { " - " + question.Substring(16) };

                // если файл не существует, то создаём пустой
                if (!File.Exists(tasksPath)) 
                {
                    String[] empty = new String[] {};
                    File.WriteAllLines(tasksPath, empty, Encoding.GetEncoding(1251));
                }

                tasks.AddRange(task); // добавляем в список новую задачу
                File.WriteAllLines(tasksPath, tasks.ToArray(), Encoding.GetEncoding(1251));

                return "Задача \"" + question.Substring(16) + "\" добавлена.";
            }
            else return "Не удалось добавить задачу! Неккоректный ввод.";
        }

        /// <summary>
        /// Удаление задачи
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        static string DeleteTask(string question)
        {
            tasksPath = userName + "_tasks.txt"; // путь к файлу с задачами

            if (question.Length >= 15)
            {
                String task = " - " + question.Substring(15);

                // проверка на существование файла со списком задач
                if (!File.Exists(tasksPath)) return "У вас нет текущих задач!";

                if (tasks.Contains(task)) // если список задач содержит удаляемую задачу
                {
                    tasks.Remove(task); // убираем из списка удаляемую задачу
                    File.WriteAllLines(tasksPath, tasks.ToArray(), Encoding.GetEncoding(1251));

                    return "Задача \"" + question.Substring(15) + "\" удалена.";
                }
                else return "Такой задачи не существует!";
            }
            else return "Не удалось удалить задачу! Неккоректный ввод.";
        }

        /// <summary>
        /// Запрос на проверку погоды
        /// </summary>
        /// <param name="question"></param>
        /// <returns> Информацию о погоде </returns>
        static string WeatherPls(string question)
        {
            String[] infoWeather = FindOutWeather(); // возвращает массив строк с информацией о погоде
            if (infoWeather[0] != null) // если null, значит отсутствет подключение к интернету
            {
                return "Температура в городе " + infoWeather[0] + " " + infoWeather[1] + " °C"
                    + ", ветер " + infoWeather[2] + " м/c";
            }
            else return "Проверьте подключение к интернету!";
        }

        /// <summary>
        /// Запрос на проверку курсов валют
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        static string CBRdailyPls(string question)
        {
            String[] infoCBR = FindOutCBR(); // возвращает массив строк с информацией о курсах валют
            if (infoCBR[0] != null) // если null, значит отсутствет подключение к интернету
                return infoCBR[0] + ": " + infoCBR[1] + "; " +  // USD name + value
                    infoCBR[2] + ": " + infoCBR[3] + "; " +     // EUR name + value
                    infoCBR[4] + ": " + infoCBR[5];             // CNY name + value
            else return "Проверьте подключение к интернету!";
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public ChatBot() { }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="filename"></param>
        public ChatBot(string filename) { LoadHistory(filename); }

        /// <summary>
        /// Геттер имени пользователя
        /// </summary>
        public string UserName { get { return userName; } }

        /// <summary>
        /// Геттер пути к файлу с историей сообщений
        /// </summary>
        public string Path { get { return path; } }

        /// <summary>
        /// Геттер истории сообщений
        /// </summary>
        public List<string> History { get { return history; } }

        /// <summary>
        /// Загрузка истории из файла
        /// </summary>
        /// <param name="user"></param>
        public void LoadHistory(string user)
        {
            userName = user; // имя пользователя
            path = userName + ".txt"; // путь к файлу с историей сообщений

            try
            {
                // попытка загрузки существующей базы
                history.AddRange(File.ReadAllLines(path, Encoding.GetEncoding(1251)));

                // если файл был изменен не сегодня, то записываем новую дату переписки
                if (File.GetLastWriteTime(path).ToString("dd.MM.yy") !=
                    DateTime.Now.ToString("dd.MM.yy"))
                {
                    String[] date = new String[] {"\n\t\t\t" + 
                        DateTime.Now.ToString("dd.MM.yy"+ "\n")};
                    AddToHistory(date);
                }
            }
            catch
            {
                // если файл не существует, создаем его
                File.WriteAllLines(path, history.ToArray(), Encoding.GetEncoding(1251));
                // отмечаем дату начала переписки
                String[] date = new String[] {"\t\t\t" + 
                    DateTime.Now.ToString("dd.MM.yy")};
                AddToHistory(date);
            }
        }

        /// <summary>
        /// Добавление переписки в файл
        /// </summary>
        /// <param name="answer"></param>
        public void AddToHistory(string[] answer)
        {
            history.AddRange(answer);
            File.WriteAllLines(path, history.ToArray(), Encoding.GetEncoding(1251));
        }

        /// <summary>
        /// Запрос информации о погоде
        /// </summary>
        /// <returns></returns>
        static private String[] FindOutWeather()
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q=" + 
                "Chita" + // <- здесь можно вставить любой город
                "&units=metric&appid=2856fc0f74411cd143093c7ac9b9a7a0";

            // инициализация WebRequest
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            try
            {
                // возврат ответа от интернет-ресурса
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            
                string responce;
                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    responce = streamReader.ReadToEnd();
                }

                // конвертируем тип JSON в .NET тип
                WeatherResponse weather = JsonConvert.DeserializeObject<WeatherResponse>(responce);

                String[] infoWeather = { weather.Name, 
                                        weather.Main.Temp.ToString(), 
                                        weather.Wind.Speed.ToString() };
                return infoWeather;

            }
            catch
            {
                // в случае возникновения ошибки возвращаем пустой массив
                String[] error = { null }; 
                return error;
            }
        }

        /// <summary>
        /// Запрос информации о курсе валют
        /// </summary>
        /// <returns></returns>
        static private String[] FindOutCBR()
        {
            string url = "https://www.cbr-xml-daily.ru/daily_json.js";

            // инициализация WebRequest
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            try
            {
                // возврат ответа от интернет-ресурса
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                string response;
                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                }

                // конвертируем тип JSON в .NET тип
                CBRdailyResponse cbr = JsonConvert.DeserializeObject<CBRdailyResponse>(response);

                String[] infoCBR = { cbr.Valute.USD.Name, cbr.Valute.USD.Value.ToString(),
                                    cbr.Valute.EUR.Name, cbr.Valute.EUR.Value.ToString(),
                                    cbr.Valute.CNY.Name, cbr.Valute.CNY.Value.ToString() };
                return infoCBR;
            }
            catch
            {
                // в случае возникновения ошибки возвращаем пустой массив
                String[] error = { null };
                return error;
            }
        }

        /// <summary>
        /// Переопределённый метод ответа пользователю
        /// </summary>
        /// <param name="userQuestion"></param>
        /// <returns></returns>
        public override string Answer(string userQuestion)
        {
            userQuestion = userQuestion.ToLower(); // переводим в нижний регистр

            for (int i = 0; i < regecies.Count; i++) // проходим по регулярным выражениям
            {
                if (regecies[i].IsMatch(userQuestion)) // ищем подходящее регулярное выражение
                {
                    funcBuf = func[i]; // сохраняем функцию по найденому индексу в буфер
                    return funcBuf(userQuestion); // возвращаем результат выполнения этой функции
                }
            }
            return "Извините, я вас не понимаю";
        }
    }
}
