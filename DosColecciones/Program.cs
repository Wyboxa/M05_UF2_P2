using System;
using System.Collections.Generic;

namespace DosColecciones
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Elemento> a = new List<Elemento>();
            LinkedList<Elemento> b = new LinkedList<Elemento>();
            for (int i = 0; i < 10; i++)
            {
                Elemento temp = new Elemento();
                temp.num = i;
                a.Add(temp);
            }
            foreach (var item in a)
            {
                b.AddLast(item);
            }
        }
    }
    class Elemento
    {
        public int num;
    }
}
