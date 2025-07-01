using System;
using System.IO;
using System.Linq;

namespace File_IO
{
    internal class Program
    {
        static string filePath = "customer.txt";

        static void Main(string[] args)
        {
            Console.WriteLine(" File I/O Operations & Analysis\n");

            WriteToFile("Prasad Patil.\nLives in Pune.\nLearning C# and File I/O operations.");

            ReadFromFile();

            AnalyzeFile();

            UpdateFile("Prasad R. Patil.\nNow updated with new data.\nStill learning File operations.");

            ReadFromFile();

            AnalyzeFile();

            DeleteFile();

            ReadFromFile();
        }

        // Create / Write
        static void WriteToFile(string content)
        {
            File.WriteAllText(filePath, content);
            Console.WriteLine(" File created and data written.\n");
        }

        // Read
        static void ReadFromFile()
        {
            if (File.Exists(filePath))
            {
                string data = File.ReadAllText(filePath);
                Console.WriteLine(" File Contents:\n" + data + "\n");
            }
            else
            {
                Console.WriteLine(" File does not exist.\n");
            }
        }

        // Update
        static void UpdateFile(string newContent)
        {
            if (File.Exists(filePath))
            {
                File.WriteAllText(filePath, newContent);
                Console.WriteLine(" File updated successfully.\n");
            }
            else
            {
                Console.WriteLine(" Cannot update. File does not exist.\n");
            }
        }

        // Delete
        static void DeleteFile()
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Console.WriteLine(" File deleted successfully.\n");
            }
            else
            {
                Console.WriteLine(" Cannot delete. File does not exist.\n");
            }
        }

        // Analyze File
        static void AnalyzeFile()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine(" Cannot analyze. File does not exist.\n");
                return;
            }

            string content = File.ReadAllText(filePath);
            int charCount = content.Length;
            int wordCount = content.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
            int lineCount = File.ReadAllLines(filePath).Length;
            int statementCount = content.Count(c => c == '.');
            int vowelCount = content.Count(c => "aeiouAEIOU".Contains(c));

            Console.WriteLine(" File Analysis:");
            Console.WriteLine($"Characters     : {charCount}");
            Console.WriteLine($"Words          : {wordCount}");
            Console.WriteLine($"Lines          : {lineCount}");
            Console.WriteLine($"Statements (.) : {statementCount}");
            Console.WriteLine($"Vowels         : {vowelCount}\n");
        }
    }
}
