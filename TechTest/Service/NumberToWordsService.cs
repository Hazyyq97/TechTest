using TechnicalTest.Service.IService;

namespace TechnicalTest.Service
{
    public class NumberToWordsService : INumberToWordsService
    {
        public async Task<string?> ConvertNumberToWordsAsync(double number)
        {
            try
            {
                string words = Conversion(number);
                return words;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        private static readonly string[] firstDigit = 
        { 
            "Zero", "One", "Two", "Three", "Four", "Five",
            "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
            "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
            "Seventeen", "Eighteen", "Nineteen" 
        };
        private static readonly string[] secondDigit = 
        { 
            "", "", "Twenty", "Thirty", "Forty", "Fifty",
            "Sixty", "Seventy", "Eighty", "Ninety" 
        };

        private static string Conversion(double amount)
        {
            try
            {
                int front_amount = (int)amount;
                int remainder_amount = (int)Math.Round((amount - (double)(front_amount)) * 100);
                if (remainder_amount == 0)
                {
                    return GetWords(front_amount) + " Dollar.";
                }
                else
                {
                    return GetWords(front_amount) + " Dollar And " + GetWords(remainder_amount) + " Cent.";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return "";
        }

        private static string GetWords(int i)
        {
            if (i < 20)
            {
                return firstDigit[i];
            }
            if (i < 100)
            {
                return secondDigit[i / 10] + ((i % 10 > 0) ? " " + GetWords(i % 10) : "");
            }
            if (i < 1000)
            {
                return firstDigit[i / 100] + " Hundred"
                        + ((i % 100 > 0) ? " And " + GetWords(i % 100) : "");
            }
            if (i < 100000)
            {
                return GetWords(i / 1000) + " Thousand "
                        + ((i % 1000 > 0) ? " " + GetWords(i % 1000) : "");
            }
            if (i < 1000000)
            {
                return GetWords(i / 100000) + " Hundred Thousand "
                        + ((i % 100000 > 0) ? " " + GetWords(i % 100000) : "");
            }
            if (i < 100000000)
            {
                return GetWords(i / 1000000) + " Million "
                        + ((i % 1000000 > 0) ? " " + GetWords(i % 1000000) : "");
            }
            if (i < 1000000000)
            {
                return GetWords(i / 100000000) + " Hundred Million "
                        + ((i % 100000000 > 0) ? " " + GetWords(i % 100000000) : "");
            }
            else
            {
                return "Amount is bigger than hundred million dollar";

            }
        }

    }
}
