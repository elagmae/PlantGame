using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Permet au joueur d'acheter une plante (en appuyant sur le bouton dédié à cette même plante).
/// </summary>

public class BuyingBehaviour : MonoBehaviour
{
    public PlantData _plantData;
    [SerializeField]
    private Button _button;
    [SerializeField]
    private InventoryManager _inventoryManager;
    [SerializeField]
    private TextMeshProUGUI _priceUI;

    private void Start()
    {
        _priceUI.text = _plantData.PriceBuy.ToString();
        _button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (MoneyManager.Instance._money >= _plantData.PriceBuy)
        {
            MoneyManager.Instance.Depense(_plantData.PriceBuy);
            _inventoryManager.Bought(_plantData);
        }
    }

}
