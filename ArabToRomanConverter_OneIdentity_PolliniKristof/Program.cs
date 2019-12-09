using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabToRomanConverter_OneIdentity_PolliniKristof
{
    class Program
    {
        static Numbers numbers;
        static int[] arabicNumbersArray;
        static string[] romanResults;

        // Map digits to letters.
        private static string[] ThousandsLetters = { "", "M", "MM", "MMM" };
        private static string[] HundredsLetters =
            { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        private static string[] TensLetters =
            { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        private static string[] OnesLetters =
            { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

        /// <summary>
        /// Convert Arabic numerals to an integer.
        /// </summary>
        /// <param name="arabicNumbers">Integer array containing the data to be converted</param>
        /// <returns>String array is returned filled with converted data</returns>
        static string[] ArabicToRoman(int[] arabicNumbers)
        {
            string[] romanResults = new string[arabicNumbers.Length];

            for (int i = 0; i < arabicNumbers.Length; i++)
            {
                // Process the letters.
                string result = "";

                //If number is bigger than 4000 the program should stop with an error message
                if (arabicNumbers[i] > 4000)
                {
                    throw new Exception("Error, number out of range!");
                }

                // Pull out thousands.
                int num;
                num = arabicNumbers[i] / 1000;
                result += ThousandsLetters[num];
                arabicNumbers[i] %= 1000;

                // Handle hundreds.
                num = arabicNumbers[i] / 100;
                result += HundredsLetters[num];
                arabicNumbers[i] %= 100;

                // Handle tens.
                num = arabicNumbers[i] / 10;
                result += TensLetters[num];
                arabicNumbers[i] %= 10;

                // Handle ones.
                result += OnesLetters[arabicNumbers[i]];

                romanResults[i] = result;
            }

            return romanResults;

        }

        /// <summary>
        /// Input file is loaded. The filename is hardcoded now, but it can be changed into an interactive user input.
        /// </summary>
        static void LoadNewFile()
        {
            string fileNameOrPath = "ARAB.IN";
            numbers = new Numbers(fileNameOrPath);
            arabicNumbersArray = numbers.Load();
        }

        /// <summary>
        /// Converted data is saved into a new output file. The filename is hardcoded now, but it can be changed into an interactive user input.
        /// </summary>
        static void SaveNewFile()
        {
            string outputFileNameOrPath = "ROMAN.OUT";
            romanResults = ArabicToRoman(arabicNumbersArray);
            numbers.Write(romanResults, outputFileNameOrPath);
        }



        static void Main(string[] args)
        {
            try
            {
                LoadNewFile();

                SaveNewFile();
            }
            catch (Exception e)
            {

                Console.WriteLine("{0} Exception caught!", e);
            }

            Console.WriteLine("The conversion is done, please find the ROMAN.OUT file in the debug folder!");
            Console.WriteLine("Press enter to exit!");
            Console.ReadKey();


        }
    }
}
