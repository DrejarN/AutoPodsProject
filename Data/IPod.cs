using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModels;

namespace Data
{
    public interface IPod
    {
        string filenameForJson { get; set; }
        void deserializeList(string file);
    }
}
