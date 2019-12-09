using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ArabToRomanConverter_OneIdentity_PolliniKristof
{
    class Numbers
    {
        string fileNameOrPath;

        //Ctor
        public Numbers(string fileName)
        {
            this.fileNameOrPath = fileName;
        }

        /// <summary>
        /// Loads the input file, line by line into an array
        /// </summary>
        /// <returns>The filled integer array is returned</returns>
        public int[] Load()
        {
            int[] arabicNumbers;
            string[] temp = File.ReadAllLines(fileNameOrPath);
            string[] lines = new string[temp.Length];

            for (int i = 0; i < temp.Length; i++)
            {
                lines[i] = temp[i].Trim();
            }

            arabicNumbers = new int[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                arabicNumbers[i] = int.Parse(lines[i]);
            }
            return arabicNumbers;
        }


        /// <summary>
        /// Writes the converted data into the output file
        /// </summary>
        /// <param name="romanNumbers">Converted data stored in a string array</param>
        /// <param name="outputFileNameOrPath">The name of the output file, a path can be added too</param>
        public void Write(string[] romanNumbers, string outputFileNameOrPath)
        {
            using (StreamWriter sw = new StreamWriter(outputFileNameOrPath))
            {
                for (int i = 0; i < romanNumbers.Length; i++)
                {
                    sw.WriteLine(romanNumbers[i]);
                }
                sw.Close();
            }
        }
    }
}
