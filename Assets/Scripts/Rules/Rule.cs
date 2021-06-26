using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Rules
{
    public class Rule
    {
        [JsonProperty] private List<NumberPair> m_AlivePercentages;

        [JsonConstructor]
        public Rule()
        {
            
        }
    
        public Rule(List<NumberPair> alivePercentages)
        {
            this.m_AlivePercentages = alivePercentages;
        }

        public float GetNextGenerationValue(float neighboursFraction)
        {
            foreach (var pair in m_AlivePercentages)
            {
                if (neighboursFraction >= pair.start && neighboursFraction <= pair.end)
                {
                    //TODO: change
                    return 1f;
                }
            }

            return -1f;
        }
    }

    public class NumberPair
    {
        [JsonProperty] public readonly float start, end;

        [JsonConstructor]
        public NumberPair()
        {
            
        }
    
        public NumberPair(float start, float end)
        {
            this.start = start;
            this.end = end;
        }
    }
}