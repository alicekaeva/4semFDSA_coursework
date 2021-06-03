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
    public partial class AddingForm : Form
    {
        public AddingForm()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            make();
            DialogResult = DialogResult.OK;
        }

        LA who;

        public LA make()
        {
            who = new LA(textBox1.Text, textBox2.Text);
            return who;
        }
    }
}
