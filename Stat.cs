/***********************************
*  Jason Thatcher		2018
*  Stat.CS
*  
*  C# Class to perform basic stat calc
*  Mean, Mode, Median, Standard
*  Deviation for Population and Sample,
*  Variance, etc.
************************************
*/


using System;
using System.Collections.Generic;

namespace Stat
{
    public static class Stat
    {
        public static double[] ConvertIntToDouble(int[] val)
        {
            double[] result = new double[val.Length];
            int counter = 0;

            foreach(int i in val)
            {
                result[counter++] = (double)i;                
            }

            return result;
        }

        public static double[] ConvertDecimalToDouble(decimal[] val)
        {
            double[] result = new double[val.Length];
            int counter = 0;

            foreach (decimal i in val)
            {
                result[counter++] = (double)i;
            }

            return result;
        }

        public static double Mean(double[] val)
        {
            double result = 0.0d;

            foreach(double d in val)
            {
                result += d;
            }

            double denominator = (double)val.Length;
            result = result / denominator;

            return result;
        }

        
        public static double Median(double[] val)
        {
            double result = 0.0d;

            Array.Sort(val);

            //if even return avg of middle 2.  if odd return middle. remember 0-based...
            if (val.Length % 2 == 0)
            {
                result = (double)(((double)val[val.Length / 2] + (double)val[(val.Length / 2) - 1])/2);
            }
            else
            {
                result =(double)val[(val.Length / 2)];
                result = Math.Round(result);
            }

            return result;
        }

        public static string Mode (double[] val)
        {
            double result = 1.00d;
            string sResult = " ";

            Dictionary<double, double> occur = new Dictionary<double, double>();

            foreach (double d in val)
            {
                if (occur.ContainsKey(d))
                {
                    occur[d] += 1;
                }
                else
                {
                    occur.Add(d, 1d);
                }
            }
                        
            foreach(KeyValuePair<double, double> kvp in occur)
            {
                if(kvp.Value > result)
                {
                    result = kvp.Key;
                }
            }

            if (result.Equals(1.00d))
            {
                sResult = "No Mode";
            }
            else
            {
                sResult = result.ToString("N2");
            }

            return sResult;
        }

        public static double VarianceSample(double[] val)
        {
            double result = 0.0d;
            double mean = Mean(val);

            foreach(double d in val)
            {
                double dif = mean - d;
                dif = Math.Abs(dif);
                dif = Math.Pow(dif, 2);
                result += dif;
            }

            result = result / (double)(val.Length - 1);
            
            return result;
        }

        public static double VariancePopulation(double[] val)
        {
            double result = 0.0d;
            double mean = Mean(val);

            foreach (double d in val)
            {
                double dif = mean - d;
                dif = Math.Abs(dif);
                dif = Math.Pow(dif, 2);
                result += dif;
            }

            result = result / (double)val.Length;

            return result;
        }

        public static double StandardDeviationSample(double[] val)
        {
            double result = 0.0;

            result = VarianceSample(val);
            result = Math.Sqrt(result);

            return result;
        }

        public static double StandardDeviationPopulation(double[] val)
        {
            double result = 0.0;

            result = VariancePopulation(val);
            result = Math.Sqrt(result);

            return result;
        }

    }
}
