
namespace CourseWork
{
    partial class AllForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllForm));
            this.BackToTheMenu = new System.Windows.Forms.Button();
            this.searchingButton = new System.Windows.Forms.Button();
            this.addingButton = new System.Windows.Forms.Button();
            UsersGridView = new System.Windows.Forms.DataGridView();
            this.Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Way = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deletionButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(UsersGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // BackToTheMenu
            // 
            this.BackToTheMenu.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.BackToTheMenu.Location = new System.Drawing.Point(85, 660);
            this.BackToTheMenu.Name = "BackToTheMenu";
            this.BackToTheMenu.Size = new System.Drawing.Size(234, 86);
            this.BackToTheMenu.TabIndex = 11;
            this.BackToTheMenu.Text = "Назад в меню";
            this.BackToTheMenu.UseVisualStyleBackColor = true;
            this.BackToTheMenu.Click += new System.EventHandler(this.BackToTheMenu_Click_1);
            // 
            // searchingButton
            // 
            this.searchingButton.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.searchingButton.Location = new System.Drawing.Point(85, 517);
            this.searchingButton.Name = "searchingButton";
            this.searchingButton.Size = new System.Drawing.Size(234, 86);
            this.searchingButton.TabIndex = 10;
            this.searchingButton.Text = "Поиск по логину";
            this.searchingButton.UseVisualStyleBackColor = true;
            this.searchingButton.Click += new System.EventHandler(this.searchingButton_Click);
            // 
            // addingButton
            // 
            this.addingButton.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.addingButton.Location = new System.Drawing.Point(85, 232);
            this.addingButton.Name = "addingButton";
            this.addingButton.Size = new System.Drawing.Size(234, 86);
            this.addingButton.TabIndex = 9;
            this.addingButton.Text = "Добавить продажу";
            this.addingButton.UseVisualStyleBackColor = true;
            this.addingButton.Click += new System.EventHandler(this.addingButton_Click_1);
            // 
            // UsersGridView
            // 
            UsersGridView.AllowUserToAddRows = false;
            UsersGridView.BackgroundColor = System.Drawing.Color.PaleTurquoise;
            UsersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            UsersGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Login,
            this.Address,
            this.Item,
            this.Price,
            this.Way});
            UsersGridView.GridColor = System.Drawing.Color.PaleTurquoise;
            UsersGridView.Location = new System.Drawing.Point(422, 102);
            UsersGridView.Name = "UsersGridView";
            UsersGridView.ReadOnly = true;
            UsersGridView.RowHeadersWidth = 82;
            UsersGridView.RowTemplate.Height = 41;
            UsersGridView.Size = new System.Drawing.Size(1200, 746);
            UsersGridView.TabIndex = 6;
            // 
            // Login
            // 
            this.Login.HeaderText = "Логин";
            this.Login.MinimumWidth = 10;
            this.Login.Name = "Login";
            this.Login.ReadOnly = true;
            this.Login.Width = 240;
            // 
            // Address
            // 
            this.Address.HeaderText = "Адрес";
            this.Address.MinimumWidth = 10;
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Width = 240;
            // 
            // Item
            // 
            this.Item.HeaderText = "Товар";
            this.Item.MinimumWidth = 10;
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            this.Item.Width = 240;
            // 
            // Price
            // 
            this.Price.HeaderText = "Цена";
            this.Price.MinimumWidth = 10;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 180;
            // 
            // Way
            // 
            this.Way.HeaderText = "Способ оплаты";
            this.Way.MinimumWidth = 10;
            this.Way.Name = "Way";
            this.Way.ReadOnly = true;
            this.Way.Width = 240;
            // 
            // deletionButton
            // 
            this.deletionButton.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.deletionButton.Location = new System.Drawing.Point(85, 372);
            this.deletionButton.Name = "deletionButton";
            this.deletionButton.Size = new System.Drawing.Size(234, 86);
            this.deletionButton.TabIndex = 12;
            this.deletionButton.Text = "Удалить продажу";
            this.deletionButton.UseVisualStyleBackColor = true;
            this.deletionButton.Click += new System.EventHandler(this.deletionButton_Click);
            // 
            // AllForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(1686, 950);
            this.Controls.Add(this.deletionButton);
            this.Controls.Add(this.BackToTheMenu);
            this.Controls.Add(this.searchingButton);
            this.Controls.Add(this.addingButton);
            this.Controls.Add(UsersGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AllForm";
            this.Text = "Общая структура";
            this.Load += new System.EventHandler(this.AllForm_Load);
            ((System.ComponentModel.ISupportInitialize)(UsersGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BackToTheMenu;
        private System.Windows.Forms.Button searchingButton;
        private System.Windows.Forms.Button addingButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Login;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Way;
        private System.Windows.Forms.Button deletionButton;
        public static System.Windows.Forms.DataGridView UsersGridView;
    }
}