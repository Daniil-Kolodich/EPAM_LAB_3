using System;
/*
    Вариант 7
    Ромб
    Получение площади, длины стороны, периметра по двум диагоналям
 */
namespace _Rhombus {
    class Program {
        static void Main(string[] args) {
            float a, b;
            Rhombus romb;
            while (true) {
                Console.WriteLine("Enter sizes of two diagonals");
                try {
                    a = float.Parse(Console.ReadLine());
                    b = float.Parse(Console.ReadLine());
                    romb = new Rhombus(a, b);
                    break;
                }
                catch (FormatException) {
                    Console.WriteLine("Invalid input\n");
                }
                catch (ArgumentException ex) {
                    Console.WriteLine(ex.Message + "\n");
                }
            }

            romb.Info();
        }
    }
    class Rhombus {
        private float firstDiagonal;
        private float secondDiagonal;
        // a = sqrt(sqr(d_1 / 2) + sqr(d_2 / 2));	 
        private float side;

        private float FirstDiagonal {
            get {
                return firstDiagonal;
            }
            set {
                if (value <= 0)
                    throw new ArgumentException("Wrong data");
                firstDiagonal = value;
            }
        }
        private float SecondDiagonal {
            get {
                return secondDiagonal;
            }
            set {
                if (value <= 0)
                    throw new ArgumentException("Wrong data");
                secondDiagonal = value;
            }
        }

        public Rhombus(float firstDiagonal, float secondDiagonal) {
            this.FirstDiagonal = firstDiagonal;
            this.SecondDiagonal = secondDiagonal;
            side = (float)Math.Sqrt(FirstDiagonal * FirstDiagonal / 4 + SecondDiagonal * SecondDiagonal / 4);
        }

        public void Info() {
            Console.WriteLine("\nInfo:");
            Console.WriteLine($"\tfirst diagonal = {FirstDiagonal}");
            Console.WriteLine($"\tsecond diagonal = {SecondDiagonal}");
            Console.WriteLine($"\tlength of side = {side: #.###}");
            Console.WriteLine($"\tPerimeter = {this.GetPerimeter(): #.###}");
            Console.WriteLine($"\tArea = {this.GetArea(): #.###}");
        }

        public float GetPerimeter() {
            return side * 4;
        }

        public float GetArea() {
            // S = d_1 * d_2 / 2;
            return FirstDiagonal * SecondDiagonal / 2;
        }
    }
}
