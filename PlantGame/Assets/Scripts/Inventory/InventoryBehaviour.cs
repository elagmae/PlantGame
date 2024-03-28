using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gère l'inventaire du joueur selon ses achats.
/// </summary>
public class InventoryBehaviour : MonoBehaviour
{
    public Dictionary<PlantData, int> DictPlants { get; private set; } = new Dictionary<PlantData, int>();

    public void Bought(PlantData plantData)
    {
        if (DictPlants.ContainsKey(plantData))
        {
            DictPlants[plantData]++;
        }
        else
        {
            DictPlants.Add(plantData, 1);
        }
    }
}
