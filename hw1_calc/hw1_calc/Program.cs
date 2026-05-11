public class Calc
{
    static void Main()
    {
        while (true)
        {
            double num1 = 0;
            bool exit1 = false;
            while (true)
            {
                Console.WriteLine("Введите первое число (или q чтобы завершить):");
                string num1_str = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(num1_str))
                {
                    Console.WriteLine("Пустой ввод");
                    continue;
                }
                if (num1_str == "q")
                {
                    exit1 = true;
                    break;
                }
                if (double.TryParse(num1_str, out num1))
                {
                    break;
                }
                Console.WriteLine("Неверный формат ввода");
            }

            if (exit1)
            {
                break;
            }
            
            double num2 = 0;
            bool exit2 = false;
            while (true)
            {
                Console.WriteLine("Введите второе число (или q чтобы завершить):");
                string num2_str = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(num2_str))
                {
                    Console.WriteLine("Пустой ввод");
                    continue;
                }
                if (num2_str == "q")
                {
                    exit2 = true;
                    break;
                }
                if (double.TryParse(num2_str, out num2))
                {
                    break;
                }
                Console.WriteLine("Неверный формат ввода");
            }

            if (exit2)
            {
                break;
            }
            
            double res = 0;
            bool exit3 = false;
            bool success_flag = false;
            while (true)
            {
                Console.WriteLine("Выберите тип операции (+, -, *, /):");
                string operation = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(operation))
                {
                    Console.WriteLine("Пустой ввод");
                    continue;
                }
                if (operation == "q")
                {
                    exit3 = true;
                    break;
                }
                switch (operation)
                {
                    case "+":
                        res = num1 + num2;
                        success_flag = true;
                        break;

                    case "-":
                        res = num1 - num2;
                        success_flag = true;
                        break;

                    case "*":
                        res = num1 * num2;
                        success_flag = true;
                        break;

                    case "/":
                        if (num2 == 0)
                        {
                            Console.WriteLine("Произошло деление на ноль");
                            continue;
                        }
                        res = num1 / num2;
                        success_flag = true;
                        break;

                    default:
                        Console.WriteLine("Неизвестная операция");
                        continue;
                }

                if (success_flag)
                {
                    break;
                }
            }

            if (exit3)
            {
                break;
            }
            

            Console.WriteLine($"Результат: {res}");
            Console.WriteLine();
        }

        Console.WriteLine("Программа завершена");
    }
}
