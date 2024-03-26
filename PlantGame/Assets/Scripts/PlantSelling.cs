using UnityEngine;
using UnityEngine.EventSystems;

public class PlantSelling : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private PlantData _plantData;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        var _plant = this.GetComponent<PlantGrow>();
        if (_plant.HasGrew)
        {
            MoneyManager.Instance.Sell(_plantData.Price);
            Destroy(_plant.gameObject);
        }
    }
}
