using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Properties")]
    public int startingAmount;

    void Start()
    {
        CurrencyManager.Instance.ModifyCurrency(startingAmount);
    }

    public void LoseGame()
    {

        Debug.Log("Your farm was destroyed!");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void WinGame()
    {
        Debug.Log("Bank Destroyed");
    }
}
