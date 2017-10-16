using System;
using System.IO;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace search_engine
{


    class Program
    {
        static void Main(string[] args)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t', '\n',  };


            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string pathToCol = path + "\\collections\\";
            string outputFile = pathToCol + "\\output.txt";
            string[] filePaths = Directory.GetFiles(pathToCol, "*.txt", SearchOption.TopDirectoryOnly);
            if (File.Exists(outputFile))
            {
                File.WriteAllText(outputFile, "");
            }
            string output = "";
            foreach (var item in filePaths)
            {
                string temp = "";
                string readFiles = File.ReadAllText(item);
                temp = readFiles;
                output += temp;
            }
            string[] words = output.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            string wordOutput = "";
            foreach(string item in words)
            {
                wordOutput += item + " ";
            }
            string final = StringProcessor.RemoveSpecialCharacters(wordOutput);
            final = StringProcessor.FilterWhiteSpaces(final);
            var query = final
                        .Split(' ')
                        .ToLookup(x => x)
                        .Select(x => new
                        {
                            Word = x.Key,   
                            Count = x.Count(),
                        });
            //File.WriteAllText(outputFile, query);
            string list = "";
            foreach (object o in query)
            {
                list += o.ToString();
            }
            File.WriteAllText(outputFile, list);
        }
    }
}
