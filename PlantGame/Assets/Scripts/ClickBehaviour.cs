using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Permet au joueur de cliquer sur la graine et la parcelle (dans le but de planter ses graines).
/// </summary>

public class ClickBehaviour : MonoBehaviour, IPointerClickHandler
{
    [HideInInspector]
    public static GameObject CurrentPlant;
    [HideInInspector]
    public static int CurrentAmount;
    [SerializeField]
    private InventoryManager _inventoryManager;
    [SerializeField]
    private PlantData _plantData;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (this.CompareTag("Parcelle") && CurrentPlant != null && this.transform.childCount == 0 && CurrentAmount > 0)
        {
            Debug.Log(name);
            var plant = Instantiate(CurrentPlant, this.gameObject.transform, true);
            plant.transform.localPosition = UnityEngine.Vector2.zero;
            var plantData = CurrentPlant.GetComponent<SeedCount>()._plantData;
            _inventoryManager.m_Plants[plantData]--;
            CurrentAmount--;
            Destroy(plant.GetComponent<Image>());
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
