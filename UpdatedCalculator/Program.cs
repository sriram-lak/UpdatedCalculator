//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
class Program
{
    static void Main(String[] args)
    {
        double result = 0;
        bool loop = true;
        Console.WriteLine("\n Calculator App \n press e : Exit the App \n Press c : Reset 0 \n");
        while (loop)
        {
            String text = Console.ReadLine();
            if (text == "e")
            {
                loop = false;
            }
            else if ((text == "c"))
            {
                result = 0;
            }
            else
            {
                result = calculate(text, result);
                Console.WriteLine(result);
            }
        }
    }
    static double calculate(String text, double final_result)
    {
        double result = final_result;
        String current_number = "";
        char current_operation = '+';

        for (int i = 0; i < text.Length; i++)
        {
            char letter = text[i];
            if (Char.IsDigit(letter) || letter == '.')
            {
                current_number = current_number + letter;
            }
            if ((!Char.IsDigit(letter) && (letter != '.')) || i == text.Length - 1)
            {
                if (!Char.IsDigit(letter))
                {
                    double current_value = 0;
                    try { current_value = Convert.ToDouble(current_number); }
                    catch { current_value = 0; }
                    result = operation(current_operation, result, current_value);
                    if (letter != '=')
                    {
                        current_operation = letter;
                    }
                    current_number = "";


                }
                else if (i == text.Length - 1)
                {
                    double current_value = Convert.ToDouble(current_number);
                    result = operation(current_operation, result, current_value);
                }
            }
        }
        return result;
    }
    static double operation(char symbol, double result, double current_number)
    {
        if (symbol == '+')
        {
            return result + current_number;
        }
        else if (symbol == '-')
        {
            return result - current_number;
        }
        else if (symbol == '*')
        {
            return result * current_number;
        }
        else if (symbol == '/')
        {
            try
            {
                return result / current_number;
            }
            catch { Console.WriteLine("Invalid Input"); }

        }
        return current_number;
    }
}