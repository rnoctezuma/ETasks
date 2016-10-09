using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._4.MyString
{
    public class MyString
    {
        public char[] charArray { get; set; }

        public MyString(char[] str)
        {
            this.charArray = str;
        }

        public int Length
        {
            get { return this.charArray.Length; }
        }

        public char this[int index]
        {
            get
            {
                return this.charArray[index];
            }
            set
            {
                this.charArray[index] = value;
            }
        }

        public static int Compare(MyString firstString, MyString secondString)    //firstString > secondString -> 1; firstString < secondString -> -1;
        {                                                                         //firstString == secondString -> 0;
            if (firstString.Length > secondString.Length)
                return 1;
            if (firstString.Length < secondString.Length)
                return -1;
            for (int i = 0; i < firstString.Length; i++)
            {
                if (firstString[i] > secondString[i])
                    return 1;
                if (firstString[i] < secondString[i])
                    return -1;
            }
            return 0;
        }

        public override bool Equals(object secondString)
        {
            if (Compare(this, secondString as MyString) == 0)
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return this.charArray.GetHashCode();
        }

        public static bool operator <(MyString firstString, MyString secondString)
        {
            if (Compare(firstString, secondString) == -1)
                return true;
            return false;
        }

        public static bool operator >(MyString firstString, MyString secondString)
        {
            if (Compare(firstString, secondString) == 1)
                return true;
            return false;
        }

        public override string ToString()
        {
            return new string(this.charArray);
        }

        public static explicit operator MyString(char[] charArray)
        {
            return new MyString(charArray);
        }

        public static implicit operator char[] (MyString myString)
        {
            char[] charArray = new char[myString.Length];
            Array.Copy(myString.charArray, charArray, myString.Length);
            return charArray;
        }

        public int IndexOf(char searchElem)
        {
            return Array.IndexOf(this.charArray, searchElem);
        }

        public static MyString operator +(MyString firstString, MyString secondString)
        {
            char[] newStr = new char[firstString.Length + secondString.Length];
            Array.Copy(firstString.charArray, newStr, firstString.Length);
            Array.Copy(secondString.charArray, 0, newStr, firstString.Length, secondString.Length);
            return new MyString(newStr);
        }
    }
}