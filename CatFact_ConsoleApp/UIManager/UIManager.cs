using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFact_ConsoleApp
{
    public class UIManager : IUIManager
    {
        //This class lets you print app logo, and colorize text
        public void PrintLogo()
        {
            ChangeColor(ConsoleColor.White);
            Console.WriteLine("======================================================================\n" +
                "  ____      _        _  \t\t\n" +
                " / ___|__ _| |_     / \\   _ __  _ __  \t\t\n" +
                "| |   / _` | __|   / _ \\ | '_ \\| '_ \\ \t _._     _,-'\"\"`-._\r\n" +
                "| |__| (_| | |_   / ___ \\| |_) | |_) |\t(,-.`._,'(       |\\`-/|\r\n" +
                " \\____\\__,_|\\__| /_/   \\_\\ .__/| .__/ \t    `-.-' \\ )-`( , o o)\r\n" +
                "                         |_|   |_|   \t          `-    \\`_`\"'-\n" +
                "======================================================================\n");
        }
        public void PrintError(string message)
        {
            //Print Error
            ChangeColor(ConsoleColor.Red);
            Console.WriteLine(message);
            ChangeColor(ConsoleColor.White);
        }

        public void PrintSuccess(string message)
        {
            //Print Success(Green)
            ChangeColor(ConsoleColor.Green);
            Console.WriteLine(message);
            ChangeColor(ConsoleColor.White);
        }

        public void Print(string message)
        {
            //Normal Print
            ChangeColor(ConsoleColor.White);
            Console.WriteLine(message);

        }

        private void ChangeColor(ConsoleColor color)
        {
            //Make sure that color turn back to white
            Console.ForegroundColor = color;
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
