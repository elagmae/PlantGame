using UnityEngine;

[CreateAssetMenu(fileName = "Plants", menuName = "PlantGame/Plants", order = 1)]
public class PlantData : ScriptableObject
{

    [field:SerializeField]
    public float Price {get; private set;}
    [field: SerializeField]
    public float Time {get; private set;}

    [field: SerializeField]
    public Sprite PlantSprite { get; private set; }

    [field: SerializeField]
    public string Name { get; private set; }

}
