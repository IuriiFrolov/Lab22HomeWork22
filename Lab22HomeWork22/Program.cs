using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab22HomeWork22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размер массива:");
            int n = Convert.ToInt32(Console.ReadLine());

            Task<int[]> task1 = new Task<int[]>(() => Method1(n));

            // задача продолжения
            Task task2 = task1.ContinueWith(arrayT => Method2(arrayT.Result, n));

            task1.Start();

            // ждем окончания второй задачи
            task2.Wait();
            Console.WriteLine("Метод Main окончил работу");
            Console.ReadLine();
        }

        static int[] Method1(int a)
        {
            int[] arrayT = new int[a];
            Random random = new Random();

            for (int i = 0; i < a; i++)
            {
                arrayT[i] = random.Next(0, 10);
                Console.WriteLine("{0,4}", arrayT[i]);
            }
            Console.WriteLine("Method 1 окончил работу");
            return arrayT;
        }

        static void Method2(int[] arrayS, int n)
        {
            Console.WriteLine();

            int sum = 0;
            int max = 0;

            for (int i = 0; i < n; i++)
            {
                sum += arrayS[i]; // Суммирование
                if (arrayS[i] > max) // Ищем максимальное
                {
                    max = arrayS[i];
                }
            }
            Console.WriteLine("Сумма чисел  = {0,3}", sum);
            Console.WriteLine("Максимальное число  = {0,3}", max);
            Console.WriteLine("Method 2 окончил работу");
        }
    }
}
