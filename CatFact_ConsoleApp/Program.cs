
using CatFact_ConsoleApp;
using CatFactLibrary.Model;
using CatFactLibrary.Service;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Text;

var UI = new UIManager();

var Run = true;
var factManager = new CatFactManager();
bool isFirstRun = true;

while (Run)
{

    try
    {
        var fact = new FactModel(null, 0);
        if (isFirstRun)
        {
            isFirstRun = false;
            UI.Clear();
            UI.PrintLogo();

        }

        if (fact != null)
        {
            string choice = "";
            UI.Print("\nSelect:\n(R)efresh Facts\n(C)lear the Facts file\n(L)oad Facts from file\n(Q)uit");
            choice = Console.ReadLine();

            switch (choice)
            {
                //nowy fakt
                case "r":
                case "R":
                    UI.Clear();
                    UI.PrintLogo();
                    fact = factManager.GetFactFromRequest().Result;
                    UI.Clear();
                    UI.PrintLogo();
                    UI.Print(fact.Fact);
                    break;
                //zobacz fakty z pliku
                case "l":
                case "L":
                    UI.Clear();
                    UI.PrintLogo();
                    var factsList = factManager.GetFactFromFile();

                    if(factsList.Count == 0)
                    {
                        UI.PrintError("The file is missing. Refresh fact to create new file!");
                    }
                    else
                    {
                       UI.PrintSuccess("Loading Fact from file");
                       
                        
                        for(int i = 0; i < factsList.Count; i++)
                        {
                            UI.Print($"{i+1}. {factsList[i].Fact}");
                        }
                    }
                    break;
                //wyczysc plik
                case "c":
                case "C":

                    UI.Clear();
                    UI.PrintLogo();
                    if (factManager.ClearFactFile())
                    {
                        UI.PrintSuccess("Successfully Cleared the file!");
                    }
                    else
                    {
                        UI.PrintError("The file is missing. Refresh fact to create new file!");
                    }

                        break;
                //wyjdz
                case "q":
                case "Q":
                    UI.Print("GoodBye!");
                    Run = false;
                    break;
                default:
                    UI.Clear();
                    UI.PrintLogo();
                    UI.Print("There no such option, please select again");
                    break;
            }
        }
    }catch (Exception ex)
    {
        UI.PrintError(ex.Message);
    }
}
