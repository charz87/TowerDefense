using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static bool isGameEnd;

    public GameObject gameOverUI;
    public GameObject gamePauseUI;
    // Update is called once per frame

    private void Start()
    {
        isGameEnd = false;
    }
    void Update()
    {
        if (isGameEnd)
            return;

        if(PlayerStats.Lives <= 0)
        {
            EndGame();

        }

        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    void EndGame()
    {
        isGameEnd = true;
        gameOverUI.SetActive(true);
        Debug.Log("Game Over");
    }

    public void TogglePause()
    {
        gamePauseUI.SetActive(!gamePauseUI.activeSelf);

        if(gamePauseUI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void RetryPause()
    {
        TogglePause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MenuPause()
    {
        Debug.Log("Go to Menu");
        SceneManager.LoadScene(0);
    }

}
