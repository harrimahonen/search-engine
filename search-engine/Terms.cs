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
        public int DocId { get; set; }

        public override string ToString()
        {
            return "Term: " + Term + "  DocumentID: " + DocId;
        }
    }

}
