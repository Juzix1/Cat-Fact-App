using CatFactLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFactLibrary.Service
{
    public class CatFactManager : ICatFactManager
    {

        //this Manager has all methods required for app to work, all in one place
        private readonly IFileService _fileService;
        private readonly IRequestService _requestService;
        public CatFactManager() {

            _fileService = new FileService();
            _requestService = new RequestService();
        }

        public List<FactModel> GetFactFromFile()
        {
            return _fileService.LoadFile();
        }

        public async Task<FactModel?> GetFactFromRequest()
        {
            //Makes Get request for fact and saves it to file
            var fact = await _requestService.GetFactAsync();
            SaveFactToFile(fact);
            return fact;

        }

        public void SaveFactToFile(FactModel model)
        {
            _fileService.SaveFile(model);
        }

        public bool ClearFactFile()
        {
            return _fileService.ClearFile();
        }
    }
}
