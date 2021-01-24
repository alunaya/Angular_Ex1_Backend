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
            return (float)Math.Round((random.NextDouble() * (maxValue - minValue)) + minValue, 2);
        }
    }
}
