using System;
using System.IO;
using System.Linq;

public class FileService : IFileService
{
    public string[] ReadWordsFromFile(string filePath)
    {
        try
        {
 
            if (File.Exists(filePath))
            {
           
                var words = File.ReadLines(filePath)
                                .SelectMany(line => line.Split(new[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries))
                                .ToArray();

                return words;
            }
            else
            {
               
                return new string[0];
            }
        }
        catch (Exception )
        {
           
            return new string[0];
        }
    }
}
