
namespace CourseWork
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Users = new System.Windows.Forms.Button();
            this.ChooseYourFighter = new System.Windows.Forms.Label();
            this.ShowAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Users
            // 
            this.Users.Font = new System.Drawing.Font("Segoe UI", 10.875F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.Users.Location = new System.Drawing.Point(183, 184);
            this.Users.Name = "Users";
            this.Users.Size = new System.Drawing.Size(274, 90);
            this.Users.TabIndex = 0;
            this.Users.Text = "Пользователи";
            this.Users.UseVisualStyleBackColor = true;
            this.Users.Click += new System.EventHandler(this.Users_Click);
            // 
            // ChooseYourFighter
            // 
            this.ChooseYourFighter.AutoSize = true;
            this.ChooseYourFighter.Font = new System.Drawing.Font("Segoe UI", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.ChooseYourFighter.Location = new System.Drawing.Point(41, 78);
            this.ChooseYourFighter.Name = "ChooseYourFighter";
            this.ChooseYourFighter.Size = new System.Drawing.Size(561, 65);
            this.ChooseYourFighter.TabIndex = 3;
            this.ChooseYourFighter.Text = "Выберите структуру";
            // 
            // ShowAll
            // 
            this.ShowAll.Font = new System.Drawing.Font("Segoe UI", 10.875F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.ShowAll.Location = new System.Drawing.Point(222, 322);
            this.ShowAll.Name = "ShowAll";
            this.ShowAll.Size = new System.Drawing.Size(202, 90);
            this.ShowAll.TabIndex = 4;
            this.ShowAll.Text = "Продажи";
            this.ShowAll.UseVisualStyleBackColor = true;
            this.ShowAll.Click += new System.EventHandler(this.ShowAll_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(668, 486);
            this.Controls.Add(this.ShowAll);
            this.Controls.Add(this.ChooseYourFighter);
            this.Controls.Add(this.Users);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Меню";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Users;
        private System.Windows.Forms.Label ChooseYourFighter;
        private System.Windows.Forms.Button ShowAll;
    }
}

