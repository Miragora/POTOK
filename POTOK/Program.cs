using System;
using System.Threading;
using System.Collections.Generic;

namespace Time
{
    class TimeProgram
    {
        static void Main()
        {
            //TimeUpdates();
            Thread time_thread = new Thread(TimeUpdates);
            time_thread.Name = "Timer";
            time_thread.Priority = ThreadPriority.BelowNormal;
            time_thread.IsBackground = true;
            time_thread.Start();

            Console.WriteLine("Введите число, до которого будем искать простые числа");
            var a_str = Console.ReadLine();
            var a = int.Parse(a_str);
            var start = DateTime.Now; //начало времени поиска простых чисел
            var prime_numbes = GetPrimeNumbers(a);
            var stop = DateTime.Now; // конец процесса
            var time = stop - start;
            Console.WriteLine("время процесса {0}", time);
            Console.WriteLine(string.Join(",", prime_numbes));

            Console.ReadLine();
        }

        static void TimeUpdates()
        {
            while(true)
            {
                Console.Title = DateTime.Now.ToString();
                Thread.Sleep(100);
            }
        }

        static List<int> GetPrimeNumbers(int N)
        {
            var result = new List<int>(N/2);

            for (var i = 2; i <= N; i++)
            {
                var is_prime = true;
                foreach(var x in result)
                    if(i % x == 0) //% - деление без остатка
                    {
                        is_prime = false;
                        break;    //прерывание цикл проверки
                    }
                if (is_prime) result.Add(i); //если число простое - добавляем в цикл

                
            }

            return result;
        }
    }
}
