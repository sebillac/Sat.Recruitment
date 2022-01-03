using System;
using System.IO;

namespace Sat.Recruitment.Api.Helpers
{
    public class FileHelper
    {
        public StreamReader ReadDataFromFile(string fileName)
        {
            string path = $"{ Directory.GetCurrentDirectory()}/Files/{fileName}.txt";

            FileStream fileStream = new FileStream(path, FileMode.Open);

            StreamReader reader = new StreamReader(fileStream);
            return reader;
        }
    }
}
