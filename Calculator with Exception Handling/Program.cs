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
                int arrayQuotient = GetQuotient(arrayProd);

                Console.WriteLine($"Your Array size is size: {userArray.Length}");
                Console.WriteLine($"The numbers in the array are" + string.Join(",", userArray));
                Console.WriteLine($"The sum of your array is {arraySum}");
                Console.WriteLine($"{arraySum} * {arrayProd/arraySum} = {arrayProd}");
                Console.WriteLine($"{arrayProd} / {arrayProd/arrayQuotient} = {arrayQuotient}");
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

        private static int GetQuotient(int num)
        {
            throw new NotImplementedException();
        }

        private static int GetProduct(int[] arr, int num)
        {
            throw new NotImplementedException();
        }

        private static int GetSum(int[] arr)
        {
            throw new NotImplementedException();
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
