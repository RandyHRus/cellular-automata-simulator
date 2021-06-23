using System;
using System.Collections.Generic;
using UnityEngine;

namespace Chemicals
{
    public class ChemicalColors
    {
        private List<Color> colors;

        public ChemicalColors(List<Color> colors)
        {
            if (colors.Count < 1)
            {
                throw new System.Exception("Not enough colors");
            }
            this.colors = colors;
        }

        public Color GetColor(float value)
        {
            if (value < 0 || value > 1)
            {
                throw new System.Exception("Invalid value");
            }

            var floatIndex = value * (colors.Count - 1);
            var lowerBound = (int)Math.Floor(floatIndex);
            var upperBound = (int)Math.Ceiling(floatIndex);

            var color0 = colors[lowerBound];
            var color1 = colors[upperBound];

            var offset = floatIndex - lowerBound;
            return Color.Lerp(color0, color1, offset);
        }
    }
}