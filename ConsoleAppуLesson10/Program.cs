using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppуLesson10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Angle angle = new Angle();
            double andleRad = 0;
            int temp;

            Console.WriteLine("Введите значение угла раздельно градусы-минутыц-секунды");
            Console.WriteLine();

            Console.Write(" Введите целое число градусов, знак определяет направление вращения : ");
            temp = Convert.ToInt32(Console.ReadLine());
            angle.Gradus = temp;
           
            Console.Write(" Введите целое неотрицательное число угловых минут, менее 60 : ");
            temp = Convert.ToInt32(Console.ReadLine());
            angle.Minets = temp;
            
            Console.Write(" Введите целое неотрицательное число угловых секунд, менее 60 : ");
            temp = Convert.ToInt32(Console.ReadLine());
            angle.Seconds = temp;
            Console.WriteLine();

            andleRad = angle.ToRadians();
            Console.WriteLine(" Введенный угол, в радианах, составляет : {0}", andleRad);

            Console.ReadKey();
        }
    }
    class Angle
    {
        int pointer = 1; // Задает направление вращения (в соответствии с тригонометрическим кругом) : + против часовойй стрелки, - по часовой стрелки.
        int gradus; // целое число градусов, знак определяет направление вращения (в соответствии с тригонометрическим кругом).
        int minets; // целое число угловых минут В ДИАППАЗОНЕ [0;60) , отложенное по направлению, заданному знаком gradus, 
        int seconds; // целое число угловых секунд В ДИАППАЗОНЕ [0;60) , отложенное по направлению, заданному знаком gradus, 

        public int Gradus
        {
            set // "Препарируем" значение для раздельного хранения.
            { 
                int g = value;
                if (g < 0)
                { 
                    this.pointer = -1;
                    g = g * (-1);
                }
                this.gradus = g; 
            }
            get // Возвращаем пользовательское значение.
            {
                int g = this.gradus * this.pointer;
                return g; 
            } 
        }
        public int Minets
        {
            set
            {
                if ((value >= 0) & (value < 60))
                {
                    this.minets = value;
                }
                else
                {
                    Console.WriteLine("Значени минут должно быть менее 60 и положительным.");
                }

            }
            get
            { return this.minets; }
        }
        public int Seconds
        {
            set
            {
                if ((value >= 0) & (value < 60))
                {
                    this.seconds = value;
                }
                else
                {
                    Console.WriteLine("Значени секунд должно быть менее 60 и положительным.");
                }

            }
            get
            { return this.minets; }
        }

        public double ToRadians()
        {
            double r;
            r = this.pointer * ( this.gradus + 60 * ( this.minets + 60 * this.seconds ) );
            r = Math.PI *  r / 180;
            return r;

        }


    }
}
