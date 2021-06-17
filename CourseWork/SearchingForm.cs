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
    public partial class SearchingForm : Form
    {
        public SearchingForm()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            make();
            DialogResult = DialogResult.OK;
        }

        public string make()
        {
            try
            {
                string who = textBox1.Text;
                if (who != "") return who;
                else return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
