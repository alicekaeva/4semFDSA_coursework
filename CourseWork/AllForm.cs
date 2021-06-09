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
        public static List<Sales> salesList = new List<Sales>();
        public static LAavlTree tree = new LAavlTree();

        public AllForm()
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
            int rowIndex = UsersGridView.CurrentCell.RowIndex;
            string l = UsersGridView.Rows[rowIndex].Cells[0].Value.ToString();
            string a = UsersGridView.Rows[rowIndex].Cells[1].Value.ToString();
            string t = UsersGridView.Rows[rowIndex].Cells[2].Value.ToString();
            string p = UsersGridView.Rows[rowIndex].Cells[3].Value.ToString();
            string m = UsersGridView.Rows[rowIndex].Cells[4].Value.ToString();
            MessageBox.Show($"{l} c товаром {t} был удален");
            salesList.Remove(new Sales(l, a, t, Int32.Parse(p), m));
            string tempFile = Path.GetTempFileName();
            string whatToDelete = l + "|" + a + "|" + t + "|" + p + "|" + m;
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

        private void AllForm_Load(object sender, EventArgs e)
        {
            Form MainForm = new MainForm();
            MainForm.Hide();
            StreamReader file = null;
            try
            {
                file = new StreamReader("sales.txt");
                String line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] subs = line.Split('|');
                    LA u = new LA(subs[0], subs[1]);
                    if (LAForm.UHT.search(u))   //РЕБЯТА СЮДА ДОБАВЛЯЮТ
                    {
                        salesList.Add(new Sales(subs[0], subs[1], subs[2], Int32.Parse(subs[3]), subs[4]));
                        UsersGridView.Rows.Add(subs[0], subs[1], subs[2], subs[3], subs[4]);
                    }
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
            for (int i = 0; i < salesList.Count; i++) tree.Add(salesList[i].login, salesList[i]);
        }

        private void BackToTheMenu_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Hide();
            UsersGridView.Rows.Clear();
        }

        private void addingButton_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < UsersGridView.Rows.Count - 1; i++) UsersGridView.Rows[i].DefaultCellStyle.BackColor = Color.White;
            AddingSale addForm = new AddingSale();
            DialogResult dialogResult = addForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                Sales a = addForm.make();
                LA u = new LA(a.login, a.address);
                if (LAForm.UHT.search(u) && !salesList.Contains(a))
                {
                    MessageBox.Show($"{a.login} был добавлен");
                    using (StreamWriter sw = File.AppendText("sales.txt"))
                    {
                        sw.WriteLine($"{a.login}|{a.address}|{a.nameOfProduct}|{a.price}|{a.typeOfPayment}");
                        sw.Close();
                    }
                    UsersGridView.Rows.Add(a.login, a.address, a.nameOfProduct, a.price, a.typeOfPayment);
                }
                else if (LAForm.UHT.search(u) && salesList.Contains(a)) MessageBox.Show($"{a.login} с товаром {a.nameOfProduct} уже добавлен");
                else MessageBox.Show("Не может быть добавлен");
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
                if (tree.contains(c))
                {
                    MessageBox.Show($"Сравнений - {LAavlTree.compare}");
                    LAavlTree.compare = 0;
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