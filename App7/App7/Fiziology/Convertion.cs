using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App7.Helpers;

namespace App7.Fiziology
{
   public static class Convertion
    {
        public static double StepsToCall(double steps)
        {
            double cal = (0.023*Math.Pow(Settings.Speed,3)- 0.1765 * Math.Pow(Settings.Speed, 2)+ 0.8710 * Settings.Speed)*
                Settings.Weight*(Settings.StepLength/(1000*Settings.Speed))*steps;
            return cal;
        }
    }
}
