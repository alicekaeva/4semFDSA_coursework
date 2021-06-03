using System;
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
        public int hashFunc(LA u)
        {
            int nx = 0;
            for (int i = 0; i < u.login.Length; i++)
            {
                nx += (int)u.login[i];
            }
            double A = 0.618033;
            int index = (int)Math.Floor(n * (A * nx - Math.Floor(A * nx)));
            return index;
        }
        public bool add(LA u)
        {
            return hashT[hashFunc(u)].insert(u);
        }
        public bool delete(LA u)
        {
            return hashT[hashFunc(u)].deleteGivenNode(u);
        }
        public void searchByLogin(string u)
        {
            if (hashT[hashFunc(u)].searchByLogin(u) == false) MessageBox.Show($"{u.login} не был найден");
        }
    }
}
