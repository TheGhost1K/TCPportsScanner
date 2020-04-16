using System;
using System.Linq;
using System.Net.NetworkInformation;

namespace TCPScanner
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Сканер портов TCP" + "\n" + "Выполнил Лоскутов Максим МО-202, МЕН-282203"
                + "\n" + "Программа выводит список открытых портов в заданном диапазоне"
                + "\n" + "Если открытых портов не надено, то программа ничего не выведет" + "\n");

            Console.WriteLine("Введите начальный порт: ");
            var start = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите конечный порт: ");
            var end = int.Parse(Console.ReadLine());

            if (start >= end) Console.WriteLine("Начальный порт должен быть меньше конечного");
            else
            {
                for (int i = start; i <= end; i++)
                {
                    var port = IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpListeners()
                        .Any(z => z.Port == i);
                    if (port == true)
                    {
                        Console.WriteLine("Port №" + i.ToString() + " is open");
                    }
                }
            }
            Console.WriteLine("Для выхода нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
