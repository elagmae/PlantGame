using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Permet de changer ou de quitter la scène dans laquelle on est.
/// </summary>

public class LoadScene : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Exit()
    {
        Application.Quit();
    }
}

