using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Permet au joueur d'acheter une plante (en appuyant sur le bouton dédié à cette même plante).
/// </summary>
public class BuyingBehaviour : MonoBehaviour
{
    // bouton représentant la graine à l'achat
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
        // met en place les éléments d'UI pré-requis
        _priceUI.text = PlantData.PriceBuy.ToString();
        _button.onClick.AddListener(TaskOnClick);
    }

    // Réagir à chaque click du joueur sur une graine à l'achat
    private void TaskOnClick()
    {
        /* Si la graine n'est pas trop chère pour le joueur, il peut alors l'acheter (il perdra
        donc un peu d'argent et se verra attribuer la graine dans son inventaire)*/
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
