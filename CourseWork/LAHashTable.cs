﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    class LAHashTable
    {
        static int n = 10;
        LADoublyLL[] hashT;
        public LAHashTable()
        {
            hashT = new LADoublyLL[n];
            for (int i = 0; i < n; i++)
            {
                hashT[i] = new LADoublyLL();
            }
        }
        public int hashFunc(string u)
        {
            int nx = 0;
            for (int i = 0; i < u.Length; i++)
            {
                nx += (int)u[i];
            }
            int index = nx % n; ;
            return index;
        }
        public bool add(LA u)
        {
            return hashT[hashFunc(u.login)].insert(u);
        }
        public bool delete(LA u)
        {
            return hashT[hashFunc(u.login)].deleteGivenNode(u);
        }
        public void search(string u)
        {
            if (hashT[hashFunc(u)].searchByLogin(u) == null) MessageBox.Show($"{u} не был найден");
        }
    }
}
