using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace search_engine
{
    class Terms
    {
        public string Term { get; set; }
        public List<int> DocId = new List<int>();
        public List<OccurenceObj> CountInDocs = new List<OccurenceObj>();
        public int AppearenceInDocs { get; set; }

        public string GetDocNrs(Terms o)
        {
            string temp = "";
            foreach (object item in o.DocId)
            {
                temp += item +", ";
            }
            return temp;
        }
        public string GetCountDoc(Terms o)
        {
            string temp = "";
            foreach (object item in o.CountInDocs)
            {
                temp += item + ", ";
            }
            return temp;
        }


        public override string ToString()
        {
            return "Term: " + Term + "  DocumentID: " + GetDocNrs(this) +"  Appears in " + AppearenceInDocs +" of documents and frequency is "+ GetCountDoc(this) +"";
        }
    }

}
