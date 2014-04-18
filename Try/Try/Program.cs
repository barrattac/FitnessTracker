using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Try
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string>();
            words.Add("You can add a string to a List<string>");
            words.Add(null);
            words.Add(null);
            words.Add("You can add a null to a List<string>");
            words.Add(null);
            words.Add("I added two nulls, then a string, then another null");
            words.Add("See how nulls are counted." + words.Count);
            words.Add("RemoveAll(null) will throw an exception.");
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine("Press 'Enter' to see how to remove all the nulls.");
            ConsoleKey key = Console.ReadKey().Key;
            while (key != ConsoleKey.Enter)
            {
                key = Console.ReadKey().Key;
            }
            Console.Clear();
            words.Add("You can type:");
            words.Add("{");
            words.Add("words.Remove(null);");
            words.Add("}");
            words.Add("where 'words' represents the name of the list.");
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine("Press 'Enter' to see what happens.");
            key = ConsoleKey.A;
            while (key != ConsoleKey.Enter)
            {
                key = Console.ReadKey().Key;
            }
            Console.Clear();
            while (words.Contains(null))
            {
                words.Remove(null);
            }
            Console.WriteLine("This is what the new list would look like");
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine("Press 'Enter' to see what the new list looks like.");
            key = ConsoleKey.A;
            while (key != ConsoleKey.Enter)
            {
                key = Console.ReadKey().Key;
            }
            Console.Clear();
            words.Add("You can AddRange(new List<string>), but you can't AddRange(null).");
            int preCount = words.Count;
            List<string> noWords = new List<string>();
            words.AddRange(noWords);
            int count = words.Count;
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine("Before adding the new List<string>: " + preCount + ", after adding the new List<string>: " + count);
            Console.WriteLine("See how a new List<string> constains nothing, but is not the same as null.");
            Console.ReadLine();
        }
    }
}
