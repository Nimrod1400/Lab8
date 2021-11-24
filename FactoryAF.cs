using System;
using System.Collections.Generic;


namespace Lab8
{
    class FactoryAF
    {
        public List<Car> Vehicles { get; set; } = new List<Car>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public Random R { get; set; }

        public void AddCar(byte num)
        {            
            Car car = new Car(num, R);
            Vehicles.Add(car);            
        }

        public void SaleCar()
        {
            byte carNum = (byte)R.Next(0, Vehicles.Count); // номер машины, которая сейчас будет продаваться

            List<byte> allowedCusts = new List<byte>(); // индексы людей, у которых нет машины

            allowedCusts = Allowed(); // список индексов для покупателей, у которых нет машины
            
            if (Vehicles.Count != 0 && allowedCusts.Count != 0)
            {
                byte custNum = allowedCusts[R.Next(0, allowedCusts.Count)];
                Customers[custNum].Vehicle = Vehicles[carNum];
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{Customers[custNum].Initials} купил машину под номером {Vehicles[carNum].Number}. " +
                    $"Размер педалей этой машины был равен {Vehicles[carNum].Eng.Size} см.");

                Vehicles.RemoveAt(carNum);
                Console.ResetColor();
            }

            allowedCusts = Allowed(); // обновление индексов покупателей без машины

            if (Vehicles.Count == 0 && allowedCusts.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nПоздравляем! Все машины были распроданы и все покупатели остались удовлетворены.");
                Console.ResetColor();
                Ending();
            }
            if (Vehicles.Count == 0 && allowedCusts.Count != 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nНа складе не осталось машин.");
                Console.WriteLine($"Без автомобиля остались {allowedCusts.Count} человек (человека).");
                Console.ResetColor();
                Ending();
            }            
            if (Vehicles.Count != 0 && allowedCusts.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\nПокупатели закончились, и на складе осталось {Vehicles.Count} машин (машины).");
                Console.ResetColor();
                Ending();
            }
            Console.ReadKey();

            List<byte> Allowed() // возвращает список индексов покупателей, у которых нет машины 
            {
                List<byte> ac = new List<byte>();
                for (byte i = 0; i < Customers.Count; i++)
                {
                    if (Customers[i].Vehicle == null)
                    {
                        ac.Add(i);
                    }
                }
                return ac;
            }
        }
        private void Ending() // обработка завершения программы
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nНажмиите любую клавишу для выхода из программы...");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
