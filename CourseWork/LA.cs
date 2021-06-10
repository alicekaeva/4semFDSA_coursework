using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public class LA : IEquatable<LA>
    {

        public string login;
        public string address;

        public LA(string l, string a)
        {
            this.login = l;
            this.address = a;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            LA objAsPart = obj as LA;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals(LA other)
        {
            if (other == null) return false;
            return (this.login.Equals(other.login) && this.address.Equals(other.address));
        }

        public override int GetHashCode()
        {
            int Count = 0;
            for (int i = 0; i < this.login.Length; i++) Count += (int)this.login[i];
            for (int i = 0; i < this.address.Length; i++) Count += (int)this.address[i];
            return Count;
        }
    }
}
