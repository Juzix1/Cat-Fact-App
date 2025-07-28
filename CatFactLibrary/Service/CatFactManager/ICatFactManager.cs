using CatFactLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFactLibrary.Service
{
    public interface ICatFactManager
    {
        void SaveFactToFile(FactModel model);
        List<FactModel?> GetFactFromFile();
        Task<FactModel?> GetFactFromRequest();
        bool ClearFactFile();
    }
}
