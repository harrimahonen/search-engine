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
            //init variables
            char[] delimiterChars = { ' ', '\n', };
            List<Document> allDocuments = new List<Document>();

            // get path to folder and get all .txt files in collections folder
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string pathToCol = path + "\\collections\\";
            string[] filePath = Directory.GetFiles(pathToCol, "*.txt", SearchOption.TopDirectoryOnly);

            //Incase we need to output into txt file
            //string outputFile = pathToCol + "\\output.txt";


           

            // documentIndex == Current document == document ID
            for (var documentIndex = 0; documentIndex < filePath.Length; documentIndex++)
            {
                //TOKENIZE

                //Go through each document
                //Get Text Output
                string readText = File.ReadAllText(filePath[documentIndex]);
                //remove whitespace
                var lines = readText.Split('\n')
                        .Where(line => !string.IsNullOrWhiteSpace(line));
                // join them again after split
                string output = string.Join("\n", lines);
                // get punctiations
                var punctuation = output.Where(Char.IsPunctuation).Distinct().ToArray();
                //split and remove empty and punctiations
                var words = output.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim(punctuation));
                //new temp list to clean up words further
                List<String> temp = new List<string>();
                //remove special characters
                foreach (string item in words)
                {
                    var cleanUp = item.RemoveSpecialCharacters();
                    temp.Add(cleanUp);
                }
                //get only items that are not empty or null
                //Tokenizing ready
                var cleanOutput = temp.Where(x => !string.IsNullOrEmpty(x.Trim())).ToArray();
                //Need list of all words in document to check their count
                var checkAgainst = string.Join(" ", cleanOutput);

                var grouping = GetDictionary(cleanOutput);
                Document newDoc = new Document
                {
                    id = documentIndex,
                    words = grouping
                };
                allDocuments.Add(newDoc);
                Console.WriteLine("End of Document # " + documentIndex);
            }
            Console.WriteLine("End of All Documents. Number of Documents: " + allDocuments.Count );

        }
        public static Dictionary<string, int> GetDictionary(string[] o)
        {
          var tt = o.GroupBy(txt => txt)
                    .Where(grouping => grouping.Count() > 0)
                    .ToDictionary(g => g.Key, g => g.Count());
            foreach(object i in tt)
            Console.WriteLine(i);
            return tt;
        }

        public class Document
            {
                public int id;
                public Dictionary<string, int> words;
        }
    }
}
                        
