using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Joue le son voulu quand le bouton contenant le script est survolé par le joueur.
/// </summary>
public class SoundHandlerUI : MonoBehaviour, IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData pointerData)
    {
        AudioManager.Instance.PlaySound("highlighted");
    }
}
