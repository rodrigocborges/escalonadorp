using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalonadorP
{
    public class Process
    {
        public int id { private set; get; }
        public int incoming { private set; get; }
        public int execution { private set; get; }
        public int status { set; get; }

        public Process(int id, int incoming, int execution)
        {
            this.id = id;
            this.incoming = incoming;
            this.execution = execution;
            this.status = 0;
        }
    }
}
