using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular_Ex1_Backend
{
    public static class RandomExtension
    {
        public static float NextFloat(this Random random, float minValue, float maxValue)
        {
            double mantissa = (random.NextDouble() * 2.0) - 1.0;
            // choose -149 instead of -126 to also generate subnormal floats (*)
            //double exponent = Math.Pow(2.0, random.Next(-126, 128));
            double exponent = maxValue- minValue;
            return (float)(mantissa * exponent);
        }
    }
}
