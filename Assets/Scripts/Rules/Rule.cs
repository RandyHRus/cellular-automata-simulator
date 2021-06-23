using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule
{
    private List<NumberPair> alivePercentages;
    
    public Rule(List<NumberPair> alivePercentages)
    {
        this.alivePercentages = alivePercentages;
    }

    public float GetNextGenerationValue(float neighboursFraction)
    {
        foreach (var pair in alivePercentages)
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
    public readonly float start, end;
    
    public NumberPair(float start, float end)
    {
        this.start = start;
        this.end = end;
    }
}
