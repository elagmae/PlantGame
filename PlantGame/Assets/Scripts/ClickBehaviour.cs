using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Permet au joueur de planter ses graines sur les parcelles proposées.
/// </summary>
public class ClickBehaviour : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private InventoryManager _inventoryManager;
    [SerializeField]
    private PlantData _plantData;

    // game object d'abord vide, qui se remplira avec les données de la graine cliquée
    public static GameObject CurrentPlant { get; private set; }

    public static int CurrentAmount { get; private set; }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        /*Si le joueur clique sur une parcelle, que la parcelle est vide, et qu'une graine est
        déjà sélectionnée et possédée*/
        if (this.CompareTag("Parcelle") && CurrentPlant != null && this.transform.childCount == 0 && CurrentAmount > 0)
        {
            // le joueur plante sa graine dans la parcelle
            var plant = Instantiate(CurrentPlant.GetComponent<SeedCount>().PlantData.PlantPrefab, this.gameObject.transform);
            plant.transform.localPosition = UnityEngine.Vector2.zero;

            // le joueur perd la graine de son inventaire
            var plantData = CurrentPlant.GetComponent<SeedCount>().PlantData;
            _inventoryManager.DictPlants[plantData]--;
            CurrentAmount--;

            // la plannte pousse
            plant.GetComponent<SpriteRenderer>().sortingOrder = 10 - Mathf.CeilToInt(transform.position.y);
            plant.GetComponent<PlantGrow>().PlantSeed();
        }

        // Si le joueur clique sur une graine
        else if (!this.CompareTag("Parcelle"))
        {
            // empêche une potentielle erreur si le joueur clique sur la parcelle avant la graine
            try
            {
                // on stocke la graine pour pouvoir la planter au prochain clique sur une parcelle
                CurrentPlant = this.gameObject;

                /* on prend en compte le nombre de graine du type cliqué pour savoir si on en
                possède assez afin de la planter au prochain click*/
                CurrentAmount = _inventoryManager.DictPlants[_plantData];
            }
            catch (KeyNotFoundException)
            {
            }
        }
    }
}
