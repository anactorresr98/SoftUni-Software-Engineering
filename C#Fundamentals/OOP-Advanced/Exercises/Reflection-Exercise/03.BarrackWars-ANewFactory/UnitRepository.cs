﻿using System;
using System.Collections.Generic;
using System.Text;

public class UnitRepository : IRepository
{
    private readonly IDictionary<string, int> amountOfUnits;

    public UnitRepository()
    {
        this.amountOfUnits = new SortedDictionary<string, int>();
    }

    public string Statistics
    {
        get
        {
            StringBuilder statBuilder = new StringBuilder();

            foreach (KeyValuePair<string, int> entry in this.amountOfUnits)
            {
                string formatedEntry = $"{entry.Key} -> {entry.Value}";
                statBuilder.AppendLine(formatedEntry);
            }

            return statBuilder.ToString().Trim();
        }
    }

    public void AddUnit(IUnit unit)
    {
        string unitType = unit.GetType().Name;

        if (!this.amountOfUnits.ContainsKey(unitType))
        {
            this.amountOfUnits.Add(unitType, 0);
        }

        this.amountOfUnits[unitType]++;
    }

    public void RemoveUnit(string unitType)
    {
        if (this.amountOfUnits.ContainsKey(unitType) && this.amountOfUnits[unitType] > 0)
        {
            this.amountOfUnits[unitType]--;
        }
        else
        {
            throw new ArgumentException("No such units in repository.");
        }
    }
}