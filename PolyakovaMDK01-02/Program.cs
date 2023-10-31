using System.Numerics;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

namespace BinaryNumber
{
    public class Polyakova
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1 - Перевод из троичной в десятичную систему счисления\n2 - Перевод из троичной в десятичную систему счисления\n3 - Калькулятор двоичных чисел\n4 - Калькулятор троичных чисел ");
                string number = Console.ReadLine();
                if (number != "")
                {
                    if (number == "1")
                    {
                        Console.WriteLine("Введите число в троичной системе счисления");
                        string a = Console.ReadLine();
                        if (IsTernaryNumber(a))
                        {
                            var b = ConvertToDecimal(a);
                            Console.WriteLine($"Результат: {b}");
                        }
                        else
                        {
                            Console.WriteLine("Неправильное число");
                        }
                    }

                    if (number == "2")
                    {
                        try
                        {
                            Console.WriteLine("Введите число в двоичной системе счисления");
                            long a = Convert.ToInt64(Console.ReadLine(), 2);
                            Console.WriteLine($"Результат: {a}");
                        }
                        catch
                        {
                            Console.WriteLine("Неправильное число");
                        }
                    }

                    if (number == "3")
                    {
                        try
                        {
                            Console.WriteLine("Введите двоичное число:");
                            string binaryNumber1 = Console.ReadLine();
                            ulong number1 = Convert.ToUInt64(binaryNumber1, 2);
                            Console.WriteLine("Введите двоичное число:");
                            string binaryNumber2 = Console.ReadLine();
                            ulong number2 = Convert.ToUInt64(binaryNumber2, 2);
                            Console.WriteLine("Введите операнд:");
                            string operand = Console.ReadLine();
                            if (operand == "-")
                            {
                                ulong result = number1 - number2;
                                string resultNumber = DecimalToBinary(result);
                                Console.WriteLine($"Результат: {resultNumber}");
                            }
                            if (operand == "+")
                            {
                                ulong result1 = number1 + number2;
                                string resultNumber1 = DecimalToBinary(result1);
                                Console.WriteLine($"Результат: {resultNumber1}");
                            }
                            if (operand == "*")
                            {
                                ulong result2 = number1 * number2;
                                string resultNumber2 = DecimalToBinary(result2);
                                Console.WriteLine($"Результат: {resultNumber2}");
                            }
                            if (operand == "/")
                            {
                                if (number2 == 0)
                                {
                                    Console.WriteLine("На ноль делить нельзя!");
                                }
                                else
                                {
                                    ulong result3 = number1 / number2;
                                    string resultNumber3 = DecimalToBinary(result3);
                                    if (resultNumber3 == "0")
                                    {
                                        Console.WriteLine("Число не может быть отрицательным");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Результат: {resultNumber3}");
                                    }
                                }
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Неправильное число");
                        }
                    }

                    if (number == "4")
                    {
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Введите троичное число");
                                string ternaryNumber6 = Console.ReadLine();
                                ulong number3 = ConvertToDecimal(ternaryNumber6);
                                if (!IsTernaryNumber(ternaryNumber6))
                                {
                                    Console.WriteLine("Неправильное число");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Введите троичное число");
                                }
                                string ternaryNumber2 = Console.ReadLine();
                                ulong number4 = ConvertToDecimal(ternaryNumber2);
                                if (!IsTernaryNumber(ternaryNumber2))
                                {
                                    Console.WriteLine("Неправильное число");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Введите операнд:");
                                }
                                string operand = Console.ReadLine();
                                if (operand == "-")
                                {
                                    if (number4 > number3)
                                    {
                                        Console.WriteLine("Второе чмсло не может быть больше первого");
                                        break;
                                    }
                                    else
                                    {
                                        ulong result = number3 - number4;
                                        string resultNumber = ConvertToTernary(result);
                                        Console.WriteLine($"Результат: {resultNumber}");
                                        break;
                                    }
                                }
                                if (operand == "+")
                                {
                                    ulong result1 = number3 + number4;
                                    string resultNumber1 = ConvertToTernary(result1);
                                    Console.WriteLine($"Результат: {resultNumber1}");
                                    break;
                                }
                                if (operand == "*")
                                {
                                    ulong result2 = number3 * number4;
                                    string resultNumber2 = ConvertToTernary(result2);
                                    Console.WriteLine($"Результат: {resultNumber2}");
                                    break;
                                }
                                if (operand == "/")
                                {
                                    if (number4 == 0)
                                    {
                                        Console.WriteLine("На ноль делить нельзя!");
                                        break;
                                    }
                                    else
                                    {
                                        if (number3 > number4)
                                        {
                                            ulong result3 = number3 / number4;
                                            string resultNumber3 = ConvertToTernary(result3);
                                            Console.WriteLine($"Результат: {resultNumber3}");
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Второе число не должно быть больше первого");
                                            break;
                                        }
                                    }
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Неправильное число");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Неправильный символ");
                }
            }
        }

        private static bool IsTernaryNumber(string input)
        {
            foreach (char digit in input)
            {
                if (digit != '0' && digit != '1' && digit != '2')
                {
                    return false;
                }
            }
            return true;
        }

        private static ulong ConvertToDecimal(string trojanNumber)
        {
            ulong result = 0;
            ulong baseValue = 3;

            for (int i = 0; i < trojanNumber.Length; i++)
            {
                ulong digit = ulong.Parse(trojanNumber[i].ToString());
                result = result * baseValue + digit;
            }

            return result;
        }

        private static string DecimalToBinary(ulong decimalNumber)
        {
            if (decimalNumber == 0)
            {
                return "0";
            }

            string binary = "";

            while (decimalNumber > 0)
            {
                ulong remainder = decimalNumber % 2;
                binary = remainder + binary;
                decimalNumber /= 2;
            }

            return binary;
        }

        private static string ConvertToTernary(ulong decimalNumber)
        {
            if (decimalNumber == 0)
            {
                return "0";
            }

            string trojan = "";

            while (decimalNumber > 0)
            {
                ulong remainder = decimalNumber % 3;
                trojan = remainder + trojan;
                decimalNumber /= 3;
            }

            return trojan;
        }
    }
}