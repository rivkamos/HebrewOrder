using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text.RegularExpressions;

namespace HebrewOrderPrj
{
    internal class Program
    {
        static Dictionary<char, int> customMapper = new Dictionary<char, int>();

        static void Main(string[] args)
        {
            string paragraph = "Lorem ipsum dolor sit amet, consectetur adipiscing elit,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua";
            string order = "ABGDHVZJTYKLMNSIPXQRWUCEFO";

            HebrewOrder(CleanInput(paragraph), order);

            Console.ReadLine();
        }

        public static List<string> CleanInput(string paragraph)
        {
            //Remove punctuation
            paragraph = paragraph.Replace(',', ' ');

            //Split the paragraph to a list ignore more than one space
            return Regex.Split(paragraph, @"\s+").ToList();
        }

        public static void HebrewOrder(List<string> paragraph, string order)
        {
            // Mapping each character to its occurrence position
            for (int i = 0; i < order.Length; customMapper[order.ToLower()[i]] = i++) ;

            // Custom sorting based on customMapper order
            paragraph.Sort(Compare);

            // Printing the sorted order of words
            Console.WriteLine(string.Join(" ", paragraph));
        }

        // Custom comparator function for sort
        static int Compare(string a, string b)
        {
            int minLength = Math.Min(a.Length, b.Length);

            for (int i = 0; i < minLength; i++)
            {
                if (customMapper[a.ToLower()[i]] != customMapper[b.ToLower()[i]])
                {
                    return customMapper[a.ToLower()[i]] - customMapper[b.ToLower()[i]];
                }
            }

            return a.Length - b.Length;
        }
    }
}