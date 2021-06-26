using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Rules;
using UnityEngine;

namespace Chemicals
{
    public class Chemical
    {
        [JsonProperty] public List<Color32> chemicalColors { get; private set; }
        [JsonProperty] public readonly Rule rule;
        [JsonProperty] public readonly string chemicalName;
        [JsonProperty] public readonly string guid;

        [JsonConstructor]
        public Chemical()
        {
            
        }

        public Chemical(List<Color32> chemicalColors, Rule rule, string chemicalName)
        {
            if (chemicalColors.Count < 1)
            {
                throw new System.Exception("Not enough colors");
            }
            this.chemicalColors = chemicalColors;
            this.rule = rule;
            this.guid = System.Guid.NewGuid().ToString();
            this.chemicalName = chemicalName;
        }
        
        public Color GetColor(float value)
        {
            if (value < 0 || value > 1)
            {
                throw new System.Exception("Invalid value");
            }

            var floatIndex = value * (chemicalColors.Count - 1);
            var lowerBound = (int)Math.Floor(floatIndex);
            var upperBound = (int)Math.Ceiling(floatIndex);

            var color0 = chemicalColors[lowerBound];
            var color1 = chemicalColors[upperBound];

            var offset = floatIndex - lowerBound;
            return Color.Lerp(color0, color1, offset);
        }
    }
}