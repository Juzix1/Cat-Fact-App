using CatFactLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFactLibrary.Service
{
    public interface IRequestService
    {
        Task<FactModel?> GetFactAsync();
    }
}
