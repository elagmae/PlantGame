using UnityEngine;

/// <summary>
/// Gère l'implémentation des sons du jeu en code.
/// </summary>
public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;

    // Création du dictionnaire de son
    [SerializeField]
    private SerializedDictionnary<string, AudioClip> _audioClips;

    public static AudioManager Instance { get; private set; }

    public void PlaySound(string audio)
    {
        // joue le son choisi une seule fois
        _audioSource.PlayOneShot(_audioClips[audio]);
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}
