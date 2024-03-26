using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Retire de l'argent au joueur si celui-ci achète une plante (en appuyant sur le bouton dédié à cette même plante
/// </summary>

public class BuyingBehaviour : MonoBehaviour
{
    public PlantData _plantData;
    [SerializeField]
    private Button _button;
    [SerializeField]
    private InventoryManager _inventoryManager;


    private void Start()
    {
        _button.onClick.AddListener(TaskOnClick); 
    }

    void TaskOnClick()
    {
        MoneyManager.Instance.Depense(_plantData.Price);
        _inventoryManager.Bought(_plantData);
    }

}
