using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vigenere_cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "абвгдежзийклмнопрстуфхцчшщъыбэюя";
            for (int i = 0; i < 32; i++)
            {
                if (i != 0)
                    Console.Write("{0}\t| ", i);
                else
                    Console.Write("\t| ");
                foreach (int j in a)
                    Console.Write("{0} ",(char)(j));

                a = a + a[0];
                a = a.Remove(0, 1);
                Console.WriteLine();
            }

            decrypt();
            encrypt();

             Console.ReadKey();
        }
          static string encrypt()
            {
                byte[] text = Encoding.GetEncoding(1251).GetBytes(Console.ReadLine());
                byte[] key = Encoding.GetEncoding(1251).GetBytes(Console.ReadLine());
                byte[] shifr = new byte[text.Length];


                for (int i = 0; i < text.Length; i++)
                {
                    text[i] = (byte)(text[i] - 224);
                    Console.Write("{0} ", text[i]);
              //  Console.WriteLine();
                    key[i] = (byte)(key[i] - 224);
                    Console.Write("{0} ", key[i]);
                }

                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] + key[i] >= 32)
                        shifr[i] = (byte)(224 + text[i] + key[i] - 32);
                    else
                        shifr[i] = (byte)(224 + text[i] + key[i]);

                }
            
                Console.WriteLine(System.Text.Encoding.GetEncoding(1251).GetString((shifr)));
            return Encoding.GetEncoding(1251).GetString((shifr));
            }
        static string decrypt()
        {
            byte[] text = Encoding.GetEncoding(1251).GetBytes(Console.ReadLine());
            byte[] key = Encoding.GetEncoding(1251).GetBytes(Console.ReadLine());
            byte[] shifr = new byte[text.Length];


            for (int i = 0; i < text.Length; i++)
            {
                text[i] = (byte)(text[i] - 224);
                key[i] = (byte)(key[i] - 224);
            }

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] > key[i])
                    shifr[i] = (byte)(32 - (text[i] - key[i]) + 224);
                else
                    shifr[i] = (byte)(key[i] - text[i] + 224);

            }

            Console.WriteLine(System.Text.Encoding.GetEncoding(1251).GetString((shifr)));
            return Encoding.GetEncoding(1251).GetString((shifr));
        }
    }
}
