using System;

namespace Lab8
{
    class Car
    {
        public uint Number { get; set; }
        public Engine Eng { get; set; }
        private Random r;
        public Random R 
        {  
            set
            {
                r = value;
            }
        }

        public Car(uint num, Random r)
        {
            Engine engine = new Engine();
            engine.Size = (uint)(40 + r.Next(-10, 11));
            Eng = engine;
            Number = num;
            R = r;
        }
    }
}
