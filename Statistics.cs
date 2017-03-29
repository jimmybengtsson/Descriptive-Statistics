using System;
using System.Linq;

namespace jb223pu_examination_1
{
    static class Statistics
    {
        // DescriptiveStatistics method where all the other methods is called.

        public static dynamic DescriptiveStatistics(int[] source)
            {
                // Error-handling.

                if (source == null)
                {
                    throw new ArgumentNullException();
                }
                else if (source.Length == 0)
                {
                    throw new InvalidOperationException("Sequence contains no elements");
                }

                // Set the array for Mode method so it can be written later.

                var modeArray = Mode(source);

                // A string with the final result.
                string displayedResult = ($"Maximum: {Maximum(source)}\r\nMinimum: {Minimum(source)}\r\nMean: {Mean(source)}\r\nMedian: {Median(source)}\r\nMode: {string.Join(", ", modeArray)}\r\nRange: {Range(source)}\r\nStandard deviation: {StandardDeviation(source)}");
                return displayedResult;
            }

            // Max value

            static int Maximum(int[] source)
                {
                    int maxValue = source.Max();
                    return maxValue;
                }

            // Min value

            static int Minimum(int[] source)
                {
                    int minValue = source.Min();
                    return minValue;
                }

            // Meanv alue (average)

            static double Mean(int[] source)
                {
                    double mean = source.Average();
                    // Only one decimal
                    return Math.Round((mean), 1);
                }

            // Median value

            static double Median(int[] source)
                {
                    // Sort the array
                    Array.Sort(source);
                    
                    // If array is even and has to values in middle...
                    if (source.Count() % 2 == 0)
                    {
                        int a = source[source.Count() / 2 -1];
                        int b = source[source.Count() / 2];
                        // .. divide the sum of the two values by 2.
                        double result = (a + b) / 2;
                
                        // Only one decimal
                        return Math.Round((result), 1);
                    }
                    // If array is odd then return the middle value with one decimal.
                    else
                    {
                        double result = source[source.Count() / 2];
                        return Math.Round((result), 1);
                    }
                }

                // Range value

            static int Range(int[] source)
                {
                    return source.Max() - source.Min();
                }

                // Mode

            static int[] Mode(int[] source)
                {
                    // Count all values in array.
                    var temp = source
                            .GroupBy(x => x)
                            .Select(g => new { Value = g.Key, Count = g.Count() })
                            .ToArray(); // materialize the query to avoid evaluating it twice below

                    // Set the maxcount.
                    int maxCount = temp.Max(g => g.Count);

                    // New array for all the modes
                    int[] result = new int[100];
                    int j = 0;

                    // Loop through array to get all the max and add to the new array.
                    foreach (var i in temp)
                    {
                        if (i.Count == maxCount)
                        {
                            result[j++] = i.Value;
                        }
                    }

                    int zero = 0;

                    // Return result with all zeros filtered.
                    return result
                            .Where(x => x > zero)
                            .ToArray();                           
                }

            // Standard deviation
            // Took a lot of help from this forum-topic "http://stackoverflow.com/questions/895929/how-do-i-determine-the-standard-deviation-stddev-of-a-set-of-values"

            static double StandardDeviation(int[] source)
                {
                if (source.Count() < 2) return 0.0;
                double sumOfSquares = 0.0;
                double average = source.Average();
                foreach (double value in source) 
                {
                    sumOfSquares += Math.Pow((value - average), 2);
                }
                double result = Math.Sqrt(sumOfSquares / (source.Count()));
                return Math.Round((result), 1);
                
                }
    }
}