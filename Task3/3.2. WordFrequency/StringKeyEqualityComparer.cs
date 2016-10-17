using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._2.WordFrequency
{    
    class StringKeyEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return String.Compare(x, y, true) == 0;
        }

        public int GetHashCode(string obj)
        {
            return obj.Length;
        }
    }
}
