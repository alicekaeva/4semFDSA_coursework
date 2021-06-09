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
        public string adress;
        public LA(string l, string a)
        {
            this.login = l;
            this.adress = a;
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
            return (this.login.Equals(other.login) && this.adress.Equals(other.adress));
        }
        public override int GetHashCode()
        {
            int Count = 0;
            for (int i = 0; i < this.login.Length; i++) Count += (int)this.login[i];
            for (int i = 0; i < this.adress.Length; i++) Count += (int)this.adress[i];
            return Count;
        }
    }
}
