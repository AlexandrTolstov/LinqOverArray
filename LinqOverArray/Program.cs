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

        }
        static void QueryOverString()
        {
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};
            IEnumerable<string> subset = from g in currentVideoGames where g.Contains(" ") orderby g select g;
            foreach(string s in subset)
                Console.WriteLine("Item: {0}", s);
        }
    }
}
