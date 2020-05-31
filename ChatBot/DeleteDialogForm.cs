using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ChatBot
{
    /// <summary>
    /// Класс, представляющий собой форму подтверждения удаления истории сообщений
    /// </summary>
    public partial class DeleteDialogForm : Form
    {
        /// <summary>
        /// Класс, содержащий ссылку на метод изменения текста в TextBox
        /// </summary>
        /// <param name="nText"></param>
        public delegate void ChangeTextBox(String nText);

        /// <summary>
        /// Объявление события изменения текста в TextBox
        /// </summary>
        public event ChangeTextBox ChangeTextBox1;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="MF"></param>
        public DeleteDialogForm(MainForm MF)
        {
            InitializeComponent();
            ChangeTextBox1 += MF.ChangeTextInTextBox;
        }

        /// <summary>
        /// При закрытии формы удаления истории сообщений - скрываем её
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteDialogForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// При нажатии Enter с выделением на кнопке "Нет" - скрываем форму
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NoButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                this.Hide();
            }
        }

        /// <summary>
        /// При нажатии Enter с выделением на кнопке "Да" - удаляем историю сообщений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void YesButton_KeyDown(object sender, KeyEventArgs e)
        {
            // заполняем файл пустотой
            File.WriteAllText(MainForm.bot.Path, string.Empty);

            MainForm.bot.History.Clear(); // очищаем историю сообщений

            String[] date = new String[] {"\n\t\t\t" +
                        DateTime.Now.ToString("dd.MM.yy"+ "\n")};
            MainForm.bot.AddToHistory(date);

            ChangeTextBox1(date[0]); // обновляем TextBox
            this.Hide();
        }

        /// <summary>
        /// При нажатии на кнопку "Да" - удаляем историю сообщений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void YesButton_Click(object sender, EventArgs e)
        {
            // заполняем файл пустотой
            File.WriteAllText(MainForm.bot.Path, string.Empty);

            MainForm.bot.History.Clear(); // очищаем историю сообщений

            String[] date = new String[] {"\n\t\t\t" +
                        DateTime.Now.ToString("dd.MM.yy"+ "\n")};
            MainForm.bot.AddToHistory(date);

            ChangeTextBox1(date[0]); // обновляем TextBox
            this.Hide();
        }
    }
}
