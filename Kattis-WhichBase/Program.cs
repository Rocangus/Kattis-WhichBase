using System;

namespace Kattis_WhichBase
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputData;
            int[] decimals, octals, hexadecimals;
            GetDataSets(out inputData, out decimals, out octals, out hexadecimals);
            ProcessDataSets(inputData, decimals, octals, hexadecimals);
            PrintOutput(inputData, decimals, octals, hexadecimals);
        }

        private static void GetDataSets(out string[] inputData, out int[] decimals, out int[] octals, out int[] hexadecimals)
        {
            var dataSizeString = Console.ReadLine();
            var dataSizeInt = int.Parse(dataSizeString);
            inputData = new string[dataSizeInt];
            decimals = new int[dataSizeInt];
            octals = new int[dataSizeInt];
            hexadecimals = new int[dataSizeInt];
            for (int i = 0; i < inputData.Length; i++)
            {
                inputData[i] = Console.ReadLine();
            }
        }

        private static void ProcessDataSets(string[] inputData, int[] decimals, int[] octals, int[] hexadecimals)
        {
            for (int i = 0; i < inputData.Length; i++)
            {
                var tokens = inputData[i].Split();
                var number = int.Parse(tokens[1]);
                decimals[i] = number;
                var workingValue = number;
                int digitTotal = FindDigitTotal(number);
                ProcessAsOctal(octals, i, tokens, number, digitTotal);
                ProcessAsHexadecimal(hexadecimals, i, number, digitTotal);
            }
        }


        private static int FindDigitTotal(int number)
        {
            int digitTotal = 0;
            while (Math.Pow(10, digitTotal) < number)
            {
                digitTotal++;
            }

            return digitTotal;
        }

        private static void ProcessAsOctal(int[] octals, int i, string[] tokens, int number, int digitTotal)
        {
            if (tokens[1].Contains('9'))
            {
                octals[i] = 0;
            }
            else
            {
                octals[i] = GetDecimalValueForBaseNInterpretation(number, digitTotal, 8);
            }
        }

        private static void ProcessAsHexadecimal(int[] hexadecimals, int i, int number, int digitTotal)
        {
            hexadecimals[i] = GetDecimalValueForBaseNInterpretation(number, digitTotal, 16);
        }

        private static int GetDecimalValueForBaseNInterpretation(int number, int digitTotal, int numberBase)
        {
            var decimalValue = 0;
            for (int n = 0; n < digitTotal; n++)
            {
                int digit = number / (int) Math.Ceiling(Math.Pow(10, n)) % 10;
                decimalValue += digit * (int)Math.Pow(numberBase, n);
                number -= digit;
            }

            return decimalValue;
        }
        private static void PrintOutput(string[] inputData, int[] decimals, int[] octals, int[] hexadecimals)
        {
            for (int i = 0; i < inputData.Length; i++)
            {
                Console.WriteLine($"{i + 1} {octals[i]} {decimals[i]} {hexadecimals[i]}");
            }
        }

    }
}
