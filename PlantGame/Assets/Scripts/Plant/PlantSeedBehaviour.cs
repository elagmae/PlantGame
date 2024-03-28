using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Permet au joueur de planter ses graines sur les parcelles proposées.
/// </summary>
public class PlantSeedBehaviour : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private InventoryBehaviour _inventoryBehaviour;
    [SerializeField]
    private PlantData _plantData;
    [SerializeField]
    private AudioManager _audioManagerPick;
    [SerializeField]
    private AudioManager _audioManagerUnpick;

    // game object d'abord vide, qui se remplira avec les données de la graine cliquée
    public static GameObject CurrentPlant { get; private set; }

    // prend en compte le nombre de graines possédées par rapport au type cliqué par le joueur
    public static int CurrentAmount { get; private set; }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        /* Si le joueur clique sur une parcelle, que la parcelle est vide, et qu'une graine est
        déjà sélectionnée et possédée */
        if (this.CompareTag("Parcelle") && CurrentPlant != null && this.transform.childCount == 0 && CurrentAmount > 0)
        {
            // le joueur plante sa graine dans la parcelle
            var plant = Instantiate(CurrentPlant.GetComponent<SeedCount>().PlantData.PlantPrefab, this.gameObject.transform);
            plant.transform.localPosition = UnityEngine.Vector2.zero;

            // le joueur perd la graine de son inventaire
            var plantData = CurrentPlant.GetComponent<SeedCount>().PlantData;
            _inventoryBehaviour.DictPlants[plantData]--;
            CurrentAmount--;

            // la plante pousse
            plant.GetComponent<SpriteRenderer>().sortingOrder = 10 - Mathf.CeilToInt(transform.position.y);
            plant.GetComponent<PlantGrow>().HarvestPlant();
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
                possède assez afin de la planter au prochain click */
                CurrentAmount = _inventoryBehaviour.DictPlants[_plantData];

                if (CurrentAmount > 0)
                {
                    _audioManagerPick.PlaySound();
                }
                else if (CurrentAmount == 0)
                {
                    _audioManagerUnpick.PlaySound();
                }
            }
            catch (KeyNotFoundException)
            {
                _audioManagerUnpick.PlaySound();
            }
        }
    }
}
