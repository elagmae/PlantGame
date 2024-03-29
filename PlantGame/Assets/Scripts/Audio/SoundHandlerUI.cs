using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Joue le son voulu quand le bouton contenant le script est survolé par le joueur.
/// </summary>
public class SoundHandlerUI : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField]
    private AudioManager _audioManagerHighlighted;

    public void OnPointerEnter(PointerEventData pointerData)
    {
        _audioManagerHighlighted.PlaySound();
    }
}
