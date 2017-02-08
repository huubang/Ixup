using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ixup.Business
{
    public static class StringExtensions
    {
        /// <summary>
        /// Reverses each and every words in a sentence without changing the order of the words.
        /// Time complexity: O(n)
        /// </summary>
        /// <param name="sentence">The sentence whose words are to be reversed.</param>
        public static string ReverseWords(this string sentence)
        {
            char[] wholeSentence = sentence.ToCharArray();
            int pointer = 0;

            while (pointer < wholeSentence.Length)
            {
                // Skip white spaces
                while (pointer < wholeSentence.Length && char.IsWhiteSpace(wholeSentence[pointer]))
                {
                    pointer++;
                }

                // Mark the front of the word
                var front = pointer;

                // Skip non-whitespace characters
                while (pointer < wholeSentence.Length && !char.IsWhiteSpace(wholeSentence[pointer]))
                {
                    pointer++;
                }

                // Mark the back of the word
                var back = pointer - 1;

                // Reverse the word
                while (front < back)
                {
                    char t = wholeSentence[front];
                    wholeSentence[front++] = wholeSentence[back];
                    wholeSentence[back--] = t;
                }
            }

            return new string(wholeSentence);
        }
    }
}
