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
                    UsersGridView.Rows.Add(MainForm.UHT.hashFunc(current.data.login), current.data.login, current.data.address);
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
            for (int i = 0; i < UsersGridView.Rows.Count; i++) UsersGridView.Rows[i].DefaultCellStyle.BackColor = Color.White;
            AddingForm addForm = new AddingForm();
            DialogResult dialogResult = addForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                LA a = addForm.make();
                if (a != null)
                {
                    if (MainForm.UHT.add(a))
                    {
                        MessageBox.Show($"{a.login} был добавлен");
                        using (StreamWriter sw = File.AppendText("user.txt"))
                        {
                            sw.WriteLine($"{a.login}|{a.address}");
                            sw.Close();
                        }
                        string[] row1 = new string[] { MainForm.UHT.hashFunc(a.login).ToString(), a.login, a.address };
                        UsersGridView.Rows.Add(row1);
                    }
                }
                else MessageBox.Show("Поле оказалось пустым");
            }
        }

        private void searchingButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < UsersGridView.Rows.Count; i++) UsersGridView.Rows[i].DefaultCellStyle.BackColor = Color.White;
            SearchingForm seaForm = new SearchingForm();
            DialogResult dialogResult = seaForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string c = seaForm.make();
                if (c != null)
                {
                    if (MainForm.UHT.searchByLogin(c))
                    {
                        MessageBox.Show($"Сравнений - {LADoublyLL.compare}");
                        for (int i = 0; i < UsersGridView.Rows.Count; i++)
                        {
                            string l = UsersGridView.Rows[i].Cells[1].Value.ToString();
                            if (l == c) UsersGridView.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                        }
                    }
                }
                else MessageBox.Show("Поле оказалось пустым");
            }
        }

        private void deletingButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < UsersGridView.Rows.Count; i++) UsersGridView.Rows[i].DefaultCellStyle.BackColor = Color.White;
            if (MessageBox.Show("Согласны ли вы, удаляя пользователя из этой хеш-таблицы, удалить ее в общем списке?", "Удалить пользователя", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int rowIndex = UsersGridView.CurrentCell.RowIndex;
                string l = UsersGridView.Rows[rowIndex].Cells[1].Value.ToString();
                string a = UsersGridView.Rows[rowIndex].Cells[2].Value.ToString();
                if (MainForm.UHT.delete(new LA(l, a), MainForm.salesList, MainForm.tree)) UsersGridView.Rows.RemoveAt(rowIndex);
            }
        }
    }
}