using System;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Fact
    {

        private static async Task LetsSayUserClickedAButtonOnGuiMethod()
        {
            var result = await GetTheMagicNumber();
            Console.WriteLine(result);
        }

        private static async Task<int> GetTheMagicNumber()
        {
            return await Task.Run(() => IKnowIGuyWhoKnowsAGuy());
        }

        private static async Task<int> IKnowIGuyWhoKnowsAGuy()
        {
            return await Task.Run(() => IKnowWhoKnowsThis(10)) + await Task.Run(() => IKnowWhoKnowsThis(5));
        }

        private static async Task<int> IKnowWhoKnowsThis(int n)
        {
            return await Task.Run(() => Factorials.FactorialDigitSum(n));
        }

        // Ignore this part .
        static void Main(string[] args)
        {
            // Main method is the only method that
            // can ’t be marked with async .
            // What we are doing here is just a way for us to simulate
            // async - friendly environment you usually have with
            // other . NET application types ( like web apps , win apps etc .)
            // Ignore main method , you can just focus on
            //LetsSayUserClickedAButtonOnGuiMethod() as a
            // first method in the call hierarchy .
            var t = Task.Run(() => LetsSayUserClickedAButtonOnGuiMethod());
            Console.Read();
        }
    }
}
