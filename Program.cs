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
            Console.WriteLine(Mean(jsonArray));
            Console.WriteLine(Median(jsonArray));
            Console.WriteLine(Range(jsonArray));
            Console.WriteLine(Mode(jsonArray));
            Console.WriteLine(StandardDeviation(jsonArray));
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

        static double Mean(int[] source)
            {
                double mean = source.Average();
                return mean;
            }

        static double Median(int[] source)
            {
                int[] temp = (int[])source.Clone();    
                Array.Sort(temp);
                
                

                if (temp.Count() % 2 == 0)
                {
                    int a = temp[temp.Count() / 2 -1];
                    int b = temp[temp.Count() / 2];
                    return (a + b) / 2;
                }
                else
                {
                    return temp[temp.Count() / 2];
                }
            }

        static int Range(int[] source)
            {
                return source.Max() - source.Min();
            }

        static int Mode(int[] source)
            {
                return source.GroupBy(v => v)
                                .OrderByDescending(g => g.Count())
                                .First()
                                .Key;
            }

        static double StandardDeviation(int[] source)
            {
                double average = source.Average();
                double sumOfDerivation = 0;  
                foreach (double value in source)  
                {  
                sumOfDerivation += (value) * (value);  
                }  
                double sumOfDerivationAverage = sumOfDerivation / (source.Count() - 1);  
                return Math.Sqrt(sumOfDerivationAverage - (average*average));  
            }
    }
}
