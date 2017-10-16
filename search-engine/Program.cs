using System;
using System.IO;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace search_engine
{


    class Program
    {
        static void Main(string[] args)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t', '\n',  };
            string list = "";
            List<List<String>> wordPairing = new List<List<String>>();
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string pathToCol = path + "\\collections\\";
            string outputFile = pathToCol + "\\output.txt";
            string[] filePath = Directory.GetFiles(pathToCol, "*.txt", SearchOption.TopDirectoryOnly);
            HashSet<string> unique = new HashSet<string>();


            if (File.Exists(outputFile))
            {
                File.WriteAllText(outputFile, "");
            }


            // do this for each document
            for (int index = 0; index < filePath.Length; index++ )
            {
                wordPairing.Add(new List<String>());
                var item = filePath[index];
                string readFiles = File.ReadAllText(item);
                string final = StringProcessor.RemoveSpecialCharacters(readFiles);
                final = StringProcessor.FilterWhiteSpaces(final).ToLower();
                // final consists of only words without numbers and special characters, also lowercase

                // split into words
                
                string[] words = final.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
                unique = new HashSet<string>(words);
                //pair words with doc ID
                foreach (string word in unique)
                {
                    wordPairing[index].Add(word);
                }


                // query is a unique words counter
                var query = final
                            .Split(' ')
                            .ToLookup(x => x)
                            .Select(x => new
                            {
                                Word = x.Key,
                                Count = x.Count(),
                            });

                /* foreach (object o in wordPairing)
                {

                    list += o.ToString();
                } */


                for (var id = 0; id < wordPairing.Count; id++)
                {
                    for (var textVal = 0; textVal < wordPairing[id].Count; textVal++)
                    {
                        string temp = "";
                    }

                }
            }



            // after processing documents
            File.WriteAllText(outputFile, list);
        }
    }
}
