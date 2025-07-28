using CatFactLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFactLibrary.Service
{
    public interface IFileService
    {
        void SaveFile(FactModel model);
        List<FactModel> LoadFile();
        bool ClearFile();
    }
}
