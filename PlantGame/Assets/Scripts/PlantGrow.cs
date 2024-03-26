using System.Collections;
using UnityEngine;

public class PlantGrow : MonoBehaviour
{    
    [SerializeField]
    private PlantData _plantData;
    [SerializeField]
    private SpriteRenderer _sprite;

    public void PlantSeed()
    {
        StartCoroutine(Grow());
    }

    IEnumerator Grow()
    {
        Debug.Log("attend stp");
        yield return new WaitForSeconds(_plantData.Time);
        _sprite.color = Color.white;
        MoneyManager.Instance.Sell(_plantData.Price);
    }
}
