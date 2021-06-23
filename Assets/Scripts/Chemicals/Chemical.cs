using UnityEngine;

namespace Chemicals
{
    public class Chemical
    {
        public ChemicalColors chemicalColors { get; private set; }
        public Rule m_Rule { get; private set; }

        public Chemical(ChemicalColors chemicalColors, Rule rule)
        {
            this.chemicalColors = chemicalColors;
            this.m_Rule = rule;
        }
    }
}