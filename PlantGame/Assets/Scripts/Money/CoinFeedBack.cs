using DG.Tweening;
using UnityEngine;

/// <summary>
/// Gère l'animation de l'argent gagné après la récolte.
/// </summary>
public class CoinFeedback : MonoBehaviour
{
    public void CoinMovement()
    {
        this.transform.position = this.transform.position;

        // déplace l'argent vers le coin en haut à droite de l'écran (soit vers l'argent du joueur)
        var pos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width - 30.0f, Screen.height - 30.0f));
        this.transform.DOMove(pos, 1.0f);

        // attend la fin de la ligne avant de continuer
        this.transform.DOScale(new Vector3(1.2f, 1.2f, 1.0f), 1.0f).onComplete += () =>
        {
            Destroy(this.gameObject);
        };
    }
}
