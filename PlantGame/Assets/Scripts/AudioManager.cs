using UnityEngine;

/// <summary>
/// Gère l'implémentation des sons du jeu en code.
/// </summary>
public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _audioClip;

    public void PlaySound()
    {
        // joue le son choisi une seule fois
        _audioSource.PlayOneShot(_audioClip);
    }
}
