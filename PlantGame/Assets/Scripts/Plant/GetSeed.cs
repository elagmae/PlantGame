using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Permet au joueur de planter ses graines sur les parcelles proposées.
/// </summary>
public class GetSeed : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private InventoryBehaviour _inventoryBehaviour;
    [SerializeField]
    private PlantData _plantData;

    // game object d'abord vide, qui se remplira avec les données de la graine cliquée
    public static GameObject CurrentPlant { get; private set; }

    // prend en compte le nombre de graines possédées par rapport au type cliqué par le joueur
    public static int CurrentAmount { get; set; }

    public void OnPointerClick(PointerEventData pointerEventData)
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
                AudioManager.Instance.PlaySound("pick");
            }
            else if (CurrentAmount == 0)
            {
                AudioManager.Instance.PlaySound("unpick");
            }
        }
        catch (KeyNotFoundException)
        {
            AudioManager.Instance.PlaySound("unpick");
        }
    }
}
