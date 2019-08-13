using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqOverArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****** Fun with LINQ to Object *****\n");
            QueryOverString();
            QueryOverStringWithExtensionMethod();

        }
        static void QueryOverString()
        {
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            IEnumerable<string> subset = from g in currentVideoGames where g.Contains(" ") orderby g select g;
            ReflectOverQueryResults(subset);
            foreach (string s in subset)
                Console.WriteLine("Item: {0}", s);
        }
        static void QueryOverStringWithExtensionMethod()
        {
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            IEnumerable<string> subset = currentVideoGames.Where(g => g.Contains(" ")).OrderBy(g => g).Select(g => g);
            ReflectOverQueryResults(subset, "Extension Method");
            foreach (string s in subset)
                Console.WriteLine("Item: {0}", s);
        }
        static void ueryOverStringsLongHand()
        {
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            string[] gamesWithSpaces = new string[5];
            for (int i = 0; i < currentVideoGames.Length; i++)
            {
                if (currentVideoGames[i].Contains(" "))
                    gamesWithSpaces[i] = currentVideoGames[i];
            }
            // Now sort them.
            Array.Sort(gamesWithSpaces);
            // Print out the results.
            foreach (string s in gamesWithSpaces)
            {
                if (s != null)
                    Console.WriteLine("Item: {0}", s);
            }
            Console.WriteLine();
        }
        static void ReflectOverQueryResults(object resultSet, string queryType = "Query Expressions")
        {
            Console.WriteLine($" Info about your query using {queryType} *****");
            Console.WriteLine("resultSet is of type: {0}", resultSet.GetType().Name);
            Console.WriteLine("resultSet location: {0}", resultSet.GetType().Assembly.GetName().Name);
        }
    }
}
