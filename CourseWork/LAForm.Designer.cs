
namespace CourseWork
{
    partial class LAForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LAForm));
            this.UsersGridView = new System.Windows.Forms.DataGridView();
            this.Hash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addingButton = new System.Windows.Forms.Button();
            this.searchingButton = new System.Windows.Forms.Button();
            this.BackToTheMenu = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.UsersGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // UsersGridView
            // 
            this.UsersGridView.BackgroundColor = System.Drawing.Color.PaleTurquoise;
            this.UsersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UsersGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Hash,
            this.Login,
            this.Address});
            this.UsersGridView.GridColor = System.Drawing.Color.PaleTurquoise;
            this.UsersGridView.Location = new System.Drawing.Point(426, 114);
            this.UsersGridView.Name = "UsersGridView";
            this.UsersGridView.RowHeadersWidth = 82;
            this.UsersGridView.RowTemplate.Height = 41;
            this.UsersGridView.Size = new System.Drawing.Size(1200, 746);
            this.UsersGridView.TabIndex = 0;
            // 
            // Hash
            // 
            this.Hash.HeaderText = "Хеш";
            this.Hash.MinimumWidth = 10;
            this.Hash.Name = "Hash";
            this.Hash.Width = 400;
            // 
            // Login
            // 
            this.Login.HeaderText = "Логин";
            this.Login.MinimumWidth = 10;
            this.Login.Name = "Login";
            this.Login.Width = 400;
            // 
            // Address
            // 
            this.Address.HeaderText = "Адрес";
            this.Address.MinimumWidth = 10;
            this.Address.Name = "Address";
            this.Address.Width = 400;
            // 
            // addingButton
            // 
            this.addingButton.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.addingButton.Location = new System.Drawing.Point(79, 317);
            this.addingButton.Name = "addingButton";
            this.addingButton.Size = new System.Drawing.Size(234, 86);
            this.addingButton.TabIndex = 2;
            this.addingButton.Text = "Добавить пользователя";
            this.addingButton.UseVisualStyleBackColor = true;
            this.addingButton.Click += new System.EventHandler(this.addingButton_Click);
            // 
            // searchingButton
            // 
            this.searchingButton.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.searchingButton.Location = new System.Drawing.Point(79, 465);
            this.searchingButton.Name = "searchingButton";
            this.searchingButton.Size = new System.Drawing.Size(234, 86);
            this.searchingButton.TabIndex = 4;
            this.searchingButton.Text = "Поиск пользователя";
            this.searchingButton.UseVisualStyleBackColor = true;
            this.searchingButton.Click += new System.EventHandler(this.searchingButton_Click);
            // 
            // BackToTheMenu
            // 
            this.BackToTheMenu.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.BackToTheMenu.Location = new System.Drawing.Point(79, 611);
            this.BackToTheMenu.Name = "BackToTheMenu";
            this.BackToTheMenu.Size = new System.Drawing.Size(234, 86);
            this.BackToTheMenu.TabIndex = 5;
            this.BackToTheMenu.Text = "Назад в меню";
            this.BackToTheMenu.UseVisualStyleBackColor = true;
            this.BackToTheMenu.Click += new System.EventHandler(this.BackToTheMenu_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // LAForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(1686, 950);
            this.Controls.Add(this.BackToTheMenu);
            this.Controls.Add(this.searchingButton);
            this.Controls.Add(this.addingButton);
            this.Controls.Add(this.UsersGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LAForm";
            this.Text = "Справочник пользователей";
            this.Load += new System.EventHandler(this.LAForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UsersGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView UsersGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hash;
        private System.Windows.Forms.DataGridViewTextBoxColumn Login;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.Button addingButton;
        private System.Windows.Forms.Button searchingButton;
        private System.Windows.Forms.Button BackToTheMenu;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
    }
}