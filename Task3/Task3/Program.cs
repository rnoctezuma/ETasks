using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Program
    {
        private static void Effacement(Queue<Person> persons)
        {
            int count = 1;
            while (persons.Count != 1)
            {
                Person temp = persons.Dequeue();
                if (count % 2 != 0)
                {
                    persons.Enqueue(temp);
                    Console.WriteLine("Added {0}", temp.ShowPerson());
                }
                count++;
            }
        }

        private static void Main(string[] args)
        {
            int N = 10;
            Queue<Person> persons = new Queue<Person>(N);
            for (int i = 1; i <= N; i++)
            {
                Person temp = new Person(i);
                persons.Enqueue(temp);
                Console.Write(temp.ShowPerson());
            }
            Console.WriteLine();
            Effacement(persons);
            Console.WriteLine();
            Console.WriteLine("Queue count - {0}; Leftover person - {1}", persons.Count, persons.Peek().ShowPerson());
        }
    }
}