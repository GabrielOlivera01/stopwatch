using System;
using System.Threading;

namespace StopWatch
{
    class Program
    {
        static void Main(string[] args)
        {
            int operacao = Menu();

            switch (operacao)
            {
                case 1:
                    StopWatch();
                    break;
                case 0:
                    Console.Clear();
                    System.Environment.Exit(0);
                    break;
            }
        }
        static int Menu()
        {
            Console.Clear();
            Console.WriteLine("1 - Iniciar Cronômetro");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("----------------------");

            int resposta = int.Parse(Console.ReadLine());

            return resposta;
        }
        static void StopWatch()
        {
            int hours = 0;
            int minutes = 0;
            int seconds = 0;
            bool hoursLessThanOrEqualToNine = false;
            bool minutesLessThanOrEqualToNine = false;
            bool secondsLessThanOrEqualToNine = false;

            //Default: 00:00:00
            while (true)
            {
                //Tempo de espera em milísegundos
                Thread.Sleep(1000);

                secondsLessThanOrEqualToNine = (seconds <= 9 ? true : false);
                minutesLessThanOrEqualToNine = (minutes <= 9 ? true : false);
                hoursLessThanOrEqualToNine = (hours <= 9 ? true : false);

                Console.Clear();
                string? msgStart = "Parar = Ctrl + C";
                Console.WriteLine(msgStart);

                if (secondsLessThanOrEqualToNine || minutesLessThanOrEqualToNine || hoursLessThanOrEqualToNine)
                {
                    if (secondsLessThanOrEqualToNine && minutesLessThanOrEqualToNine && hoursLessThanOrEqualToNine)
                    {//Acrecentar 0 no primeiro digíto das horas, minutos e segundos.
                        Console.WriteLine($"0{hours}:0{minutes}:0{seconds}");
                    }
                    else if (hoursLessThanOrEqualToNine && minutesLessThanOrEqualToNine)
                    {//Acrecentar 0 no primeiro digíto das horas e minutos.
                        Console.WriteLine($"0{hours}:0{minutes}:{seconds}");
                    }
                    else if (hoursLessThanOrEqualToNine && secondsLessThanOrEqualToNine)
                    {//Acrecentar 0 no primeiro digíto das horas e segundos.
                        Console.WriteLine($"0{hours}:{minutes}:0{seconds}");
                    }
                    else if (minutesLessThanOrEqualToNine && secondsLessThanOrEqualToNine)
                    {//Acrecentar 0 no primeiro digíto dos minutos e segundos.
                        Console.WriteLine($"{hours}:0{minutes}:0{seconds}");
                    }
                    else if (hoursLessThanOrEqualToNine)
                    {//Acrecentar 0 no primeiro digíto das horas.
                        Console.WriteLine($"0{hours}:{minutes}:{seconds}");
                    }
                    else if (minutesLessThanOrEqualToNine)
                    {//Acrecentar 0 no primeiro digíto dos minutos.
                        Console.WriteLine($"{hours}:0{minutes}:{seconds}");
                    }
                    else if (secondsLessThanOrEqualToNine)
                    {//Acrecentar 0 no primeiro digíto dos segundos.
                        Console.WriteLine($"{hours}:{minutes}:0{seconds}");
                    }
                }
                else
                {//Não acressenta nada pois horas, minutos e segundos possuem 2 digitos. 
                    Console.WriteLine($"{hours}:{minutes}:{seconds}");
                }

                seconds++;

                if (seconds == 60)
                {
                    minutes += 1;
                    seconds = 0;

                    if (minutes == 60)
                    {
                        hours += 1;
                        minutes = 0;
                    }
                }
            }
        }
    }
}