using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding.Exercise
{
    
    public class InlineArray
    {
        public static string completeString;
        public static string Inline(string[] arrayOfStrings)
        {
            foreach(string item in arrayOfStrings)
            {
                completeString += item;
                Console.WriteLine(completeString);
            }
            return completeString;
        }
    }
}
