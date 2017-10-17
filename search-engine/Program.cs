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
            char[] delimiterChars = { ' ', ',', '.', ':', '\t', '\n', };
            List<Terms> wordPairing = new List<Terms>();

            // get path to folder and get all files in collections folder
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
            for (int index = 0; index < filePath.Length; index++)
            {
                var item = filePath[index];
                string readFiles = File.ReadAllText(item);
                string final = StringProcessor.RemoveSpecialCharacters(readFiles);
                final = StringProcessor.FilterWhiteSpaces(final).ToLower();
                // final consists of only words without numbers and special characters, also lowercase

                // split into words

                string[] words = final.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
                unique = new HashSet<string>(words);
                List<string> uniqueList = unique.ToList();


                // TODO
                // Check for new Term
                // check for new DocId
                // Check for occurence number

                // loop words
                int docCounter = 1;
                for (int wordIndex = 0; wordIndex < words.Length; wordIndex++)
                {
                    // Check for new Term
                    // does wordPairing have the current word?
                    for (int pairingIndex = 0; pairingIndex < wordPairing.Count; pairingIndex++)
                    {
                        // TERM DOES NOT Exists in the list
                        //Add New Terms() with Term name, DocId, Doc Appearance and Count in current doc
                        if (wordPairing[pairingIndex].Term != words[wordIndex])
                        {
                            docCounter = 1;
                            wordPairing.Add(new Terms()
                            {
                                Term = words[wordIndex],
                                DocId = new List<int> { index },
                                AppearenceInDocs = 1,
                                CountInDocs = { DocumentId = index, Counter = docCounter }
                            });
                        }
                        // TERM DOES Exists in the list
                        // Check the Document 
                        else if (wordPairing[pairingIndex].Term == words[wordIndex])
                        {
                            // Check for document ID, if it !contains current document Index
                            // Push new document index and increase document freq counter
                            if (!wordPairing[pairingIndex].DocId.Contains(index))
                            {
                                wordPairing[pairingIndex].DocId = new List<int> { index };
                                wordPairing[pairingIndex].AppearenceInDocs++;
                            }
                            //Term Does Exists in the list and DocumentID is the same
                            // Check for occurance and increase counter
                            if (wordPairing[pairingIndex].DocId.Contains(index))
                            {
                                docCounter++;
                                wordPairing[pairingIndex].CountInDocs.DocumentId = index;
                                wordPairing[pairingIndex].CountInDocs.Counter = docCounter;
                            }
                        }
                    }
                }
            }
        }
    }
}
                        
