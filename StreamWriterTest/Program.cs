using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace StreamWriterTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Podaj nazwę pliku .txt: ");
            var line = Console.ReadLine();
            var path = Path.Combine($"{line}.txt");

            StreamWriter streamWriter;

            if (File.Exists(path))
            {
                Console.Write("Plik istnieje, dopisać dane do istniejącego pliku? [T/n]: ");
                bool makeNewFile = Console.ReadKey(true).KeyChar switch
                {
                    (char)ConsoleKey.Enter => true,
                    'T' => true,
                    't' => true,
                    'N' => false,
                    'n' => false,
                    _ => false,
                };
                streamWriter = new StreamWriter(path, makeNewFile);
            }
            else
                streamWriter = new StreamWriter(path);

            Console.Write("\nWpisz wiadomość do zapisania w pliku:\n");
            while (true)
            {
                streamWriter.WriteLine(Console.ReadLine());
                Console.Write("Kontynuować? [T/n]: ");
                bool nextMessage = Console.ReadKey(true).KeyChar switch
                {
                    (char)ConsoleKey.Enter => true,
                    'T' => true,
                    't' => true,
                    'N' => false,
                    'n' => false,
                    _ => false,
                };

                if (!nextMessage)
                    break;
                Console.Write("\nWpisz wiadomość do zapisania w pliku:\n");
            }
            streamWriter.Close();
        }
    }
}
