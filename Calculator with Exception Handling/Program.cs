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
            throw new NotImplementedException();
        }
    }
}
