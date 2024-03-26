using System.Collections;
using UnityEngine;

/// <summary>
/// Permet aux graines de se transformer en plantes apr�s un temps donn�.
/// </summary>

public class PlantGrow : MonoBehaviour
{    
    [SerializeField]
    private PlantData _plantData;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    public bool HasGrew { get; private set; } = false;

    public void PlantSeed()
    {
        StartCoroutine(Grow());
    }

    IEnumerator Grow()
    {
        transform.localScale = Vector3.one;
        yield return new WaitForSeconds(_plantData.Time);
        _spriteRenderer.sprite = _plantData.PlantSprite;
        HasGrew = true;
    }
}