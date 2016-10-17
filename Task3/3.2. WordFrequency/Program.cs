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
            string[] splitText = text.Split(new char[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < splitText.Length; i++)
            {

                if (!wordsFrequency.ContainsKey(splitText[i]))
                    wordsFrequency.Add(splitText[i], 1);
                else
                    wordsFrequency[splitText[i]]++;
            }
            foreach (var item in wordsFrequency)
            {
                Console.WriteLine("{0} {1:P2}", item.Key, (double)item.Value/splitText.Length);
            }
        }
    }
}