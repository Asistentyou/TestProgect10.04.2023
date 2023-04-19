using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVC
{
    internal interface IFileService
    {
        List<Blyda> Open(string filename);
        void Save(string filename, List<Blyda> phonesList);
    }
}