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

            while(true)
            {
                Console.Clear();
                Console.WriteLine("\nШифр Виженера для русского алфавита\n");
                Console.WriteLine("Чтобы зашифровать сообщение, нажмите 1.\nЧтобы дешифровать сообщение, нажмите 2.\nДля выхода, нажмите 0");
                switch (Console.ReadLine())
                {
                    case "0":
                        System.Environment.Exit(0);
                        break;
                    case "1":
                        if (encrypt() == false)
                        {
                            Console.WriteLine("\nОшибка: были введены символы, отличные от русского алфавита.\n\nНажмите любую клавишу");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("\nШифрование завершено.\n\nНажмите любую клавишу");
                            Console.ReadKey();
                        }
                        break;
                    case "2":
                        if (decrypt() == false)
                        {
                            Console.WriteLine("\nОшибка: были введены символы, отличные от русского алфавита.\n\nНажмите любую клавишу");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("\nДешифрование завершено.\n\nНажмите любую клавишу");
                            Console.ReadKey();
                        }
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Ошибка: был введен иной символ");
                        break;
                }
            }

        }
          static bool encrypt()
            {
                byte[] text = Encoding.GetEncoding(1251).GetBytes(Console.ReadLine());
                byte[] key = Encoding.GetEncoding(1251).GetBytes(Console.ReadLine());
                byte[] shifr = new byte[text.Length];


                for (int i = 0; i < text.Length; i++)
                {
                    if ((text[i] < 224) || (key[i] < 224))
                        return false;

                    text[i] = (byte)(text[i] - 224);
                    key[i] = (byte)(key[i] - 224);
                }
            Console.ReadKey();
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] + key[i] >= 32)
                        shifr[i] = (byte)(224 + text[i] + key[i] - 32);
                    else
                        shifr[i] = (byte)(224 + text[i] + key[i]);

                }
            
                Console.WriteLine(System.Text.Encoding.GetEncoding(1251).GetString((shifr)));
            return true;
            }
        static bool decrypt()
        {
            byte[] text = Encoding.GetEncoding(1251).GetBytes(Console.ReadLine());
            byte[] key = Encoding.GetEncoding(1251).GetBytes(Console.ReadLine());
            byte[] shifr = new byte[text.Length];


            for (int i = 0; i < text.Length; i++)
            {
                if((text[i] < 224) || (key[i] < 224))
                        return false;

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
            return true;
        }
    }
}
