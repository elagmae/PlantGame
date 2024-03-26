using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Retire de l'argent au joueur si celui-ci ach�te une plante (en appuyant sur le bouton d�di� � cette m�me plante
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
