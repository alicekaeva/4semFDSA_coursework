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
    public partial class MainForm : Form
    {
        public static LAHashTable UHT = new LAHashTable();
        public static List<Sales> salesList = new List<Sales>();
        public static LAavlTree tree = new LAavlTree();

        public MainForm()
        {
            InitializeComponent();
        }

        private void Users_Click(object sender, EventArgs e)
        {
            Hide();
            LAForm addForm = new LAForm();
            DialogResult dialogResult = addForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void ShowAll_Click(object sender, EventArgs e)
        {
            Hide();
            AllForm addForm = new AllForm();
            DialogResult dialogResult = addForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            StreamReader file = null;
            try
            {
                file = new StreamReader("user.txt");
                String line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] subs = line.Split('|');
                    UHT.add(new LA(subs[0], subs[1]));
                    string[] row1 = new string[] { UHT.hashFunc(subs[0]).ToString(), subs[0], subs[1] };
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
            try
            {
                file = new StreamReader("sales.txt");
                String line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] subs = line.Split('|');
                    LA u = new LA(subs[0], subs[1]);
                    if (UHT.search(u) && checkingNameOfProduct(subs[2]) && checkRangeOfPrice(Int32.Parse(subs[3])) && checkTypeOfMethod(subs[4])) salesList.Add(new Sales(subs[0], subs[1], subs[2], Int32.Parse(subs[3]), subs[4]));
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

        public static bool checkingNameOfProduct(string s)
        {
            if (s.Length <= 50)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (!((s[i] >= 'А' && s[i] <= 'Я') || (s[i] >= 'а' && s[i] <= 'я') || (s[i] >= 'A' && s[i] <= 'Z') || (s[i] >= 'a' && s[i] <= 'z') || s[i] == '"' || s[i] == '-' || s[i] == ' ' || (s[i] >= '0' && s[i] <= '9')))
                    {
                        return false;
                    }
                }
                return true;
            }
            else return false;
        }

        public static bool checkRangeOfPrice(int a)
        {
            return (a >= 0 && a <= 999999);
        }

        public static bool checkTypeOfMethod(string s)
        {
            return (s == "безналичный" || s == "наличный");
        }
        public static bool checkingLogin(string s)
        {
            if (s.Length <= 30)
            {
                if ((s[0] >= 'A' && s[0] <= 'Z') || (s[0] >= 'a' && s[0] <= 'z'))
                {
                    for (int i = 1; i < s.Length; i++)
                    {
                        if (!((s[i] >= 'A' && s[i] <= 'Z') || (s[i] >= 'a' && s[i] <= 'z') || s[i] == '.' || s[i] == '_' || (s[i] >= '0' && s[i] <= '9')))
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else return false;
        }

        public static bool checkingAddress(string s)
        {
            string[] dormitory = new string[] { "город", "корпус 11", "корпус 10", "корпус 9", "корпус 8.1", "корпус 8.2", "корпус 7.1", "корпус 7.2", "корпус 6.1", "корпус 6.2", "корпус 1.10", "корпус 2.1", "корпус 2.2", "корпус 2.3", "корпус 2.4", "корпус 2.5", "корпус 2.6", "корпус 2.7" };
            int count = 0;
            for (int i = 0; i < dormitory.Length; i++)
            {
                if (s == dormitory[i]) count++;
            }
            if (count == 1) return true;
            else return false;
        }
    }
}