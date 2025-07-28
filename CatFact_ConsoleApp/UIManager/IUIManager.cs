using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFact_ConsoleApp
{
    public interface IUIManager
    {
        void PrintLogo();
        void PrintError(string message);
        void PrintSuccess(string message);
        void Print(string message);
        void Clear();
    }
}
