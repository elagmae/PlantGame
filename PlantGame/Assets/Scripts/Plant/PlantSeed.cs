using UnityEngine;
using UnityEngine.EventSystems;

public class PlantSeed : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private InventoryBehaviour _inventoryBehaviour;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        /* Si le joueur clique sur une parcelle, que la parcelle est vide, et qu'une graine est
        déjà sélectionnée et possédée */
        if (GetSeed.CurrentPlant != null && this.transform.childCount == 0 && GetSeed.CurrentAmount > 0)
        {
            // le joueur plante sa graine dans la parcelle
            var plant = Instantiate(GetSeed.CurrentPlant.GetComponent<SeedCount>().PlantData.PlantPrefab, this.gameObject.transform);
            plant.transform.localPosition = UnityEngine.Vector2.zero;

            // le joueur perd la graine de son inventaire
            var plantData = GetSeed.CurrentPlant.GetComponent<SeedCount>().PlantData;
            _inventoryBehaviour.DictPlants[plantData]--;
            GetSeed.CurrentAmount--;

            // la plante pousse
            plant.GetComponent<SpriteRenderer>().sortingOrder = 10 - Mathf.CeilToInt(transform.position.y);
            plant.GetComponent<PlantGrow>().HarvestPlant();
        }
    }
}
