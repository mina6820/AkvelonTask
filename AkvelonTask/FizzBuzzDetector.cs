using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AkvelonTask
{
    /// <summary>
    /// Implements the FizzBuzz detection logic.
    /// Every third alphanumeric word is replaced with "Fizz", every fifth with "Buzz",
    /// and every fifteenth with "FizzBuzz". Only words with alphanumeric core (after
    /// stripping punctuation) are counted.
    /// </summary>
    public class FizzBuzzDetector
    {
        /// <summary>
        /// Processes the input string to replace every third alphanumeric word with "Fizz",
        /// every fifth with "Buzz", and every fifteenth with "FizzBuzz", while preserving
        /// non-alphanumeric tokens and whitespace. Returns the modified string and the count
        /// of replacements made.
        /// </summary>
        /// <param name="input">The input string to process, must be between 7 and 100 characters.</param>
        /// <returns>
        /// A <see cref="FizzBuzzResult"/> object containing the modified output string and the
        /// number of replacements (where each "Fizz", "Buzz", or "FizzBuzz" counts as 1).
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the input string is null, or its length is less than 7 or greater than 100.
        /// </exception>
        public FizzBuzzResult GetOverlappings(string input)
        {
            if (input == null)
            {
                throw new ArgumentException("Input string cannot be null.");
            }

            input = input.Replace("\r\n", "\n");
            if (input.Length < 7 || input.Length > 100)
            {
                throw new ArgumentException("Input string length must be between 7 and 100 characters.");
            }


            string[] tokens = Regex.Split(input, @"(\s+)");
            int wordCount = 0;
            int replacementCount = 0;
            var outputBuilder = new StringBuilder();

            foreach (string token in tokens)
            {
                if (string.IsNullOrEmpty(token) || string.IsNullOrWhiteSpace(token))
                {
                    outputBuilder.Append(token);
                    continue;
                }

                // Remove punctuation from the beginning and end to obtain the core word.
                int start = 0;
                int end = token.Length;
                while (start < end && char.IsPunctuation(token[start]))
                {
                    start++;
                }
                while (end > start && char.IsPunctuation(token[end - 1]))
                {
                    end--;
                }
                string coreWord = token.Substring(start, end - start);

                if (!string.IsNullOrEmpty(coreWord) && IsAlphanumeric(coreWord))
                {
                    wordCount++;
                    string replacement = null;
                    if (wordCount % 15 == 0)
                    {
                        replacement = "FizzBuzz";
                    }
                    else if (wordCount % 3 == 0)
                    {
                        replacement = "Fizz";
                    }
                    else if (wordCount % 5 == 0)
                    {
                        replacement = "Buzz";
                    }

                    if (replacement != null)
                    {
                        outputBuilder.Append(replacement);
                        replacementCount++;
                        continue;
                    }
                }

                outputBuilder.Append(token);
            }

            return new FizzBuzzResult
            {
                Output = outputBuilder.ToString(),
                Count = replacementCount
            };
        }

        /// <summary>
        /// Determines whether a string is alphanumeric.
        /// </summary>
        /// <param name="s">The string to check.</param>
        /// <returns>
        /// True if all characters in the string are letters or digits; otherwise, false.
        /// </returns>
        private bool IsAlphanumeric(string s)
        {
            foreach (char c in s)
            {
                if (!(char.IsLetterOrDigit(c) || c == '\''))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
