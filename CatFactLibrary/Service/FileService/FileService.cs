using CatFactLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CatFactLibrary.Service
{
    public class FileService : IFileService
    {
        public FileService() { 
            
        }

        private string path = "";

        public List<FactModel> LoadFile()
        {
            try
            {
                GetPath();
                if (File.Exists(path))
                {
                    //If file exists, method loads Json structure and puts this in List for easier access
                    
                    using (StreamReader sr = File.OpenText(path))
                    {
                        string s;
                        List<FactModel> facts = new List<FactModel>();
                        while ((s = sr.ReadLine()) != null)
                        {
                            FactModel? model = JsonSerializer.Deserialize<FactModel>(s);
                            facts.Add(model);

                        }
                        return facts;
                    }
                }
                else
                {
                    //If it does not exist, makes a empty list
                    return new List<FactModel>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<FactModel>(); ;
            }
        }

        public void SaveFile(FactModel model)
        {
            try
            {
                if (model == null)
                    return;

                GetPath();
                if (!File.Exists(path))
                {
                    //If file doesn't exist, makes a new one and adds cat fact 
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        string jsonString = JsonSerializer.Serialize(model);
                        sw.WriteLine(jsonString);
                    }
                }
                else
                {
                    if (!SearchForDuplicates(model))
                    {
                        using (StreamWriter sw = File.AppendText(path))
                        {
                            string jsonString = JsonSerializer.Serialize(model);
                            sw.WriteLine(jsonString);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public bool ClearFile()
        {
            //Method for deleting file
            GetPath();
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            return false;
            
        }

        private void GetPath()
        {
            //Get the Parent folder, creates a CatFacts.txt file outside the project folder
            string root = TryGetSolutionDirectoryInfo().Parent.FullName;
            path = Path.Combine(root, "CatFacts.txt");
        }

        //Method that checks for duplicate facts, if it detects one, will not append fact
        private bool SearchForDuplicates(FactModel model)
        {
                GetPath();
                string s;
                StreamReader sr = File.OpenText(path);
                while ((s = sr.ReadLine()) != null)
                {
                    if (model.Fact.Equals(s))
                    {
                        sr.Close();
                        return true;
                    }
                }
                sr.Close();
                    
                return false;

        }

        //Getting the Parent Directory
        private static DirectoryInfo TryGetSolutionDirectoryInfo(string currentPath = null)
        {
            var directory = new DirectoryInfo(
                currentPath ?? Directory.GetCurrentDirectory());
            while (directory != null && !directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }
            return directory;
        }
    }
}
