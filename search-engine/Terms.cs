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
        public OccurenceObj CountInDocs;
        public int AppearenceInDocs { get; set; }

        public string getDocNrs(Terms o)
        {
            string temp = "";
            foreach (object item in o.DocId)
            {
                temp += item +", ";
            }
            return temp;
        }


        public override string ToString()
        {
            return "Term: " + Term + "  DocumentID: " + getDocNrs(this) +"  Appears in: " + AppearenceInDocs +" documents and occurs # times: ";
        }
    }

}
