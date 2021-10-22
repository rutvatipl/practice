using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppInterviewLogical
{
    class SortStringAlpha
    {

        static void Main(string[] args)
        {   // Creates list of type string
            List<string> list = new List<string>();
            // Writes for sentence
            Console.Write("Enter your sentence. No punctuation.   : ");
            // Converts console into string
            string sent = (Console.ReadLine());
            // Splits string into array
            string[] words = sent.Split();
            // Writes array to list
            for (int i = 0; i < words.Length; i++)
            {
                list.Add(words[i]);
            }
            // Sorts words

            
            var sort =
                from word in list
                let lowerWord = word.ToLower()
                orderby lowerWord
                select lowerWord;

            


            // I assume a var query goes here to delete dup words

            // Writes words
            foreach (string c in sort)
            {
                Console.WriteLine(c);
            }
        }
    }
}
