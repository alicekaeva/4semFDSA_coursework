using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public class Sales : IEquatable<Sales>
    {
        public string login;
        public string address;
        public string nameOfProduct;
        public int price;
        public string typeOfPayment;

        public Sales(string login, string address, string name, int price, string type)
        {
            this.login = login;
            this.address = address;
            this.nameOfProduct = name;
            this.price = price;
            this.typeOfPayment = type;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Sales objAsPart = obj as Sales;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public bool Equals(Sales other)
        {
            if (other == null) return false;
            return (this.login.Equals(other.login) && this.address.Equals(other.address) && this.nameOfProduct.Equals(other.nameOfProduct) && this.price.Equals(other.price) && this.typeOfPayment.Equals(other.typeOfPayment));
        }
        public override int GetHashCode()
        {
            int Count = 0;
            for (int i = 0; i < this.login.Length; i++) Count += (int)this.login[i];
            for (int i = 0; i < this.address.Length; i++) Count += (int)this.address[i];
            for (int i = 0; i < this.nameOfProduct.Length; i++) Count += (int)this.nameOfProduct[i];
            for (int i = 0; i < this.typeOfPayment.Length; i++) Count += (int)this.typeOfPayment[i];
            return Count + price;
        }
    }
}
