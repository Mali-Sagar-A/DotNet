namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("🔹 C# Collection Examples 🔹\n");

            // ✅ LIST
            List<string> names = new List<string> { "Prasad", "Amit", "Sneha" };
            names.Add("Rohit");
            Console.WriteLine("📋 List:");
            foreach (var name in names)
                Console.WriteLine($"- {name}");
            Console.WriteLine();

            // ✅ STACK (LIFO)
            Stack<string> books = new Stack<string>();
            books.Push("C# Basics");
            books.Push("ASP.NET Core");
            books.Push("EF Core");
            Console.WriteLine("📚 Stack (LIFO):");
            while (books.Count > 0)
                Console.WriteLine($"- {books.Pop()}");
            Console.WriteLine();

            // ✅ QUEUE (FIFO)
            Queue<string> tasks = new Queue<string>();
            tasks.Enqueue("Login Module");
            tasks.Enqueue("Register Module");
            tasks.Enqueue("Cart Module");
            Console.WriteLine("📬 Queue (FIFO):");
            while (tasks.Count > 0)
                Console.WriteLine($"- {tasks.Dequeue()}");
            Console.WriteLine();

            // ✅ DICTIONARY
            Dictionary<int, string> students = new Dictionary<int, string>();
            students[1] = "Prasad";
            students[2] = "Amit";
            students[3] = "Sneha";
            Console.WriteLine("📖 Dictionary (Key-Value Pairs):");
            foreach (var student in students)
                Console.WriteLine($"Roll {student.Key}: {student.Value}");
        
        }
    }
}
