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
    private InventoryManager _inventoryManager;

    [field: SerializeField]
    public PlantData PlantData { get; private set; }

    public void Possess()
    {
        if (this.PlantData == _buyingBehaviour.PlantData && _inventoryManager.DictPlants.ContainsKey(PlantData))
        {
            var plantPossess = GetComponentInChildren<TextMeshProUGUI>();
            plantPossess.text = _inventoryManager.DictPlants[PlantData].ToString();
        }
    }

    private void Update()
    {
        Possess();
    }
}
