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
                // Oops! something went wrong. Time to debug
                Console.WriteLine("Something didn't quite go right: " + e.Message);
            }
            finally
            {
                // Always finish here
                Console.WriteLine("The program has finished executing.");
            }
        }

        private static void StartSequence()
        {
            Console.WriteLine("Welcome to my game! Let's do some math!");
            Console.WriteLine("Enter a number greater than zero:");
            
            try
            {
                // Get array size from user
                int userNum = Convert.ToInt32(Console.ReadLine());

                // Create empty array
                int[] userArray = new int[userNum];

                // Run methods
                userArray = Populate(userArray);
                int arraySum = GetSum(userArray);
                int arrayProd = GetProduct(userArray, arraySum);
                decimal arrayQuotient = GetQuotient(arrayProd);

                // Display final results
                Console.WriteLine($"Your Array size is size: {userArray.Length}");
                Console.WriteLine($"The numbers in the array are" + string.Join(",", userArray));
                Console.WriteLine($"The sum of your array is {arraySum}");
                Console.WriteLine($"{arraySum} * {arrayProd/arraySum} = {arrayProd}");
                Console.WriteLine($"{arrayProd} / {decimal.Divide(Convert.ToDecimal(arrayProd),arrayQuotient)} = {arrayQuotient}");
            }
            catch (OverflowException e)
            {
                // numbers got too big
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                // couldnt parse right
                Console.WriteLine(e.Message);
            }
        }

        private static decimal GetQuotient(int prod)
        {
            Console.WriteLine($"Please enter a number to divide your product {prod} by");
            decimal quotient = 0;
            try
            {
                // convert and devide in one line, Divide seemed to want 2 decimals so convert both;
                quotient = decimal.Divide( Convert.ToDecimal(prod), Convert.ToDecimal(Console.ReadLine()));
            }
            catch (DivideByZeroException e)
            {
                // If they picked 0 then they get 0, not infinity
                return 0m;
            }
            return quotient;
        }

        private static int GetProduct(int[] arr, int sum)
        {
            Console.WriteLine($"Please select a random number between 1 and {arr.Length}");
            int index = Convert.ToInt32(Console.ReadLine())-1; // im not actually sure where this error shows up, I might need to wrap in try-catch with throw

            int product = 0; // used to hold the final product
            try
            {
                product = sum * arr[index]; // straight forward arithmetic
            }
            catch (IndexOutOfRangeException e)
            {
                throw e;
            }

            return product;
        }

        private static int GetSum(int[] arr)
        {
            int sum = 0; // used to track the total sum

            // go over the whole array
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            if (sum < 20)
            {
                throw new Exception($"Value of {sum} is too low"); // custom exception if the sum is too low. generic might not be okay
            }
            return sum;
        }

        private static int[] Populate(int[] arr)
        {
            // go over the whole array asking the user for a number to add at that index
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Please enter number: {i + 1} of {arr.Length}"); // magic digit 1 so the array starts at 1 not 0
                arr[i] = Convert.ToInt32(Console.ReadLine()); // again might throw a format exception that might need thrown
            }
            return arr;
        }
    }
}
