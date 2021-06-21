using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CourseWork
{
   public class LAHashTable
    {
        static int n = 10;
        public LADoublyLL[] hashT;
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
            if (hashT[hashFunc(u.login)].insert(u)) return true;
            else return false;
        }
        public bool delete(LA u, List<Sales> s,LAavlTree t)
        {
            string tempFile = Path.GetTempFileName();
            string whatToDelete = u.login + "|" + u.address;
            using (var sr = new StreamReader("user.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line != whatToDelete) sw.WriteLine(line);
                }
            }
            File.Delete("user.txt");
            File.Move(tempFile, "user.txt");
            int first = s.Count();
            t.Delete(u.login);
            for (int i = 0; i < s.Count; i++)
            {
                if (s[i].login == u.login && s[i].address == u.address) {
                    whatToDelete = s[i].login + "|" + s[i].address + "|" + s[i].nameOfProduct + "|" + s[i].price + "|" + s[i].typeOfPayment;
                    using (var sr = new StreamReader("sales.txt"))
                    using (var sw = new StreamWriter(tempFile))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (line != whatToDelete) sw.WriteLine(line);
                        }
                    }
                    File.Delete("sales.txt");
                    File.Move(tempFile, "sales.txt");
                }
            }
            s.RemoveAll(i => i.login == u.login && i.address == u.address);
            int last = s.Count();
            MessageBox.Show($"Из общей структуры было удалено {first - last} записей");
            return hashT[hashFunc(u.login)].deleteGivenNode(u);
        }
        public bool searchByLogin(string u)
        {
            if (hashT[hashFunc(u)].searchByLogin(u) == null) return false;
            else return true;
        }
        public bool search(LA u)
        {
            if (hashT[hashFunc(u.login)].search(u) == false) return false;
            else return true;
        }
    }
}
