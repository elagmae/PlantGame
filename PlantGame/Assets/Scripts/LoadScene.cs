using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Permet de changer ou de quitter la scène dans laquelle on est.
/// </summary>
public class LoadScene : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        // change la scène actuelle à la scène de nom sceneName
        SceneManager.LoadScene(sceneName);

        /* Joue et ne détruit pas les sons joués dans le menu au moment du changement de scène
        (musique de fond + sons des boutons au moment du click) */
        AudioManager.Instance.PlaySound("clicked");
    }

    public void Exit()
    {
        // Quitte le jeu (build)
        Application.Quit();
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
