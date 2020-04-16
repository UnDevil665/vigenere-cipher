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
            Console.WriteLine("Матрица Виженера");
            string a = "абвгдежзийклмнопрстуфхцчшщъыьэюя";
            for (int i = 0; i < 33; i++)
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

            Console.Write("Для продолжения нажмите любую клавишу...");

            while (true)
            { 
                Console.ReadKey();
                Console.Clear();

                Console.WriteLine("\nШифр Виженера для русского алфавита\n");
                Console.WriteLine("Чтобы зашифровать сообщение, нажмите 1.\nЧтобы дешифровать сообщение, нажмите 2.\nДля выхода, нажмите 0");
                switch (Console.ReadKey().KeyChar)
                {
                    case '0':
                        System.Environment.Exit(0);
                        break;
                    case '1':
                        if (encrypt() == false)
                        {
                            Console.WriteLine("\nОшибка: были введены символы, отличные от русского алфавита.\n\nНажмите любую клавишу");
                            Console.ReadKey(true);
                        }
                        else
                        {
                            Console.WriteLine("\nШифрование завершено.\n\nНажмите любую клавишу");
                            Console.ReadKey(true);
                        }
                        break;
                    case '2':
                        if (decrypt() == false)
                        {
                            Console.WriteLine("\nОшибка: были введены символы, отличные от русского алфавита.\n\nНажмите любую клавишу...");
                            Console.ReadKey(true);
                        }
                        else
                        {
                            Console.WriteLine("\nДешифрование завершено.\n\nНажмите любую клавишу...");
                            Console.ReadKey(true);
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
                Console.Clear();
                Console.Write("\nВведите сообщение: ");
                byte[] text = Encoding.GetEncoding(1251).GetBytes(Console.ReadLine());

                Console.Write("\nВведите ключ: ");
                byte[] key = Encoding.GetEncoding(1251).GetBytes(Console.ReadLine());

                byte[] shifr = new byte[text.Length];

                for(int i = 0; i < text.Length; i++)
                    if ((text[i] < 224) || (key[i] < 224))
                        return false;
                matrix(System.Text.Encoding.GetEncoding(1251).GetString((key)));

            for (int i = 0; i < text.Length; i++)
                {
                    text[i] = (byte)(text[i] - 224);
                    key[i] = (byte)(key[i] - 224);
                }

                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] + key[i] >= 32)
                        shifr[i] = (byte)(224 + text[i] + key[i] - 32);
                    else
                        shifr[i] = (byte)(224 + text[i] + key[i]);

                }
            
                Console.WriteLine("\nШифрованное сообщение: {0}", System.Text.Encoding.GetEncoding(1251).GetString((shifr)));
            return true;
            }
        static bool decrypt()
        {
            Console.Clear();
            Console.Write("\nВведите шифр: ");
            byte[] key = Encoding.GetEncoding(1251).GetBytes(Console.ReadLine());

            Console.Write("\nВведите ключ: ");
            byte[] text = Encoding.GetEncoding(1251).GetBytes(Console.ReadLine());

            byte[] shifr = new byte[text.Length];

            matrix(System.Text.Encoding.GetEncoding(1251).GetString((key)));

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

            Console.WriteLine("\nИсходное сообщение: {0}", System.Text.Encoding.GetEncoding(1251).GetString((shifr)));
            return true;
        }

        static void matrix(string input)
        {
            //Console.WriteLine((int)('а'));
            string alphabet = "абвгдежзийклмнопрстуфхцчшщъыьэюя";
            Console.Write("\nМатрица шифрования\n\t| ");
            for (int i = 0; i < 32; i++)
                Console.Write("{0} ", alphabet[i]);
            Console.WriteLine();

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                    if (alphabet[j] == input[i])
                    {
                        Console.Write("{0}\t| ", j);
                        for (int k = 0; k < 32; k++)
                        {
                            if (1072 + j + k > 1103)
                                Console.Write("{0} ", (char)(1072 + j + k - 32));
                                //Console.Write("{0} ", (int)(1072 + j + k - 32));
                            else
                                Console.Write("{0} ", (char)(1072 + j + k));
                                //Console.Write("{0} ", 1072 + j + k);
                        }
                        alphabet.Remove(j, 1);
                        Console.WriteLine();

                    }
            }
            
        }
    }
}
