using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client2
{
    class Program
    {
        static string iNpath = "In.txt";
        static string outPath = "Out.txt";

        static void Main(string[] args)
        {
            try
            {
                //CreateFiles();
                Reverse();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

        }

        private static void Reverse()
        {
            if (GetLineCount(iNpath) >= 10)
            {
                string reversed = ReverseByServise(ReadFile(iNpath));
                WriteOutFile(outPath, reversed, 0, reversed.Length);
                Console.WriteLine("OK!");
            }
            else
            {
                Console.WriteLine("Error:Count < 10");
            }
        }

        private static string ReverseByServise(string text)
        {
            ReverseService.ReviseServiceSoapClient client = new ReverseService.ReviseServiceSoapClient();
            client.Open();
            var responseText = client.ReverseText(text);
            client.Close();
            return responseText;
        }

        private static int GetLineCount(string path)
        {
            int count = 0;
            if (File.Exists(path))
            {
                using (var reader = new StreamReader(File.OpenRead(path)))
                {
                    while (!reader.EndOfStream)
                    {
                        reader.ReadLine();
                        count++;
                    }
                }
            }
            else
            {
                Console.WriteLine("File not found");
                return 0;
            }

            return count;
        }
        private static string ReadFile(string path)
        {
            List<string> words = new List<string>();
            string text = "";
            if (File.Exists(path))
            {
                using (var reader = new StreamReader(File.OpenRead(path)))
                {
                    while (!reader.EndOfStream)
                        text += reader.ReadLine().Split(' ')[0] + " ";
                    reader.Close();
                }
                return text;
            }
            else
            {
                Console.WriteLine("File not found");
                return null;
            }

        }
        private static void WriteOutFile(string path, string text, int offset, int count)
        {
            FileStream file;
            if (!File.Exists(path))
            {
                File.Delete(path);
                file = File.Create(path);
            }
            else
            {
                file = File.OpenWrite(path);
            }

            file.Write(ConvertToByte(text), offset, count);
            file.Close();
        }

        private static byte[] ConvertToByte(string value)
        {
            byte[] arr = new byte[value.Length];
            for (int i = 0; i < value.Length; i++)
            {
                arr[i] = (byte)value[i];
            }
            return arr;
        }
    }
}
