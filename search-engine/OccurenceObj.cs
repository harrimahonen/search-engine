using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace search_engine
{
    public class OccurenceObj
    {
        public int DocumentId { get; set; }
        public int Counter { get; set; }

        public override string ToString()
        {
            return ""+Counter;
        }
    }
}
