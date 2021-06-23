using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Rules
{
    /*
    public class RuleDecayAndSpread // : IRule
    {
        private readonly float m_DecaySpeed; //Amount to decay every generation
        private readonly float m_SpreadChance; //Chance to spread in each direction

        private static readonly Vector2Int[] SpreadDirections = new Vector2Int[]
        {
            new Vector2Int(0, -1),
            new Vector2Int(0, 1),
            new Vector2Int(1, 0),
            new Vector2Int(-1, 0)
        };

        public RuleDecayAndSpread(float decaySpeed, float spreadChance)
        {
            if (decaySpeed < 0 || decaySpeed > 1)
            {
                throw new SystemException("Invalid value");
            }

            if (spreadChance < 0 || spreadChance > 1)
            {
                throw new System.Exception("Invalid value");
            }

            this.m_DecaySpeed = decaySpeed;
            this.m_SpreadChance = spreadChance;
        }

        public List<Tuple<Vector2Int, Cell>> GetNextGenerationCell(CellsCanvas canvas, Vector2Int coordinate, Cell cell)
        {
            List<Tuple<Vector2Int, Cell>> newCells = new List<Tuple<Vector2Int, Cell>>();

            //Update self
            {
                float proposedValue = cell.value - m_DecaySpeed;

                if (proposedValue > 0)
                {
                    newCells.Add(new Tuple<Vector2Int, Cell>(coordinate, new Cell(cell.chemical, proposedValue)));
                }
            }

            //Spreads
            foreach (Vector2Int dir in SpreadDirections)
            {
                if (UnityEngine.Random.Range(0f, 1f) < m_SpreadChance)
                {
                    Vector2Int newCoordinate = Helpers.GetWrappedCoordinate(coordinate + dir);
                    newCells.Add(new Tuple<Vector2Int, Cell>(newCoordinate, new Cell(cell.chemical, 1)));
                }
            }

            return newCells;
        }

        public List<Tuple<Vector2Int, Cell>> GetNextGenerationCells(CellsCanvas canvas, Vector2Int coordinate,
            Cell cell)
        {
            throw new NotImplementedException();
        }

        public List<Vector2Int> GetAffectCells(CellsCanvas canvas, Vector2Int coordinate)
        {
            throw new NotImplementedException();
        }
    }
    */
}
