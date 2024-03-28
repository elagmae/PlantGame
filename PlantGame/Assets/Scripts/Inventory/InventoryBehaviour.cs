using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gère l'inventaire du joueur selon ses achats.
/// </summary>
public class InventoryBehaviour : MonoBehaviour
{
    // dictionnaire qui prend en compte les graines disponibles et combien le joueur en possède
    public Dictionary<PlantData, int> DictPlants { get; private set; } = new Dictionary<PlantData, int>();

    // Ajoute une graine à l'inventaire à chaque fois que le joueur en achète une dans le magasin
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
