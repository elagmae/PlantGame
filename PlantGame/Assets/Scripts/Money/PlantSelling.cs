using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Permet au joueur de vendre ses plantes.
/// </summary>

public class PlantSelling : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private PlantData _plantData;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        var _plant = this.GetComponent<PlantGrow>();
        if (_plant.HasGrew)
        {
            MoneyManager.Instance.Sell(_plantData.PriceSell);
            Destroy(_plant.gameObject);
        }
    }
}
