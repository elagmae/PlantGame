using System.Collections;
using UnityEngine;

/// <summary>
/// Permet aux graines de se transformer en plantes après un temps donné.
/// </summary>
public class PlantGrow : MonoBehaviour
{
    [SerializeField]
    private PlantData _plantData;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    public bool HasGrew { get; private set; } = false;

    public void HarvestPlant()
    {
        StartCoroutine(Grow());
    }

    // permet à la plante de grandir une fois plantée selon un temps donné (cf. scriptable object)
    public IEnumerator Grow()
    {
        transform.localScale = Vector3.one;
        yield return new WaitForSeconds(_plantData.Time);
        _spriteRenderer.sprite = _plantData.PlantSprite;
        AudioManager.Instance.PlaySound("grown");
        HasGrew = true;
    }
}
