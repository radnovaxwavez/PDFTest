using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFTest
{
    public interface ISave
    {
        //Saving to RAM
        string Save(MemoryStream fileStream);
    }
}
