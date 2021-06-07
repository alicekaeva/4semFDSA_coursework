using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    class Sales
    {
        public string login;
        public string address;
        public string nameOfProduct;
        public int price;
        public bool typeOfPayment;

        public Sales(string login, string address, string name, int price, bool type)
        {
            this.login = login;
            this.address = address;
            this.nameOfProduct = name;
            this.price = price;
            this.typeOfPayment = type;
        }
    }
}
