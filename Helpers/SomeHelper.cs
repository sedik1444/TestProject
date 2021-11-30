using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestProject.Helpers
{
    public static class SomeHelper
    {
        public static string Filter(string str)
        {
            var stringsToRemove = new List<string>() { "Name:" ,"Email:"," ", "Website:","Experience(InYears):" ,"Comment:","Expertise::","Education:" };
            return stringsToRemove.Aggregate(str, (current, strings) => current.Replace(strings, ""));
        }
        
        public static string GetAbsoluteFilePath(params string[] relativeFilePaths)
        {
            var relativeFilePath = Path.Combine(relativeFilePaths);
            var currentDirectoryPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            return Path.Combine(currentDirectoryPath!, relativeFilePath);
        }
    }
   
    
    
}