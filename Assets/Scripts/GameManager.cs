using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Canvas mainMenuCanvas;
    public Canvas gamePlayCanvas;
    public Canvas winCanvas;
    public Canvas gameOverCanvas;

    private void Start()
    {
        mainMenuCanvas.enabled = false;

        gameOverCanvas.enabled = false;
        
        gamePlayCanvas.enabled = true;

        winCanvas.enabled = false;
    }

    public void LoseGame()
    {
        gamePlayCanvas.enabled = false;

        gameOverCanvas.enabled = true;

        Debug.Log("Your farm was destroyed!");
    }

    public void StartGame()
    {
        mainMenuCanvas.enabled = false;

        gamePlayCanvas.enabled = true;
    }

    public void GotoMainMenu()
    {
        gamePlayCanvas.enabled = false;

        mainMenuCanvas.enabled = true;
    }

    public void WinGame()
    {
        Debug.Log("Bank Destroyed");

        gamePlayCanvas.enabled = false;

        winCanvas.enabled = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}