using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.VisualStyles;

namespace KosShooter.Items;

public class DropItemSystem
{
    private List<AiItem> possibleItems;
    private List<float> dropChances;

    public DropItemSystem()
    {
        possibleItems = new List<AiItem>();
        dropChances = new List<float>();
    }

    public void AddItem(AiItem item, float dropChance)
    {
        possibleItems.Add(item);
        dropChances.Add(dropChance);
    }

    public AiItem DropItem()
    {
        var random = new Random();
        var totalChance = dropChances.Sum();
        var randomValue = (float)random.NextDouble() * totalChance;
        float cumulativeChance = 0;
        for (var i = 0; i < possibleItems.Count; i++)
        {
            cumulativeChance += dropChances[i];
            if (randomValue < cumulativeChance)
            {
                return possibleItems[i];
            }
        }
        return null;
    }
}