using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._5.ToIntOrNotToInt
{
    public static class StringExtension
    {
        private static Dictionary<string, Dictionary<int, string>> transitionTable = new Dictionary<string, Dictionary<int, string>>();

        public static bool IsPositiveIntNumber(this string s)
        {
            InitTable(); ////transitionTable.Count == 0
            string current = "S0";
            int countBeforeExp = 0;
            bool isNumber = false;
            List<char> chars = new List<char>();
            for (int i = 0; i < s.Length; i++)
            {
                try
                {
                    int input = -1;
                    if (s[i] >= '1' && s[i] <= '9')
                        input = 0;
                    if (s[i] == '0')
                        input = 1;
                    if (s[i] == '+')
                        input = 2;
                    if (s[i] == 'e' || s[i] == 'E')
                        input = 3;
                    if (s[i] == '.')
                        input = 4;

                    current = transitionTable[current][input];

                    if (current == "S7")
                        countBeforeExp++;

                    if (current == "S10")
                    {
                        if (chars.Count < countBeforeExp)
                            chars.Add(s[i]);
                    }

                    if (i == s.Length - 1 && (current == "S1" || current == "S3" || current == "S10"))
                        isNumber = true;
                }
                catch
                {
                    break;
                }
            }

            int expPower = 0;
            foreach (var item in chars)
            {
                expPower += (item - '0');
            }
            if (expPower < countBeforeExp)
                isNumber = false;
            return isNumber;
        }

        private static void InitTable()
        {
            Dictionary<int, string> temp = new Dictionary<int, string>();
            temp.Add(0, "S1");
            temp.Add(2, "S2");
            transitionTable.Add("S0", temp);  //S0
            temp = new Dictionary<int, string>();
            temp.Add(0, "S3");
            temp.Add(1, "S3");
            temp.Add(3, "S5");
            temp.Add(4, "S4");
            transitionTable.Add("S1", temp);  //S1
            temp = new Dictionary<int, string>();
            temp.Add(0, "S1");
            transitionTable.Add("S2", temp);  //S2
            temp = new Dictionary<int, string>();
            temp.Add(0, "S3");
            temp.Add(1, "S3");
            transitionTable.Add("S3", temp);  //S3
            temp = new Dictionary<int, string>();
            temp.Add(0, "S7");
            transitionTable.Add("S4", temp);  //S4
            temp = new Dictionary<int, string>();
            temp.Add(0, "S3");
            temp.Add(2, "S6");
            transitionTable.Add("S5", temp);  //S5
            temp = new Dictionary<int, string>();
            temp.Add(0, "S3");
            transitionTable.Add("S6", temp);  //S6
            temp = new Dictionary<int, string>();
            temp.Add(0, "S7");
            temp.Add(1, "S7");
            temp.Add(3, "S8");
            transitionTable.Add("S7", temp);  //S7
            temp = new Dictionary<int, string>();
            temp.Add(0, "S10");
            temp.Add(2, "S9");
            transitionTable.Add("S8", temp);  //S8
            temp = new Dictionary<int, string>();
            temp.Add(0, "S10");
            transitionTable.Add("S9", temp);  //S9
            temp = new Dictionary<int, string>();
            temp.Add(0, "S10");
            temp.Add(1, "S10");
            transitionTable.Add("S10", temp);  //S10
        }
    }
}