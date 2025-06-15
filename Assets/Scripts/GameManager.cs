using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public static GameManager instance;

    void Start()
    {
        instance = this;
        Time.timeScale = 1;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void restartGame()
    {
        SceneManager.LoadScene(1);
    }
}
