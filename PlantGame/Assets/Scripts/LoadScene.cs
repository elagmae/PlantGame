using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Permet de changer ou de quitter la scène dans laquelle on est.
/// </summary>
public class LoadScene : MonoBehaviour
{
    [SerializeField]
    private AudioManager _audioManagerMusic;
    [SerializeField]
    private AudioManager _audioManagerButton;

    public void ChangeScene(string sceneName)
    {
        // change la scène actuelle à la scène de nom sceneName
        SceneManager.LoadScene(sceneName);

        /* Joue et ne détruit pas les sons joués dans le menu au moment du changement de scène
        (musique de fond + sons des boutons au moment du click) */
        DontDestroyOnLoad(_audioManagerMusic);
        DontDestroyOnLoad(_audioManagerButton);
        _audioManagerButton.PlaySound();
    }

    public void Exit()
    {
        // Quitte le jeu (build)
        Application.Quit();
    }
}
