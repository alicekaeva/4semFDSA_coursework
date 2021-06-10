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

        public LAForm()
        {
            InitializeComponent();
        }

        private void LAForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                node current = MainForm.UHT.hashT[i].head;
                while (current != null)
                {
                    UsersGridView.Rows.Add(MainForm.UHT.hashFunc(current.data.login), current.data.login, current.data.adress);
                    current = current.next;
                }
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
                if (MainForm.UHT.add(a))
                {
                    MessageBox.Show($"{a.login} был добавлен");
                    using (StreamWriter sw = File.AppendText("user.txt"))
                    {
                        sw.WriteLine($"{a.login}|{a.adress}");
                        sw.Close();
                    }
                    string[] row1 = new string[] { MainForm.UHT.hashFunc(a.login).ToString(), a.login, a.adress };
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
                MainForm.UHT.searchByLogin(c);
                for (int i = 0; i < UsersGridView.Rows.Count - 1; i++)
                {
                    string l = UsersGridView.Rows[i].Cells[1].Value.ToString();
                    if (l == c) UsersGridView.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
        }

        private void deletingButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < UsersGridView.Rows.Count - 1; i++) UsersGridView.Rows[i].DefaultCellStyle.BackColor = Color.White;
            if (MessageBox.Show("Согласны ли вы, удаляя пользователя из этой хеш-таблицы, удалить ее в общем списке?", "Удалить пользователя", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int rowIndex = UsersGridView.CurrentCell.RowIndex;
                string l = UsersGridView.Rows[rowIndex].Cells[1].Value.ToString();
                string a = UsersGridView.Rows[rowIndex].Cells[2].Value.ToString();
                MainForm.UHT.delete(new LA(l, a), MainForm.salesList, MainForm.tree);
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
                using (var sr = new StreamReader("sales.txt"))
                using (var sw = new StreamWriter(tempFile))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line != whatToDelete)
                            sw.WriteLine(line);
                    }
                }
                File.Delete("sales.txt");
                File.Move(tempFile, "sales.txt");
                UsersGridView.Rows.RemoveAt(rowIndex);
            }
        }
    }
}