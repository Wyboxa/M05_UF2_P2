using System;
using System.Collections.Generic;

namespace SetsAleatorios
{
    class Program
    {
        static SetAleatorio set;
        static void Main(string[] args)
        {
            int sets = 0;
            Console.WriteLine("How many sets do you want?");
            sets = int.Parse(Console.ReadLine());
            for (int i = 0; i < sets; i++)
            {
                SetAleatorio temp = set;
                set = new SetAleatorio();
                set.prevSet = temp;
                Console.WriteLine("Set " + i + ": " + set.numbers.Count + " números.");
                for (int j = 0; j < set.numbers.Count; j++)
                {
                    if (j != 0)
                        Console.Write(", ");
                    Console.Write(set.numbers[j]);
                }
            }
        }
    }
    class SetAleatorio
    {
        public SetAleatorio prevSet;
        public List<int> numbers = new List<int>();
        public SetAleatorio()
        {
            Random rand = new Random();
            for (int i = 0; i < 100000; i++)
            {
                numbers.Add(rand.Next());
            }
        }
    }
}
