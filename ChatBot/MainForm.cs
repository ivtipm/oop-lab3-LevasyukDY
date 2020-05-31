using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatBot
{
    /// <summary>
    /// Главная форма чат-бота, всё общение происходит здесь
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Через этот объект обращаемся к методам из класса ChatBot
        /// </summary>
        static public ChatBot bot = new ChatBot();

        /// <summary>
        /// Конструктор
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик событий для возможности управления компонентом TextBox с формы DeleteDialogForm
        /// </summary>
        /// <param name="newText"></param>
        public void ChangeTextInTextBox(String newText)
        {
            ChatText.Text = newText; 
        }

        /// <summary>
        /// Метод, восстанавливающий историю сообщений в TextBox
        /// </summary>
        public void RestoreChat()
        {
            for (int i = 0; i < bot.History.Count; i++)
                ChatText.Text += bot.History[i] + Environment.NewLine;
        }

        /// <summary>
        /// Обновление текста и перевод каретки в конец
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChatText_TextChanged(object sender, EventArgs e)
        {
            ChatText.SelectionStart = ChatText.Text.Length;
            ChatText.ScrollToCaret();
            ChatText.Refresh();
        }

        /// <summary>
        /// При закрытии формы - выход из приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Обработчик для кнопки отправки сообщения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendButton_Click(object sender, EventArgs e)
        {
            if (SendText.Text.Trim() != "")
            {
                String[] userQuestion = SendText.Text.Split(new String[] { "\r\n" },
                    StringSplitOptions.RemoveEmptyEntries);

                string message = userQuestion[0]; // для отправки боту

                userQuestion[0] = userQuestion[0].Insert(0,
                    "[" + DateTime.Now.ToString("HH:mm") + "] " + bot.UserName + ": ");

                bot.AddToHistory(userQuestion); // добавляем вопрос в файл

                ChatText.AppendText(userQuestion[0] + "\r\n");
                SendText.Text = ""; // очищаем поле отправки

                string[] botAnswer = new string[] { bot.Answer(message) };
                botAnswer[0] = botAnswer[0].Insert(0,
                    "[" + DateTime.Now.ToString("HH:mm") + "] Бот: ");

                ChatText.AppendText(botAnswer[0] + Environment.NewLine);

                bot.AddToHistory(botAnswer); // добавляем ответ бота в файл
            }
        }

        /// <summary>
        /// При нажатии Enter с выделением на форме - отправка сообщения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
                SendButton_Click(SendButton, null);
        }

        /// <summary>
        /// При нажатии Enter с выделением на поле ввода - отправка сообщения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
                SendButton_Click(SendButton, null);
        }

        /// <summary>
        /// Обработчик нажатия на иконку помощи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HelpImage_Click(object sender, EventArgs e)
        {
            HelpForm frm = new HelpForm();
            frm.Show(); // открываем форму помощи
        }

        /// <summary>
        /// Обработчик нажатия на иконку очистки диалога
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteDialogImage_Click(object sender, EventArgs e)
        {
            DeleteDialogForm frm = new DeleteDialogForm(this);
            frm.Show(); // открываем форму удаления диалога
        }
    }
}
