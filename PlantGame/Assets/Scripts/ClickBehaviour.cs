using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Permet au joueur de planter ses graines sur les parcelles proposées.
/// </summary>

public class ClickBehaviour : MonoBehaviour, IPointerClickHandler
{
    [HideInInspector]
    public static GameObject CurrentPlant { get; private set; }
    [HideInInspector]
    public static int CurrentAmount { get; private set; }
    [SerializeField]
    private InventoryManager _inventoryManager;
    [SerializeField]
    private PlantData _plantData;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (this.CompareTag("Parcelle") && CurrentPlant != null && this.transform.childCount == 0 && CurrentAmount > 0)
        {
            var plant = Instantiate(CurrentPlant, this.gameObject.transform, true);
            plant.transform.localPosition = UnityEngine.Vector2.zero;

            var plantData = CurrentPlant.GetComponent<SeedCount>()._plantData;
            _inventoryManager.m_Plants[plantData]--;
            CurrentAmount--;

            plant.GetComponent<SpriteRenderer>().sortingOrder = 10 - Mathf.CeilToInt(transform.position.y);

            Destroy(plant.GetComponent<Image>());
            Destroy(plant.GetComponent<CanvasRenderer>());
            plant.GetComponent<PlantGrow>().PlantSeed();
        }

        else if (!this.CompareTag("Parcelle"))
        {
            try
            {
                CurrentPlant = this.gameObject;
                CurrentAmount = _inventoryManager.m_Plants[_plantData];
            }
            catch(KeyNotFoundException e)
            {
            }
        }
    }
}
