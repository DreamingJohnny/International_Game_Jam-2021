using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
<<<<<<< Updated upstream
    public Canvas mainMenuCanvas;
    public Canvas gamePlayCanvas;
    public Canvas winCanvas;
    public Canvas gameOverCanvas;
=======
    [Header("Properties")]
    public int startingAmount;

    public GameObject mainMenuCanvas;
    public GameObject gamePlayCanvas;
    public GameObject winCanvas;
    public GameObject gameOverCanvas;
>>>>>>> Stashed changes

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    private void Start()
    {
        CurrencyManager.Instance.ModifyCurrency(startingAmount);

        mainMenuCanvas.SetActive(false);
        
        gameOverCanvas.SetActive(false);
        
        gamePlayCanvas.SetActive(false);

        winCanvas.SetActive(false);

        StartGame();
    }

    public void LoseGame()
    {
        gamePlayCanvas.SetActive(false);

        gameOverCanvas.SetActive(true);
    }

    public void StartGame()
    {
        mainMenuCanvas.SetActive(false);

        gamePlayCanvas.SetActive(true);
    }

    public void GotoMainMenu()
    {
        if(gamePlayCanvas != null)
            gamePlayCanvas.SetActive(false);

        if (winCanvas != null)
            winCanvas.SetActive(false);

        if (gameOverCanvas != null)
            gameOverCanvas.SetActive(false);
        
        if (mainMenuCanvas != null)
            mainMenuCanvas.SetActive(true);
    }

    public void WinGame()
    {
        gamePlayCanvas.SetActive(false);

        winCanvas.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}