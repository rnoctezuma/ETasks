using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._4.MyString
{
    public class MyString
    {
        public char [] charArray { get; set; }

        public MyString (char[] str)
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
                return this.charArray[index];      //должен ли индексатор обращаться к св-вам?
            }
            set
            {
                this.charArray[index] = value;
            }
        }

        public static MyString operator +(MyString firstString, MyString secondString)
        {
            char[] newStr = new char[firstString.Length + secondString.Length];

            for (int i = 0; i < firstString.Length; i++)
            {
                newStr[i] = firstString[i];
            }

            for (int i = 0; i<secondString.Length;i++)
            {
                newStr[firstString.Length + i] = secondString[i];
            }
            
            return new MyString(newStr);
        }

        public void ChangeElement(int position, char newValue)
        {
            this.charArray[position] = newValue;
        }

        public char [] ToCharArray()
        {
            return this.charArray;
        }

    //    public static void


        /*   
           public override bool Equals(string obj)
           {
               return base.Equals(obj);
           }
   */
        //public override string ToString()
        //{
        //    return 
        //}

    }
}
