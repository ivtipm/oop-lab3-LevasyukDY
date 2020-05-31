namespace ChatBot
{
    partial class DeleteDialogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteDialogForm));
            this.NoButton = new System.Windows.Forms.Button();
            this.YesButton = new System.Windows.Forms.Button();
            this.HelpText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NoButton
            // 
            this.NoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NoButton.Location = new System.Drawing.Point(90, 98);
            this.NoButton.Name = "NoButton";
            this.NoButton.Size = new System.Drawing.Size(75, 23);
            this.NoButton.TabIndex = 0;
            this.NoButton.Text = "Нет";
            this.NoButton.UseVisualStyleBackColor = true;
            this.NoButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NoButton_KeyDown);
            // 
            // YesButton
            // 
            this.YesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.YesButton.Location = new System.Drawing.Point(255, 98);
            this.YesButton.Name = "YesButton";
            this.YesButton.Size = new System.Drawing.Size(75, 23);
            this.YesButton.TabIndex = 1;
            this.YesButton.Text = "Да";
            this.YesButton.UseVisualStyleBackColor = true;
            this.YesButton.Click += new System.EventHandler(this.YesButton_Click);
            this.YesButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.YesButton_KeyDown);
            // 
            // HelpText
            // 
            this.HelpText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HelpText.Location = new System.Drawing.Point(22, 24);
            this.HelpText.Name = "HelpText";
            this.HelpText.Size = new System.Drawing.Size(372, 52);
            this.HelpText.TabIndex = 2;
            this.HelpText.Text = "Вы уверены, что хотите удалить историю сообщений?\r\nОтменить это действие будет не" +
    "возможно!\r\nТекущие задачи не будут удалены.";
            this.HelpText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DeleteDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 150);
            this.Controls.Add(this.HelpText);
            this.Controls.Add(this.YesButton);
            this.Controls.Add(this.NoButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DeleteDialogForm";
            this.Text = "DELETE DIALOG - TO DO CHATBOT";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DeleteDialogForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NoButton;
        private System.Windows.Forms.Button YesButton;
        private System.Windows.Forms.Label HelpText;
    }
}