using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;


namespace jb223pu_examination_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var textFile = File.ReadAllText("data.json");
            var jsonArray = JsonConvert.DeserializeObject<int[]>(textFile);
            
            Console.WriteLine(Maximum(jsonArray));
            Console.WriteLine(Minimum(jsonArray));
        }

        static int Maximum(int[] source)
            {
                int maxValue = source.Max();
                return maxValue;
            }

        static int Minimum(int[] source)
            {
                int minValue = source.Min();
                return minValue;
            }
    }
}
