using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class AddingSale : Form
    {
        public AddingSale()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            make();
            DialogResult = DialogResult.OK;
        }

        public Sales make()
        {
            try
            {
                Sales who = new Sales(textBox1.Text, textBox2.Text, textBox3.Text, Int32.Parse(textBox4.Text), textBox5.Text);
                if (checkingNameOfProduct(textBox3.Text) && checkRangeOfPrice(Int32.Parse(textBox4.Text)) && checkTypeOfMethod(textBox5.Text)) return who;
                else return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        bool checkingNameOfProduct(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (!((s[i] >= 'А' && s[i] <= 'Я') || (s[i] >= 'а' && s[0] <= 'я') || (s[i] >= 'A' && s[i] <= 'Z') || (s[i] >= 'a' && s[0] <= 'z') || s[i] == '"' || s[i] == '-' || s[i] == ' ' || (s[i] >= '0' && s[i] <= '9')))
                {
                    return false;
                }
            }
            return true;
        }

        bool checkRangeOfPrice(int a)
        {
            return (a >= 0 && a <= 999999);
        }
        bool checkTypeOfMethod(string s)
        {
            return (s == "безналичный" || s == "наличный");
        }
    }
}
