using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Walls : MonoBehaviour
{
    private GameObject wall;
    private PlayerController pControl;
    private bool isWallPlaced;
    public TMP_Text pressW;

    private bool inCollider;
    public GameObject healthBar;

    void Start()
    {
        wall = GetComponentInChildren<Health>().gameObject;
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
        if (isWallPlaced == false)
        {
            pressW.gameObject.SetActive(false);
            healthBar.SetActive(true);
            wall.SetActive(true);
            isWallPlaced = true;
            GetComponentInChildren<Health>().ResetHealth();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pControl.GetCanPlace();
        pControl.SetCanPlace(true);

        if (collision.CompareTag("Player"))
        {
            inCollider = true;
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
            inCollider = false;

            pressW.gameObject.SetActive(false);
        }
    }
}
