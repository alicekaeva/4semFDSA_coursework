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

        public AllForm()
        {
            InitializeComponent();
        }

        private void AllForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < MainForm.salesList.Count(); i++) UsersGridView.Rows.Add(MainForm.salesList[i].login, MainForm.salesList[i].address, MainForm.salesList[i].nameOfProduct, MainForm.salesList[i].price, MainForm.salesList[i].typeOfPayment);
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
                if (a != null && MainForm.checkingLogin(a.login) && MainForm.checkingAddress(a.address) && MainForm.checkingNameOfProduct(a.nameOfProduct) && MainForm.checkRangeOfPrice(a.price) && MainForm.checkTypeOfMethod(a.typeOfPayment))
                {
                    LA u = new LA(a.login, a.address);
                    if (MainForm.UHT.search(u) && !MainForm.salesList.Contains(a))
                    {
                        MessageBox.Show($"{a.login} с товаром {a.nameOfProduct} был добавлен");
                        using (StreamWriter sw = File.AppendText("sales.txt"))
                        {
                            sw.WriteLine($"{a.login}|{a.address}|{a.nameOfProduct}|{a.price}|{a.typeOfPayment}");
                            sw.Close();
                        }
                        MainForm.salesList.Add(a);
                        MainForm.tree.Add(a.login, a);
                        UsersGridView.Rows.Add(a.login, a.address, a.nameOfProduct, a.price, a.typeOfPayment);
                    }
                    else if (MainForm.UHT.search(u) && MainForm.salesList.Contains(a)) MessageBox.Show($"{a.login} с товаром {a.nameOfProduct} уже добавлен");
                    else MessageBox.Show("Пользователь не содерижится в списке пользователей");
                }
                else MessageBox.Show("Поле оказалось пустым или содержит некорректные данные");
            }
        }

        private  void searchingButton_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i < UsersGridView.Rows.Count; i++) UsersGridView.Rows[i].DefaultCellStyle.BackColor = Color.White;
            SearchingForm seaForm = new SearchingForm();
            DialogResult dialogResult = seaForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string c = seaForm.make();
                if(c != null) MainForm.tree.Contains(LAavlTree.root, c, ref count);
                else MessageBox.Show("Поле оказалось пустым");
            }
        }

        private void deletionButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < UsersGridView.Rows.Count; i++) UsersGridView.Rows[i].DefaultCellStyle.BackColor = Color.White;
            int rowIndex = UsersGridView.CurrentCell.RowIndex;
            string l = UsersGridView.Rows[rowIndex].Cells[0].Value.ToString();
            string a = UsersGridView.Rows[rowIndex].Cells[1].Value.ToString();
            string t = UsersGridView.Rows[rowIndex].Cells[2].Value.ToString();
            string p = UsersGridView.Rows[rowIndex].Cells[3].Value.ToString();
            string m = UsersGridView.Rows[rowIndex].Cells[4].Value.ToString();
            MessageBox.Show($"{l} c товаром {t} был удален");
            MainForm.salesList.Remove(new Sales(l, a, t, Int32.Parse(p), m));
            MainForm.tree.Delete(l);
            string tempFile = Path.GetTempFileName();
            string whatToDelete = l + "|" + a + "|" + t + "|" + p + "|" + m;
            using (var sr = new StreamReader("sales.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;
                while ((line = sr.ReadLine()) != null) if (line != whatToDelete) sw.WriteLine(line);
            }
            File.Delete("sales.txt");
            File.Move(tempFile, "sales.txt");
            UsersGridView.Rows.RemoveAt(rowIndex);
        }
    }
}
