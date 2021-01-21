using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module17Task2
{   
    class NumberReader
    {
        public delegate void NumEnteredDelegate(int number);
        public event NumEnteredDelegate NumEnteredEvent;
        public void Read()
        {
            Console.WriteLine("1 или 2");

            int number = Convert.ToInt32(Console.ReadLine());

            if (number != 1 && number != 2) throw new FormatException();

            NumberEntered(number);
        }

        protected virtual void NumberEntered(int number)
        {
            NumEnteredEvent?.Invoke(number);
        }
    }
    class Program
    {      
        static void Main(string[] args)
        {
            NumberReader numberReader = new NumberReader();
            numberReader.NumEnteredEvent += ShowNumber;
            {
               while(true)
                try
                {
                    numberReader.Read();               
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неправильное значение");
                }
            }         
        }
        static void ShowNumber(int number)
        {
            string[] name = { "Антипов", "Георгиев","Биб", "Яковлев" };
            switch (number)
            {
                case 1:
                    Console.WriteLine("Введено 1");
                    Array.Sort(name);
                    for (int i = 0; i < name.Length; i++)
                        Console.WriteLine("{0}", name[i]);
                    break;
                case 2:
                    Console.WriteLine("Введено 2");
                    Array.Sort(name);
                    Array.Reverse(name);
                    for (int i = 0; i < name.Length; i++)
                        Console.WriteLine("{0}", name[i]);
                    break;
            }
        }
    }
}
