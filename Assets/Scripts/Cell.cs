using System;
using System.Collections;
using System.Collections.Generic;
using Chemicals;
using UnityEngine;

public class Cell
{
    //0 to 1, 0 means dead
    public readonly float value;
    public readonly Chemical chemical;

    public Cell(Chemical chemical, float value)
    {
        if (value < 0 || value > 1)
        {
            throw new System.Exception("Invalid value");
        }

        if (chemical != null && value == 0)
        {
            throw new System.Exception("got value 0 but chemical is not null");
        }
        
        this.value = value;
        this.chemical = chemical;
    }

    public Color GetCellColor()
    {
        if (chemical == null)
        {
            return Color.white;
        }
        else
        {
            return chemical.chemicalColors.GetColor(value);
        }
    }
}
