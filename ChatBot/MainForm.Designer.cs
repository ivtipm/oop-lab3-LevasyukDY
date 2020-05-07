namespace ChatBot
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.SendButton = new System.Windows.Forms.Button();
            this.ChatText = new System.Windows.Forms.TextBox();
            this.SendText = new System.Windows.Forms.TextBox();
            this.HelpImage = new System.Windows.Forms.PictureBox();
            this.DeleteDialogImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.HelpImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteDialogImage)).BeginInit();
            this.SuspendLayout();
            // 
            // SendButton
            // 
            this.SendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SendButton.Location = new System.Drawing.Point(453, 373);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(103, 27);
            this.SendButton.TabIndex = 1;
            this.SendButton.Text = "Отправить";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // ChatText
            // 
            this.ChatText.BackColor = System.Drawing.SystemColors.Window;
            this.ChatText.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChatText.Location = new System.Drawing.Point(13, 32);
            this.ChatText.Multiline = true;
            this.ChatText.Name = "ChatText";
            this.ChatText.ReadOnly = true;
            this.ChatText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ChatText.Size = new System.Drawing.Size(543, 323);
            this.ChatText.TabIndex = 1;
            this.ChatText.TabStop = false;
            this.ChatText.TextChanged += new System.EventHandler(this.ChatText_TextChanged);
            // 
            // SendText
            // 
            this.SendText.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SendText.Location = new System.Drawing.Point(13, 373);
            this.SendText.Name = "SendText";
            this.SendText.Size = new System.Drawing.Size(434, 27);
            this.SendText.TabIndex = 0;
            this.SendText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SendText_KeyDown);
            // 
            // HelpImage
            // 
            this.HelpImage.BackColor = System.Drawing.Color.Transparent;
            this.HelpImage.Image = global::ChatBot.Properties.Resources.help;
            this.HelpImage.Location = new System.Drawing.Point(533, 4);
            this.HelpImage.Name = "HelpImage";
            this.HelpImage.Size = new System.Drawing.Size(24, 26);
            this.HelpImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.HelpImage.TabIndex = 2;
            this.HelpImage.TabStop = false;
            this.HelpImage.Click += new System.EventHandler(this.HelpImage_Click);
            // 
            // DeleteDialogImage
            // 
            this.DeleteDialogImage.BackColor = System.Drawing.Color.Transparent;
            this.DeleteDialogImage.Image = global::ChatBot.Properties.Resources.delete_dialog;
            this.DeleteDialogImage.Location = new System.Drawing.Point(13, 4);
            this.DeleteDialogImage.Name = "DeleteDialogImage";
            this.DeleteDialogImage.Size = new System.Drawing.Size(24, 26);
            this.DeleteDialogImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DeleteDialogImage.TabIndex = 3;
            this.DeleteDialogImage.TabStop = false;
            this.DeleteDialogImage.Click += new System.EventHandler(this.DeleteDialogImage_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = global::ChatBot.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(569, 418);
            this.Controls.Add(this.DeleteDialogImage);
            this.Controls.Add(this.HelpImage);
            this.Controls.Add(this.SendText);
            this.Controls.Add(this.ChatText);
            this.Controls.Add(this.SendButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "TO DO CHATBOT";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.HelpImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteDialogImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.TextBox SendText;
        private System.Windows.Forms.PictureBox HelpImage;
        private System.Windows.Forms.PictureBox DeleteDialogImage;
        public System.Windows.Forms.TextBox ChatText;
    }
}

