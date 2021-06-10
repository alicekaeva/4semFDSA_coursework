﻿using System;
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
                    if (UHT.search(u))
                    {
                        salesList.Add(new Sales(subs[0], subs[1], subs[2], Int32.Parse(subs[3]), subs[4]));
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
    }
}
