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
        List<LA> userList = new List<LA>();
        LAHashTable UHT = new LAHashTable();
        public LAForm()
        {
            InitializeComponent();
        }

        private void LAForm_Load(object sender, EventArgs e)
        {
            Form MainForm = new MainForm();
            MainForm.Hide();
        }

        private void ReadFile_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < UsersGridView.Rows.Count - 1; i++) UsersGridView.Rows[i].DefaultCellStyle.BackColor = Color.White;
            if (userList.Count != 0)
            {
                for (int i = 0; i < userList.Count; i++)
                {
                    UHT.delete(userList[i]);
                }
                userList.Clear();
            }
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                StreamReader file = null;
                try
                {
                    file = new StreamReader(openFile.FileName);
                    String line;
                    UsersGridView.Rows.Clear();
                    while ((line = file.ReadLine()) != null)
                    {
                        string[] subs = line.Split('|');
                        userList.Add(new LA(subs[0], subs[1]));
                        UHT.add(new LA(subs[0], subs[1]));
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
                for (var i = 0; i < userList.Count; i++) if (userList[i] != null) UsersGridView.Rows.Add(UHT.hashFunc(userList[i]), userList[i].login, userList[i].adress);
            }
        }

        private void BackToTheMenu_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Hide();
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
                    userList.Add(a);
                    RefreshDataGrid();
                }
            }
        }
        private void RefreshDataGrid()
        {
            UsersGridView.Rows.Clear();
            for (var i = 0; i < userList.Count; i++) if (userList[i] != null) UsersGridView.Rows.Add(UHT.hashFunc(userList[i]), userList[i].login, userList[i].adress);
        }

        private void deletingButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < UsersGridView.Rows.Count - 1; i++) UsersGridView.Rows[i].DefaultCellStyle.BackColor = Color.White;
            DeletingForm delForm = new DeletingForm();
            DialogResult dialogResult = delForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                LA b = delForm.make();
                if (UHT.delete(b))
                {
                    MessageBox.Show($"{b.login} был удален");
                    userList.Remove(b);
                    RefreshDataGrid();
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
                    if (l == c.login) UsersGridView.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
        }
    }
}
