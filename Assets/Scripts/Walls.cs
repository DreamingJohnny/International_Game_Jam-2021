using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    public GameObject wall;
    private PlayerController pControl;
    private bool isWallPlaced;

    void Start()
    {
        wall.SetActive(false);
        pControl = FindObjectOfType<PlayerController>();
        isWallPlaced = false;
    }

    void Update()
    {
        if (!wall.activeSelf)
        {
            isWallPlaced = false;
        }
    }

    public void PlaceWall()
    {
        if (isWallPlaced == false)
        {
            wall.SetActive(true);
            isWallPlaced = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pControl.GetCanPlace();
        pControl.SetCanPlace(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pControl.GetCanPlace();
        pControl.SetCanPlace(false);
    }
}
