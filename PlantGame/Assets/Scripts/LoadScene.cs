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
        SceneManager.LoadScene(sceneName);
        DontDestroyOnLoad(_audioManagerMusic);
        DontDestroyOnLoad(_audioManagerButton);
        _audioManagerButton.PlaySound();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
