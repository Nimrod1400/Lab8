using System;
using System.Collections.Generic;


namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Быков Игнат Всеволодович", "Фомин Мартын Степанович",
                "Коновалов Даниил Митрофанович", "Харитонов Панкрат Улебович",
                "Попов Денис Мэлорович", "Абрамов Николай Львович", "Степанов Эльдар Матвеевич",
                "Рогов Вальтер Вадимович", "Большаков Бенедикт Данилович", "Жмыхов Валерий Альбертович",
                "Шамрай Вадим Викторович", "Узунов Эдуард Геевич", "ТыМошонка Никита Сергеевич", };
            // сверху список фио покупателей (при необходимости расширить)

            Console.Write($"У нас {names.Length} покупателей. Сколько на складе машин? ");
            byte amountOfCars = Convert.ToByte(Console.ReadLine());
                        
            Random r = new Random();            

            FactoryAF factory = new FactoryAF { R = r };
            Customer[] cs = new Customer[names.Length]; // массив, который будет передан в поле Customers объекта factory

            for (byte i=0; i<names.Length; i++) // цикл для добавления покупателей в массив
            {
                Customer c = new Customer() { Initials = names[i] };
                cs[i] = c;
            } 

            factory.Customers.AddRange(cs); // передача полю Customers массива cs

            for (byte n = 0; n < amountOfCars; n++) // цикл добавления машин в поле Vehicles объекта factory
            {
                factory.AddCar(n);
            }

            while (true) // главный цикл программы
            {
                factory.SaleCar();
            }
        }                
    }
}
