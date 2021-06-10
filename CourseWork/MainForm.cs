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
    public partial class MainForm : Form
    {
        //public static LAHashTable UHT = new LAHashTable();
        //public static List<Sales> salesList = new List<Sales>();
        //public static LAavlTree tree = new LAavlTree();

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
    }
}
