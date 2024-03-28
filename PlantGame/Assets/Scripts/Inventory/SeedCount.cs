using TMPro;
using UnityEngine;

/// <summary>
/// Compte le nombre de graines possédées par le joueur.
/// </summary>
public class SeedCount : MonoBehaviour
{
    [SerializeField]
    private BuyingBehaviour _buyingBehaviour;
    [SerializeField]
    private InventoryBehaviour _inventoryBehaviour;

    [field: SerializeField]
    public PlantData PlantData { get; private set; }

    // prend les infos de l'inventaire (nombre de graines possédées) et les retranscrit en UI
    public void Possess()
    {
        if (this.PlantData == _buyingBehaviour.PlantData && _inventoryBehaviour.DictPlants.ContainsKey(PlantData))
        {
            var plantPossess = GetComponentInChildren<TextMeshProUGUI>();
            plantPossess.text = _inventoryBehaviour.DictPlants[PlantData].ToString();
        }
    }

    private void Update()
    {
        Possess();
    }
}
