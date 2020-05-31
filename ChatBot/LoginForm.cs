using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatBot
{
    /// <summary>
    /// Класс, представляющий собой форму авторизации
    /// </summary>
    public partial class LoginForm : Form 
    {
        /// <summary>
        /// Конструктор формы авторизации
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик события "Нажатие на кнопку"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginButton_Click(object sender, EventArgs e)
        {
            // удаляем из входящей строки пробелы и если остаётся пустая строка выдаём ошибку
            if (LoginText.Text.Trim() != "")
            {
                MainForm frm = new MainForm(); 
                MainForm.bot.LoadHistory(LoginText.Text); // загружаем историю сообщений
                frm.Show();
                frm.RestoreChat(); // восстанавливаем диалог
                this.Hide();
            }
            else MessageBox.Show("Ошибка! Введите своё имя.");
        }

        /// <summary>
        /// Вызываем LoginButton_Click при нажатии Enter с выделением на кнопке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
                LoginButton_Click(LoginButton, null);
        }

        /// <summary>
        /// Вызываем LoginButton_Click при нажатии Enter с выделением на поле ввода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
                LoginButton_Click(LoginButton, null);
        }
    }
}
