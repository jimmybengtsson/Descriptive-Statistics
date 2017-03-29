using System;
using System.IO;
using Newtonsoft.Json;


namespace jb223pu_examination_1
{
    class Program
    {
       
        static void Main(string[] args)
        {
            var textFile = File.ReadAllText(args[0]);
            var jsonArray = JsonConvert.DeserializeObject<int[]>(textFile);
            
            Console.WriteLine(Statistics.DescriptiveStatistics(jsonArray));
        }
    }
}

