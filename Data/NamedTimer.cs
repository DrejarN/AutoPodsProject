using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class NamedTimer : System.Timers.Timer
    {
        public readonly string name;
        public NamedTimer(string name)
        {
            this.name = name;
        }
    }
}
