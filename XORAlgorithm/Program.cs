using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading;


namespace XORAlgorithm
{
    class Program
    {
        /* Initialize var */

        // Change var nbrKeyChar to 3 to decrypt the 2nd file
        public int nbrKeyChar = 3;
        public string keyChar = "abcdefghijklmnopqrstuvwxyz";
        public string endString = "67";
        public List<string> words;
        // Change var key to { 0, 0, -1} to decrypt the 2nd file
        int[] key = { 0, 0, -1 };

        static void Main(string[] args)
        {
            Program program = new Program();
        }

        public Program()
        {
            // get words
            DBConnect dbConnect = new DBConnect();
            this.words = dbConnect.Select();

            // get file content
            string textToDecrypt = System.IO.File.ReadAllText(@"C:\Users\Benjamin\Desktop\P1F.txt", Encoding.UTF8);

            Char delimiter = ' ';

            // get the maximum of iteration possible
            double maxIteration = Math.Pow(keyChar.Length, nbrKeyChar);

            for (uint i = 0; i < maxIteration; i++)
            {
                // get the key to decrypt the files
                string keyTest = FindKey();
                
                //uncomment the following line if you want to decrypt the second file :
                //keyTest = keyTest + endString;

                //uncomment the following line if you want to decrypt the first file :
                //keyTest = "fju" + keyTest;

                
                // get the result of the file decryption
                string resultat = Decrypt(textToDecrypt, keyTest);

                // split the content of resultat according to the delimiter chosen
                string[] allWords = resultat.Split(delimiter);
                float count=0;

                // check if current word is part of the dictionnary (var words)
                if (allWords.Length > 1)
                {
                    for (int y = 0; y < allWords.Length; y++)
                    {
                        if (words.Contains(allWords[y]))
                        {
                            count++;
                        }
                    }
                }

                //Console.WriteLine(count);
                double ratio = count / allWords.Length;

                // save the result into a file
                
                if (ratio > 0.6)
                {
                    System.IO.File.AppendAllText("c:\\Users\\Benjamin\\FileDecrypted\\resultat.txt", resultat, Encoding.UTF8);
                    Console.Read();
                }
            }
            
        }

        /*
         
         * Function FindKey() which return the key to decrypt the files.
         
         */

        private string FindKey()
        {
            string response = "";
            key = Generate(key, nbrKeyChar - 1, keyChar.Length - 1);

            for (int i = 0; i < nbrKeyChar; i++) 
            {
                response += keyChar[key[i]];
            }
            return response;
        }

        /*
         
         * Function generating the key

         */

        private int[] Generate(int[] key, int current, int length)  
        {
            if (key[current] != length) 
            {
                key[current]++;
                return key;
            }
            else 
            {
                if (current == 0) return null;
                key[current] = 1;
                return Generate(key, current - 1, length);
            }
        }

        /*
         
         * Function allowing the Decryption of the file.
         * Add to a stringBuilder the value after having passed by the XOR Algorithm
         * Returns string result
         
         */

        private string Decrypt(string textToDecrypt, string key)
        {
            StringBuilder result = new StringBuilder();
            for (int c = 0; c < textToDecrypt.Length; c++)
                result.Append((char)((uint)textToDecrypt[c] ^ (uint)key[c % key.Length]));

            return result.ToString();
        }
    }
}
