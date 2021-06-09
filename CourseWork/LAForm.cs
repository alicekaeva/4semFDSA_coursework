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

namespace CourseWork
{
    public partial class LAForm : Form
    {
        public static LAHashTable UHT = new LAHashTable();

        public LAForm()
        {
            InitializeComponent();
            ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Удалить");
            contextMenuStrip1.Items.AddRange(new[] { deleteMenuItem });
            UsersGridView.ContextMenuStrip = contextMenuStrip1;
            deleteMenuItem.Click += deleteMenuItem_Click;
        }

        void deleteMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < UsersGridView.Rows.Count - 1; i++) UsersGridView.Rows[i].DefaultCellStyle.BackColor = Color.White;
            if (MessageBox.Show("Согласны ли вы, удаляя пользователя из этой хеш-таблицы, удалить ее в общем списке?", "Удалить пользователя", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int rowIndex = UsersGridView.CurrentCell.RowIndex;
                string l = UsersGridView.Rows[rowIndex].Cells[1].Value.ToString();
                string a = UsersGridView.Rows[rowIndex].Cells[2].Value.ToString();
                UHT.delete(new LA(l, a));
                AllForm.tree.Delete(l);
                MessageBox.Show($"{l} был удален");
                string tempFile = Path.GetTempFileName();
                string whatToDelete = l + "|" + a;
                using (var sr = new StreamReader("user.txt"))
                using (var sw = new StreamWriter(tempFile))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line != whatToDelete)
                            sw.WriteLine(line);
                    }
                }
                File.Delete("user.txt");
                File.Move(tempFile, "user.txt");
                UsersGridView.Rows.RemoveAt(rowIndex);
            }
        }

        private void LAForm_Load(object sender, EventArgs e)
        {
            Form MainForm = new MainForm();
            MainForm.Hide();
            StreamReader file = null;
            UsersGridView.Rows.Clear();
            try
            {
                file = new StreamReader("user.txt");
                String line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] subs = line.Split('|');
                    UHT.add(new LA(subs[0], subs[1]));
                    string[] row1 = new string[] { UHT.hashFunc(subs[0]).ToString(), subs[0], subs[1] };
                    UsersGridView.Rows.Add(row1);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка входных данных");
            }
            finally
            {
                file.Close();
            }
        }

        private void BackToTheMenu_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Hide();
            UsersGridView.Rows.Clear();
        }

        private void addingButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < UsersGridView.Rows.Count - 1; i++) UsersGridView.Rows[i].DefaultCellStyle.BackColor = Color.White;
            AddingForm addForm = new AddingForm();
            DialogResult dialogResult = addForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                LA a = addForm.make();
                if (UHT.add(a))
                {
                    MessageBox.Show($"{a.login} был добавлен");
                    using (StreamWriter sw = File.AppendText("user.txt"))
                    {
                        sw.WriteLine($"{a.login}|{a.adress}");
                        sw.Close();
                    }
                    string[] row1 = new string[] { UHT.hashFunc(a.login).ToString(), a.login, a.adress };
                    UsersGridView.Rows.Add(row1);
                }
            }
        }

        private void searchingButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < UsersGridView.Rows.Count - 1; i++) UsersGridView.Rows[i].DefaultCellStyle.BackColor = Color.White;
            SearchingForm seaForm = new SearchingForm();
            DialogResult dialogResult = seaForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string c = seaForm.make();
                UHT.searchByLogin(c);
                for (int i = 0; i < UsersGridView.Rows.Count - 1; i++)
                {
                    string l = UsersGridView.Rows[i].Cells[1].Value.ToString();
                    if (l == c) UsersGridView.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
        }
    }
}