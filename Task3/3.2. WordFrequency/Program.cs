using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._2.WordFrequency
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Dictionary<string, int> wordsFrequency = new Dictionary<string, int>(new StringKeyEqualityComparer());

            string text = "dfeG Dfeg hrtte Hrtte hrTTe hrttE jterg.";
            string[] splitText = text.Split(new char[] { ' ', '.' });

            for (int i = 0; i < splitText.Length; i++)
            {
                if (splitText[i] == String.Empty)
                    continue;

                if (!wordsFrequency.ContainsKey(splitText[i]))
                    wordsFrequency.Add(splitText[i], 1);
                else
                    wordsFrequency[splitText[i]]++;
            }
            foreach (var item in wordsFrequency)
            {
                Console.WriteLine("{0} {1}", item.Key, item.Value);
            }
        }
    }
}