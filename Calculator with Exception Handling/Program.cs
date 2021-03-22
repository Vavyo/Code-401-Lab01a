using System;

namespace Calculator_with_Exception_Handling
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StartSequence();
            } 
            catch(Exception e)
            {
                Console.WriteLine("Something didn't quite go right: " + e.Message);
            }
            finally
            {
                Console.WriteLine("The program has finished executing.");
            }
        }

        private static void StartSequence()
        {
            Console.WriteLine("Enter a number greater than zero:");
            int userNum = 0;
            try
            {
                userNum = Convert.ToInt32(Console.ReadLine());

                int[] userArray = new int[userNum];

                userArray = Populate(userArray);
                int arraySum = GetSum(userArray);
                int arrayProd = GetProduct(userArray, arraySum);
                decimal arrayQuotient = GetQuotient(arrayProd);

                Console.WriteLine($"Your Array size is size: {userArray.Length}");
                Console.WriteLine($"The numbers in the array are" + string.Join(",", userArray));
                Console.WriteLine($"The sum of your array is {arraySum}");
                Console.WriteLine($"{arraySum} * {arrayProd/arraySum} = {arrayProd}");
                Console.WriteLine($"{arrayProd} / {decimal.Divide(Convert.ToDecimal(arrayProd),arrayQuotient)} = {arrayQuotient}");
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static decimal GetQuotient(int prod)
        {
            Console.WriteLine($"Please enter a number to divide your product {prod} by");
            decimal quotient = 0;
            try
            {
                quotient = decimal.Divide( Convert.ToDecimal(prod), Convert.ToDecimal(Console.ReadLine()));
            }
            catch (DivideByZeroException e)
            {
                return 0m;
            }
            return quotient;
        }

        private static int GetProduct(int[] arr, int sum)
        {
            Console.WriteLine($"Please select a random number between 1 and {arr.Length}");
            int index = Convert.ToInt32(Console.ReadLine())-1;

            int product = 0;
            try
            {
                product = sum * arr[index];
            }
            catch (IndexOutOfRangeException e)
            {
                throw e;
            }

            return product;
        }

        private static int GetSum(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            if (sum < 20)
            {
                throw new Exception($"Value of {sum} is too low");
            }
            return sum;
        }

        private static int[] Populate(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Please enter number: {i + 1} of {arr.Length}");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            return arr;
        }
    }
}
