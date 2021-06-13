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
                if (MainForm.checkingLogin(textBox1.Text) && MainForm.checkingAddress(textBox2.Text) && MainForm.checkingNameOfProduct(textBox3.Text) && MainForm.checkRangeOfPrice(Int32.Parse(textBox4.Text)) && MainForm.checkTypeOfMethod(textBox5.Text)) return who;
                else return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
