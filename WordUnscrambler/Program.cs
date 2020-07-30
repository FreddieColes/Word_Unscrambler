using System;
using System.Collections.Generic;
using System.Linq;
using WordUnscrambler.Data;
using WordUnscrambler.Workers;

namespace WordUnscrambler
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();


        static void Main(string[] args)
        {

            try
            {
                bool continueWordUnscramble = true;
                do
                {

                    Console.WriteLine(Constants.OptionsOnHowToEnterScrambledWords);
                    var option = Console.ReadLine() ?? string.Empty;

                    switch (option.ToUpper())
                    {
                        case Constants.File:
                            Console.Write(Constants.EnterScrambledWordsViaFile);
                            ExecuteScrambledWordsInFileScenario();
                            break;
                        case Constants.Manual:
                            Console.Write(Constants.EnterScrambledWordsManually);
                            ExecuteScrambledWordsManualEntryScenario();
                            break;
                        default:
                            Console.Write(Constants.EnterScrambledWordsOptionNotRecognised);
                            break;
                    }

                    var continueDecision = string.Empty;
                    do
                    {
                        Console.WriteLine(Constants.OptionsOnContinuingTheProgram);
                        continueDecision = (Console.ReadLine() ?? string.Empty);
                    } while (
                        !continueDecision.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase) &&
                        !continueDecision.Equals(Constants.No, StringComparison.OrdinalIgnoreCase));

                    continueWordUnscramble = continueDecision.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase);

                } while (continueWordUnscramble);
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorProgramWillBeTerminated + ex.Message);
            }
        }

        private static void ExecuteScrambledWordsManualEntryScenario()
        {
            var manualInput = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = manualInput.Split(',');
            DisplayMatchedUnscrambledWords(scrambledWords);
        }

        private static void ExecuteScrambledWordsInFileScenario()
        {
            try
            {
                var filename = Console.ReadLine() ?? string.Empty;
                string[] scrambledWords = _fileReader.Read(filename);
                DisplayMatchedUnscrambledWords(scrambledWords);
            }

            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorScrambledWordscannotBeLoaded + ex.Message);
            }
        }

        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
        {
            string[] wordlist = _fileReader.Read(Constants.WordListFileName);

            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordlist);

            if (matchedWords.Any())
            {
                foreach (var matchedWord in matchedWords)
                {
                    Console.WriteLine(Constants.MatchFound, matchedWord.ScrambledWord, matchedWord.Word);
                }


            }
            else
            {
                Console.WriteLine(Constants.MatchNotFound);
            }
        }
    }
}

//System.IO has a nice way to read and write to files
//string[] lines = { "This is the first line", "This is the second line", "This is the third line" };
//File.WriteAllLines("MyFirstFile.txt", lines);

//        string[] fileContents = File.ReadAllLines("MyFirstFile.txt");

//        //With bigger files we need to read line by line
//        foreach(string line in File.ReadLines("MyFirstFile.txt"))
//        {
//            Console.WriteLine(line);
//        }


////constants cannot be initialised on runtime
////constant's cannot hold user created types (such as person here) (readonly's can)
//public const string someText = "This is text";
////if we want to use readonly variables in static strings we need to write this, (const is implicitaly static)
//public static readonly string someOtherText = "This is some other text";

//static void Main(string[] args)
//{

//    Console.WriteLine(someText);
//    Console.WriteLine(someOtherText);

//}

////null just means no object
//Person person = new Person("John", "Smith");
////The question marks say if person is null then we will return Default, but if not we will return Person 
//Person newPerson = person ?? new Person("Default", "Person");

//Console.WriteLine(newPerson.FirstName);

//    int a = 10;
//    //Putting out (or ref) in this and the method will cause it to act as a reference rather than a value (put the data value in the Heap instead of the Stack)
//    //if using ref the parameter being used has to be initilized (given a value) whereas out does not care about this
//    //if using out the value going out of the other method must have a value/assignment, ref doesnt care about this  
//    ChangeNumber(out a);
//    Console.WriteLine(a);


//static void ChangeNumber(out int a)
//{
//    a = 90;
//}

//int[] array = { 1, 5, 7, 9, 10 };
//List<int> list = new List<int> { 1, 5, 7, 9, 10 };

//        //list.Count is the same as array.Length
//        //Starts from the start and goes through to end (most basic)
//        foreach(var i in array)
//        {
//            Console.WriteLine(i);
//        }

//        //Use over a foreach if you need the index (doesnt go in straight order/ doesnt include certain parts etc.)
//        for(int i=0; i<array.Length; i++)
//        {
//            Console.WriteLine(array[i]);

//        }

//        //Use while loop when you dont have a set upper bound, as a condition can be applied instead
//        int index = 0;
//        while (index<array.Length)
//        {
//            Console.WriteLine(array[index]);
//            index++;
//        }


