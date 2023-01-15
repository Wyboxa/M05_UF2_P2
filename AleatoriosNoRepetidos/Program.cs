using System;
using System.Collections.Generic;

namespace AleatoriosNoRepetidos
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int units = 0;
            Console.WriteLine("How many units do you want?");
            while (units < 1)
            {
                try
                {
                    units = int.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Porfavor coloca un numero");
                }
                catch (NullReferenceException ex)
                {

                }
                catch (Exception ex)
                {

                }
                finally
                {
                    if (units < 1)
                        Console.WriteLine("Introduce una unidad mas grande");
                }
            }
            int ammount = 0;
            Console.WriteLine("How many numbers do you want?");

            int.TryParse(Console.ReadLine(), out ammount);

            ammount = int.Parse(Console.ReadLine());

            Console.Clear();
            Random random = new Random();
            for (int i = 0; i < ammount; i++)
            {
                AddNumber(random, units, numbers);
            }

            Console.WriteLine("Finished!");
        }
        public static void AddNumber(Random random, int units, List<int> numbers)
        {
            int number = random.Next(10 * units);
            int tries = 100;
            while (numbers.Contains(number) && tries <= 0)
            {
                number = random.Next(10 * units);
                tries--;
            }
            numbers.Add(number);
            Console.WriteLine(number);
        }
    }
}
