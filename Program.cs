using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;


namespace jb223pu_examination_1
{
    class Program
    {
        class Statistics
        {
        static void Main(string[] args)
        {
            var textFile = File.ReadAllText("data.json");
            var jsonArray = JsonConvert.DeserializeObject<int[]>(textFile);
            
            Console.WriteLine(DescriptiveStatistics(jsonArray));
        }

        static dynamic DescriptiveStatistics(int[] source)
        {
            if (source == null)
            {
                return "Error";
            }

            string displayedResult = ($"Maximum: {Maximum(source)}\r\nMinimum: {Minimum(source)}\r\nMean: {Mean(source)}\r\nMedian: {Median(source)}\r\nMode: {Mode(source)}\r\nRange: {Range(source)}\r\nStandard deviation: {StandardDeviation(source)}");

            return displayedResult;
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
            if (source.Count() < 2) return 0.0;
            double sumOfSquares = 0.0;
            double average = source.Average(); //.NET 3.0
            foreach (double value in source) 
            {
                sumOfSquares += Math.Pow((value - average), 2);
            }
            return Math.Sqrt(sumOfSquares / (source.Count()));
            
            }
        }
    }
}
