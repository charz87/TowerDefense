using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToload = "Main";
    public void PlayGame()
    {
        Debug.Log("Play");
        SceneManager.LoadScene(levelToload);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
