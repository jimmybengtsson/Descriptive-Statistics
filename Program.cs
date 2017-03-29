using System;
using System.IO;
using Newtonsoft.Json;


namespace Jb223puExamination1
{
    class Program
    {
       
        static void Main(string[] args)
        {
            // Read the json file and convert to array.

            var textFile = File.ReadAllText(args[0]);
            var jsonArray = JsonConvert.DeserializeObject<int[]>(textFile);

            // Call the DescriptiveStatistics method in Statistics class and write it to console.
            
            Console.WriteLine(Statistics.DescriptiveStatistics(jsonArray));
        }
    }
}

