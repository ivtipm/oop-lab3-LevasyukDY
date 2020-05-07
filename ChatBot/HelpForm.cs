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
    /// Класс, представляющий собой форму справки, содержащую команды чат-бота
    /// </summary>
    public partial class HelpForm : Form
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public HelpForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Закрываем HelpForm при нажатии Enter с выделением на кнопке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                this.Hide();
            }
        }

        /// <summary>
        /// При закрытии формы она скрывается
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HelpForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// Закрываем HelpForm при нажатии на кнопку "OK"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
