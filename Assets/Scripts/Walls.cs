using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Walls : MonoBehaviour
{
    [Header("Properties")]
    public int buildPrice;

    [Header("References")]
    public GameObject wall;
    public Health wallHealth;
    public TMP_Text pressW;
    public GameObject healthBar;

    private PlayerController pControl;
    private bool isWallPlaced;


    void Start()
    {
        wall.SetActive(false);
        pressW.gameObject.SetActive(false);
        healthBar.SetActive(false);
        pControl = FindObjectOfType<PlayerController>();
        isWallPlaced = false;
    }

    void Update()
    {
        if (!wall.activeSelf)
        {
            isWallPlaced = false;
            healthBar.SetActive(false);
        }
    }

    public void PlaceWall()
    {
        if (isWallPlaced == false && CurrencyManager.Instance.Currency >= buildPrice)
        {
            pressW.gameObject.SetActive(false);
            healthBar.SetActive(true);
            wall.SetActive(true);
            isWallPlaced = true;
            GetComponentInChildren<Health>().ResetHealth();

            CurrencyManager.Instance.ModifyCurrency(-buildPrice);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pControl.GetCanPlace();
        pControl.SetCanPlace(true);

        if (collision.CompareTag("Player"))
        {
            if (isWallPlaced != true)
            {
                pressW.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pControl.GetCanPlace();
        pControl.SetCanPlace(false);

        if (collision.CompareTag("Player"))
        {
            pressW.gameObject.SetActive(false);
        }
    }
}
