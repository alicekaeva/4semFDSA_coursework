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
    public partial class DeletingForm : Form
    {
        public DeletingForm()
        {
            InitializeComponent();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            make();
            DialogResult = DialogResult.OK;
        }

        public LA make()
        {
            LA who = new LA(textBox1.Text, textBox2.Text);
            return who;
        }
    }
}
