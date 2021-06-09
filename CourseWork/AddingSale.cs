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
            Sales who = new Sales(textBox1.Text, textBox2.Text, textBox3.Text, Int32.Parse(textBox4.Text), textBox5.Text);
            return who;
        }

    }
}
