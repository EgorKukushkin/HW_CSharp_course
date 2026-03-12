public class Calc()
{
    static void Main()
    {
        for(;;)
        {
            Console.WriteLine("Введите первое число (или q чтобы завершить):");
            string num1_str = Console.ReadLine();

            if (num1_str == "q")
                break;

            double num1 = Convert.ToDouble(num1_str);

            Console.WriteLine("Введите второе число (или q чтобы завершить):");
            string num2_str = Console.ReadLine();

            if (num2_str == "q")
                break;

            double num2 = Convert.ToDouble(num2_str);

            Console.WriteLine("Выберите тип операции (+, -, *, /):");
            string operation = Console.ReadLine();
            
            if (operation == "q")
                break;

            double res = 0;

            switch (operation)
            {
                case "+":
                    res = num1 + num2;
                    break;

                case "-":
                    res = num1 - num2;
                    break;

                case "*":
                    res = num1 * num2;
                    break;

                case "/":
                    if (num2 == 0)
                    {
                        Console.WriteLine("Произошло деление на ноль");
                        continue;
                    }
                    res = num1 / num2;
                    break;

                default:
                    Console.WriteLine("Неизвестная операция");
                    continue;
            }

            Console.WriteLine($"Результат: {res}");
            Console.WriteLine();
        }

        Console.WriteLine("Программа завершена");
    }
}