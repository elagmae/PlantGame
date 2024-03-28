using UnityEngine;

[CreateAssetMenu(fileName = "Plants", menuName = "PlantGame/Plants", order = 1)]
public class PlantData : ScriptableObject
{
    // Prix à l'achat de la graine
    [field:SerializeField]
    public float PriceBuy { get; private set; }

    // Prix à la vente de la graine
    [field: SerializeField]
    public float PriceSell { get; private set; }

    // Temps de pousse de la graine
    [field: SerializeField]
    public float Time { get; private set; }

    // Sprite de la plante (post-pousse)
    [field: SerializeField]
    public Sprite PlantSprite { get; private set; }

    // Nom de la plante
    [field: SerializeField]
    public string Name { get; private set; }

    // Prefab de la plante (pré-pousse)
    [field : SerializeField]
    public GameObject PlantPrefab { get; private set; }
}
