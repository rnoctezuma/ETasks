using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._4.MyString
{
    class Program
    {
        static void Main(string[] args)
        {
            MyString myString = new MyString(new char [] { 'a', 'A' , 'b', 'c'});

            MyString myString1 = new MyString(new char[] { 'a', 'b', 'c', 'n' });

            MyString me = (MyString)(new char[] { 'a', 'A', 'b', 'c' });

            char[] ara = myString1;
            Console.WriteLine(ara);
        }
    }
}
