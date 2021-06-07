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
    public partial class AllForm : Form
    {
        List<Sales> userList = new List<Sales>();
        LAavlTree tree = new LAavlTree();
        public AllForm()
        {
            InitializeComponent();
        }
        private void LAForm_Load(object sender, EventArgs e)
        {
            Form MainForm = new MainForm();
            MainForm.Hide();
        }

        private void BackToTheMenu_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Hide();
        }

        private void ReadFile_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < UsersGridView.Rows.Count - 1; i++) UsersGridView.Rows[i].DefaultCellStyle.BackColor = Color.White;
            if (userList.Count != 0) userList.Clear();
            StreamReader file = null;
            try
            {
                file = new StreamReader("sales.txt");
                String line;
                UsersGridView.Rows.Clear();
                while ((line = file.ReadLine()) != null)
                {
                    string[] subs = line.Split('|');
                    int p = Int32.Parse(subs[3]);
                    bool t = false;
                    if (subs[4] == "безналичный") t = true;
                    else if (subs[4] == "наличный") t = false;
                    userList.Add(new Sales(subs[0], subs[1], subs[2], p, t));
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
            for (var i = 0; i < userList.Count; i++) if (userList[i] != null) UsersGridView.Rows.Add(userList[i].login, userList[i].address, userList[i].nameOfProduct, userList[i].price, userList[i].typeOfPayment);
            for (int i = 0; i < userList.Count; i++) tree.Add(userList[i], i);
        }

        //private void addingButton_Click(object sender, EventArgs e)
        //{
        //    for (int i = 0; i < UsersGridView.Rows.Count - 1; i++) UsersGridView.Rows[i].DefaultCellStyle.BackColor = Color.White;
        //    AddingForm addForm = new AddingForm();
        //    DialogResult dialogResult = addForm.ShowDialog();
        //    if (dialogResult == DialogResult.OK)
        //    {
        //        LA a = addForm.make();
        //        if (UHT.add(a))
        //        {
        //            MessageBox.Show($"{a.login} был добавлен");
        //            using (StreamWriter sw = File.AppendText("user.txt"))
        //            {
        //                sw.WriteLine($"{a.login}|{a.adress}");
        //                sw.Close();
        //            }
        //            userList.Add(a);
        //            RefreshDataGrid();
        //        }
        //    }
        //}
        //private void RefreshDataGrid()
        //{
        //    UsersGridView.Rows.Clear();
        //    for (var i = 0; i < userList.Count; i++) if (userList[i] != null) UsersGridView.Rows.Add(UHT.hashFunc(userList[i].login), userList[i].login, userList[i].adress);
        //}

        //private void deletingButton_Click(object sender, EventArgs e)
        //{
        //    for (int i = 0; i < UsersGridView.Rows.Count - 1; i++) UsersGridView.Rows[i].DefaultCellStyle.BackColor = Color.White;
        //    DeletingForm delForm = new DeletingForm();
        //    DialogResult dialogResult = delForm.ShowDialog();
        //    if (dialogResult == DialogResult.OK)
        //    {
        //        LA b = delForm.make();
        //        if (UHT.delete(b))
        //        {
        //            MessageBox.Show($"{b.login} был удален");
        //            string tempFile = Path.GetTempFileName();
        //            string whatToDelete = b.login + "|" + b.adress;
        //            using (var sr = new StreamReader("user.txt"))
        //            using (var sw = new StreamWriter(tempFile))
        //            {
        //                string line;
        //                while ((line = sr.ReadLine()) != null)
        //                {
        //                    if (line != whatToDelete)
        //                        sw.WriteLine(line);
        //                }
        //            }
        //            File.Delete("user.txt");
        //            File.Move(tempFile, "user.txt");
        //            userList.Remove(b);
        //            RefreshDataGrid();
        //        }
        //    }
        //}

        private void searchingButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < UsersGridView.Rows.Count - 1; i++) UsersGridView.Rows[i].DefaultCellStyle.BackColor = Color.White;
            SearchingForm seaForm = new SearchingForm();
            DialogResult dialogResult = seaForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                int count = 0;
                string c = seaForm.make();
                Sales f = null;
                for (int i = 0; i < userList.Count; i++)
                {
                    if (c == userList[i].login)
                    {
                        f = userList[i];
                        count++;
                    }
                }
                if (count != 0)
                {
                    tree.Find(f);
                    for (int i = 0; i < UsersGridView.Rows.Count - 1; i++)
                    {
                        string l = UsersGridView.Rows[i].Cells[0].Value.ToString();
                        if (l == c) UsersGridView.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                }
                else MessageBox.Show($"{c} не был найден");
            }
        }
    }
}
