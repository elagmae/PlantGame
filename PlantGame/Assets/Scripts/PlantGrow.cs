using System.Collections;
using UnityEngine;

public class PlantGrow : MonoBehaviour
{    
    [SerializeField]
    private PlantData _plantData;
    [SerializeField]
    private SpriteRenderer _sprite;
    public bool HasGrew { get; private set; } = false;


    public void PlantSeed()
    {
        StartCoroutine(Grow());
    }

    IEnumerator Grow()
    {
        Debug.Log("attend stp");
        yield return new WaitForSeconds(_plantData.Time);
        _sprite.color = Color.white;
        HasGrew = true;
    }
}
