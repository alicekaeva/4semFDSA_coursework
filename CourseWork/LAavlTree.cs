using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public class LAavlTree
    {

        public class Node
        {
            public string data;
            public Sales position;
            public Node left;
            public Node right;
            public Node(string data, Sales i)
            {
                this.data = data;
                this.position = i;
            }
        }

        public static Node root;

        public void Add(string data, Sales i)
        {
            Node newItem = new Node(data, i);
            if (root == null)
            {
                root = newItem;
            }
            else
            {
                root = RecursiveInsert(root, newItem);
            }
        }

        private Node RecursiveInsert(Node current, Node n)
        {
            if (current == null)
            {
                current = n;
                return current;
            }
            else if (String.Compare(n.data, current.data) == 0)
            {
                current.left = RecursiveInsert(current.left, n);
                current = balance_tree(current);
            }
            else if (String.Compare(n.data, current.data) < 0)
            {
                current.left = RecursiveInsert(current.left, n);
                current = balance_tree(current);
            }
            else if (String.Compare(n.data, current.data) > 0)
            {
                current.right = RecursiveInsert(current.right, n);
                current = balance_tree(current);
            }
            return current;
        }

        private Node balance_tree(Node current)
        {
            int b_factor = balance_factor(current);
            if (b_factor > 1)
            {
                if (balance_factor(current.left) > 0)
                {
                    current = RotateLL(current);
                }
                else
                {
                    current = RotateLR(current);
                }
            }
            else if (b_factor < -1)
            {
                if (balance_factor(current.right) > 0)
                {
                    current = RotateRL(current);
                }
                else
                {
                    current = RotateRR(current);
                }
            }
            return current;
        }

        public void Delete(string target)
        {//and here
            root = Delete(root, target);
        }

        private Node Delete(Node current, string target)
        {
            Node parent;
            if (current == null)
            { return null; }
            else
            {
                //left subtree
                if (String.Compare(target, current.data) < 0)
                {
                    current.left = Delete(current.left, target);
                    if (balance_factor(current) == -2)//here
                    {
                        if (balance_factor(current.right) <= 0)
                        {
                            current = RotateRR(current);
                        }
                        else
                        {
                            current = RotateRL(current);
                        }
                    }
                }
                //right subtree
                else if (String.Compare(target, current.data) > 0)
                {
                    current.right = Delete(current.right, target);
                    if (balance_factor(current) == 2)
                    {
                        if (balance_factor(current.left) >= 0)
                        {
                            current = RotateLL(current);
                        }
                        else
                        {
                            current = RotateLR(current);
                        }
                    }
                }
                //if target is found
                else
                {
                    if (current.right != null)
                    {
                        //delete its inorder successor
                        parent = current.right;
                        while (parent.left != null)
                        {
                            parent = parent.left;
                        }
                        current.data = parent.data;
                        current.right = Delete(current.right, parent.data);
                        if (balance_factor(current) == 2)//rebalancing
                        {
                            if (balance_factor(current.left) >= 0)
                            {
                                current = RotateLL(current);
                            }
                            else { current = RotateLR(current); }
                        }
                    }
                    else
                    {   //if current.left != null
                        return current.left;
                    }
                }
            }
            return current;
        }

        public virtual void Contains(Node current, string value, ref int count)
        {
            if (current != null)
            {
                count++;
                if (current.data == value)
                {
                    for (int i = 0; i < AllForm.UsersGridView.Rows.Count; i++)
                    {
                        string l = AllForm.UsersGridView.Rows[i].Cells[0].Value.ToString();
                        if (l == value) AllForm.UsersGridView.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    MessageBox.Show($"{count} - сравнений");
                }
                if (String.Compare(value, current.data) <= 0) Contains(current.left, value, ref count);
                if (String.Compare(value, current.data) >= 0) Contains(current.right, value, ref count);
            }
        }

        private int max(int l, int r)
        {
            return l > r ? l : r;
        }

        private int getHeight(Node current)
        {
            int height = 0;
            if (current != null)
            {
                int l = getHeight(current.left);
                int r = getHeight(current.right);
                int m = max(l, r);
                height = m + 1;
            }
            return height;
        }

        private int balance_factor(Node current)
        {
            int l = getHeight(current.left);
            int r = getHeight(current.right);
            int b_factor = l - r;
            return b_factor;
        }

        private Node RotateRR(Node parent)
        {
            Node pivot = parent.right;
            parent.right = pivot.left;
            pivot.left = parent;
            return pivot;
        }

        private Node RotateLL(Node parent)
        {
            Node pivot = parent.left;
            parent.left = pivot.right;
            pivot.right = parent;
            return pivot;
        }

        private Node RotateLR(Node parent)
        {
            Node pivot = parent.left;
            parent.left = RotateRR(pivot);
            return RotateLL(parent);
        }

        private Node RotateRL(Node parent)
        {
            Node pivot = parent.right;
            parent.right = RotateLL(pivot);
            return RotateRR(parent);
        }
    }
}