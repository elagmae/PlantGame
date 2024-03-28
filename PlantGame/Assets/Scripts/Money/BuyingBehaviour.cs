using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Permet au joueur d'acheter une plante (en appuyant sur le bouton dédié à cette même plante).
/// </summary>
public class BuyingBehaviour : MonoBehaviour
{
    [SerializeField]
    private Button _button;
    [SerializeField]
    private InventoryBehaviour _inventoryBehaviour;
    [SerializeField]
    private TextMeshProUGUI _priceUI;
    [SerializeField]
    private AudioManager _audioManagerPick;
    [SerializeField]
    private AudioManager _audioManagerCantpick;

    [field : SerializeField]
    public PlantData PlantData { get; private set; }

    private void Start()
    {
        _priceUI.text = PlantData.PriceBuy.ToString();
        _button.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        if (MoneyManager.Instance.Money >= PlantData.PriceBuy)
        {
            _audioManagerPick.PlaySound();
            MoneyManager.Instance.Depense(PlantData.PriceBuy);
            _inventoryBehaviour.Bought(PlantData);
        }
        else if (MoneyManager.Instance.Money < PlantData.PriceBuy)
        {
            _audioManagerCantpick.PlaySound();
        }
    }
}
