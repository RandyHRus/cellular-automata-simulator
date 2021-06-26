using Chemicals;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Saving;
using UnityEngine;

namespace Canvas
{
    public class Cell
    {
        //0 to 1, 0 means dead
        [JsonProperty] public readonly float value;
        [JsonIgnore] public Chemical chemical;
        [JsonProperty] public string m_ChemicalGuid;

        [JsonConstructor]
        public Cell()
        {
            
        }

        public Cell(Chemical chemical, float value)
        {
            this.value = value;
            this.chemical = chemical;
            this.m_ChemicalGuid = chemical?.guid;
            
            if (value < 0 || value > 1)
            {
                throw new System.Exception("Invalid value");
            }
            if (chemical != null && value == 0)
            {
                throw new System.Exception("got value 0 but chemical is not null");
            }
        }

        public void InitializeFromGuid()
        {
            chemical = (m_ChemicalGuid == null) ? null : ChemicalManager.GetChemicalWithGuid(m_ChemicalGuid);
        }

        public Color GetCellColor()
        {
            if (chemical == null)
            {
                return Color.white;
            }
            else
            {
                return chemical.GetColor(value);
            }
        }
    }
}
