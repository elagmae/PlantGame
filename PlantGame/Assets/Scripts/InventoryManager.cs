using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gère l'inventaire du joueur selon ses achats.
/// </summary>

public class InventoryManager : MonoBehaviour
{
    public Dictionary<PlantData, int> m_Plants = new Dictionary<PlantData, int>(); 

    public void Bought(PlantData _plantData)
    {
        if (m_Plants.ContainsKey(_plantData))
        {
            m_Plants[_plantData]++;
        }
        else
        {
            m_Plants.Add(_plantData, 1);
        }
    }
}
