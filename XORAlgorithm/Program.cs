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
     //   Random alea = new Random();

        public int nbrKeyChar = 6;
        public string keyChar = "abcdefghijklmnopqrstuvwxyz";
        //   public string[] keyChar = {"97","98","99","100","101","102","103","104","105","106","107","108","109","110","111","112","113","114","115","116","117","118","119","120","121","122"};

        public List<string> words;


        static void Main(string[] args)
        {
            Program program = new Program();
            /*
            Program p = new Program();
            int key = 0;
            
            //string data = "test";
            string textToEncrypt = System.IO.File.ReadAllText(@"C:\Users\Benjamin\Desktop\P1G.txt", Encoding.UTF8);
            //string textToEncrypt = "michel tej";
           // Console.WriteLine(keyChar.Length +" : " + nbrKeyChar);
            double maxIteration = Math.Pow(keyChar.Length, nbrKeyChar);
           // Console.WriteLine("max i : " + maxIteration);
            for (uint i = 0; i < maxIteration; i++)
            {
               
                string keyTest = p.FindKey();
                //Console.WriteLine(i + " : " + keyTest.ToString());
                string resultat = p.EncryptDecrypt(textToEncrypt, keyTest);
                string lines = resultat +"\n\r";
               // System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\Users\\Benjamin\\result-filetodecrypt.txt", true);
               // file.WriteLine(lines, Encoding.UTF8);
               // file.Close();
                System.IO.File.AppendAllText("c:\\Users\\Benjamin\\resultinging-filetodecrypt.txt", lines + Environment.NewLine, Encoding.UTF8);
            }

            Console.WriteLine("Hello"); Console.ReadLine();*/
        }

        public Program()
        {
            // get words
            DBConnect dbConnect = new DBConnect();
            this.words = dbConnect.Select();

            // get file content
            // TODO
            string textToEncrypt = System.IO.File.ReadAllText(@"C:\Users\Benjamin\Desktop\P1E.txt", Encoding.UTF8);

            Char delimiter = ' ';
            double maxIteration = Math.Pow(keyChar.Length, nbrKeyChar);
            int totalCount = 0;
            int totalCounts = 0;
            for (uint i = 0; i < maxIteration; i++)
            {

                string keyTest = FindKey();
                string resultat = EncryptDecrypt(textToEncrypt, keyTest);
                string[] allWords = resultat.Split(delimiter);
                int count=0;

                if (totalCounts >=254300000) 
                {
                    Console.WriteLine(keyTest);
                }

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
                int ratio = count / allWords.Length;
                if (ratio > 0.1) 
                {
                   
                    System.IO.File.AppendAllText("c:\\Users\\Benjamin\\resultinging-filetodecrypt.txt", resultat + Environment.NewLine, Encoding.UTF8);
                }
                totalCount++;
                if (totalCount >= 10000) 
                {
                    totalCounts += totalCount;
                    totalCount = 0;
                    Console.WriteLine(totalCounts);
                }
            }

            Console.Read();
        }

    
        /*private int GenerateKey()
        {
            string response = "";
            string caracteres = "0123456789";
            int length = 6;
            
            for (int x = 0; x < length; x++)
            {
                response += caracteres[alea.Next(0, caracteres.Length)];
            }

            Console.WriteLine("eeeeeeeee : " + response);
            return Convert.ToInt32(response);
        }*/

        int[] key = {0,0,0,0,0,-1};

        private string FindKey()
        {
            string caracteres = "abcdefghijklmnopqrstuvwxyz";
            int length = 6;
            string response = "";

            key = test(key, length -1, caracteres.Length - 1);
          //  Console.WriteLine(key[5]);
            for (int i = 0; i < length; i++) 
            {
                response += caracteres[key[i]];
            }

            return response;
        }

        private int[] test(int[] key, int current, int length)  
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
                return test(key, current - 1, length);
            }
        }

        //    {
           /* string[] caracteres = {"97","98","99","100","101","102","103","104","105","106","107","108","109","110","111","112","113","114","115","116","117","118","119","120","121","122"};
            int length = 6;
            string response = "";
           // string result = "";
            for (int x = 0; x < length; x++)    1002927200
            {
                response += caracteres[alea.Next(0, 26)];
               // Console.WriteLine(result);
              /*  string[] newTab = new string[response.Length + 1];
                newTab[x] = result;
                response.CopyTo(newTab, 0);
                response = newTab;*/
             //   Console.WriteLine(response);
     //       }
           // Console.WriteLine("----------------------" + response);
           
          //  return response
   //    }

       /* private byte[] FindKey()
        {
            byte[] caracteres = { 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122 };
            int length = 6;
            byte[] response = { };
            byte result = 0;
            for (int x = 0; x < length; x++)
            {
                result = caracteres[alea.Next(0, 26)];
                // Console.WriteLine(result);
                byte[] newTab = new byte[response.Length + 1];
                newTab[x] = result;
                response.CopyTo(newTab, 0);
                response = newTab;
                //   Console.WriteLine(response);
            }
            // Console.WriteLine("----------------------" + response);
            return response;
        }*/

        /*private int generateNumber()
        {
         
        }*/

        private string EncryptDecrypt(string textToEncrypt, string key)
        {
           /* byte[] key = response;
           
            //string test = Convert.ToString(key[0]) + Convert.ToString(key[1]);
            
           // long mykey = Convert.ToInt64(test);

            StringBuilder inSb = new StringBuilder(textToEncrypt);
            
            StringBuilder outSb = new StringBuilder(textToEncrypt.Length);
            char c;
            for (int i = 0; i < textToEncrypt.Length; i++)
            {
                /*c = inSb[i];
                c = (char)(c ^ key[]);
                outSb.Append(c);

            }
            return outSb.ToString();*/


            StringBuilder result = new StringBuilder();

            for (int c = 0; c < textToEncrypt.Length; c++)
                result.Append((char)((uint)textToEncrypt[c] ^ (uint)key[c % key.Length]));

            return result.ToString();
        } 

        private bool checkChar(long value)
        {
            try
            {
                var c = Convert.ToChar(value);
                return true;
            }
            catch (InvalidCastException)
            {
                return false;
            }
            catch (FormatException)
            {
                return false;
            }
            catch (OverflowException)
            {
                return false;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

  }
}
