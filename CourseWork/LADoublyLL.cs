using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public class node
    {
        public LA data;
        public node next;
        public node prev;
    }

    public class LADoublyLL
    {
        public node head;

        public LADoublyLL()
        {
            head = null;
        }

        public bool insert(LA u)
        {
            if (search(u))
            {
                MessageBox.Show($"{u.login} уже добавлен");
                return false;
            }
            else if (checkingLogin(u.login) && checkingAddress(u.address) && !(search(u)))
            {
                node newNode = new node();
                newNode.data = u;
                newNode.next = null;
                newNode.prev = null;
                if (head == null)
                {
                    head = newNode;
                }
                else
                {
                    if (String.Compare(head.data.login, newNode.data.login) > 0 || String.Compare(head.data.login, newNode.data.login) == 0) // equal to head.data > newNode.data || head.data == newNode.data
                    {
                        newNode.next = head;
                        newNode.next.prev = newNode;
                        head = newNode;
                    }
                    else
                    {
                        node temp = new node();
                        temp = head;
                        while (temp.next != null && String.Compare(temp.next.data.login, newNode.data.login) < 0) // equal to temp.next.data < newNode.data
                        {
                            temp = temp.next;
                        }
                        newNode.next = temp.next;
                        if (temp.next != null) newNode.next.prev = newNode;
                        temp.next = newNode;
                        newNode.prev = temp;
                    }
                }
                return true;
            }
            else
            {
                MessageBox.Show("Неверный формат входных даннных");
                return false;
            }
        }

        public node deleteNode(node head, node del)
        {
            if (head == null || del == null)
                return null;

            if (head == del)
                head = del.next;

            if (del.next != null)
                del.next.prev = del.prev;

            if (del.prev != null)
                del.prev.next = del.next;

            del = null;

            return head;
        }

        public bool deleteGivenNode(LA u)
        {
            if (search(u))
            {
                if (head == null)
                    return false;
                node current = head;

                if (String.Compare(current.data.login, u.login) == 0) // equal to current.data == n
                {
                    head = head.next;
                    current = null;
                    if (head != null)
                    {
                        head.prev = null;
                    }
                    MessageBox.Show($"{u.login} был удален");
                    return true;
                }
                else
                {
                    while (current != null && String.Compare(current.data.login, u.login) != 0) // equal to current.data != n
                    {
                        current = current.next;
                    }
                    if (current == null)
                        return false;
                    deleteNode(head, current);
                    MessageBox.Show($"{u.login} был удален");
                    return true;
                }
            }
            else return false;
        }

        public bool search(LA u)
        {
            node current = head;
            while (current != null)
            {
                if ((current.data.address == u.address) && String.Compare(current.data.login, u.login) == 0) // equal to current.data == x
                    return true;
                current = current.next;
            }
            return false;
        }

        public LA searchByLogin(string u)
        {
            int compare = 0;
            node current = head;
            while (current != null)
            {
                if (String.Compare(current.data.login, u) == 0)
                {
                    compare++;
                    MessageBox.Show($"Сравнений - {compare}");
                    return current.data;
                }
                compare++;
                current = current.next;
            }
            MessageBox.Show($"{u} не был найден");
            MessageBox.Show($"Сравнений - {compare}");
            return null;
        }

        public bool checkingLogin(string s)
        {
            if (s.Length <= 30)
            {
                if ((s[0] >= 'A' && s[0] <= 'Z') || (s[0] >= 'a' && s[0] <= 'z'))
                {
                    for (int i = 1; i < s.Length; i++)
                    {
                        if (!((s[i] >= 'A' && s[i] <= 'Z') || (s[i] >= 'a' && s[0] <= 'z') || s[i] == '.' || s[i] == '_' || (s[i] >= '0' && s[i] <= '9')))
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else return false;
        }

        public bool checkingAddress(string s)
        {
            string[] dormitory = new string[] { "город", "корпус 11", "корпус 10", "корпус 9", "корпус 8.1", "корпус 8.2", "корпус 7.1", "корпус 7.2", "корпус 6.1", "корпус 6.2", "корпус 1.10", "корпус 2.1", "корпус 2.2", "корпус 2.3", "корпус 2.4", "корпус 2.5", "корпус 2.6", "корпус 2.7" };
            int count = 0;
            for (int i = 0; i < dormitory.Length; i++)
            {
                if (s == dormitory[i]) count++;
            }
            if (count == 1) return true;
            else return false;
        }
    }
}