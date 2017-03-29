using System;
using System.Linq;

namespace jb223pu_examination_1
{
    static class Statistics
    {
        public static dynamic DescriptiveStatistics(int[] source)
            {
                if (source == null)
                {
                    throw new ArgumentNullException();
                }
                else if (source.Length == 0)
                {
                    throw new InvalidOperationException("Sequence contains no elements");
                }

                var modeArray = Mode(source);

                string displayedResult = ($"Maximum: {Maximum(source)}\r\nMinimum: {Minimum(source)}\r\nMean: {Mean(source)}\r\nMedian: {Median(source)}\r\nMode: {string.Join(", ", modeArray)}\r\nRange: {Range(source)}\r\nStandard deviation: {StandardDeviation(source)}");
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
                    return Math.Round((mean), 1);
                }

            static double Median(int[] source)
                {
                    int[] temp = (int[])source.Clone();    
                    Array.Sort(temp);
                    
                    

                    if (temp.Count() % 2 == 0)
                    {
                        int a = temp[temp.Count() / 2 -1];
                        int b = temp[temp.Count() / 2];
                        double result = (a + b) / 2;

                        return Math.Round((result), 1);
                    }
                    else
                    {
                        double result = temp[temp.Count() / 2];
                        return Math.Round((result), 1);
                    }
                }

            static int Range(int[] source)
                {
                    return source.Max() - source.Min();
                }

            static int[] Mode(int[] source)
                {
                    var temp = source
                            .GroupBy(x => x)
                            .Select(g => new { Value = g.Key, Count = g.Count() })
                            .ToArray(); // materialize the query to avoid evaluating it twice below
                    int maxCount = temp.Max(g => g.Count);

                    int[] result = new int[100];
                    int j = 0;

                    foreach (var i in temp)
                    {
                        if (i.Count == maxCount)
                        {
                            result[j++] = i.Value;
                        }
                    }

                    int zero = 0;

                    return result
                            .Where(x => x > zero)
                            .ToArray();                           
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
                double result = Math.Sqrt(sumOfSquares / (source.Count()));
                return Math.Round((result), 1);
                
                }
    }
}