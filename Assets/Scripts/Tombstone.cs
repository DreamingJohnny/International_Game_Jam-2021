using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tombstone : MonoBehaviour
{
    [Header("Properties")]
    public float tombstoneTime;

    [Header("References")]
    public TMP_Text displayTimer;
    public TMP_Text pressE;
    [Space]
    public GameObject zombie;

    private bool canCount;
    private bool inCollider;
    private float timer;

    void Start()
    {
        displayTimer.gameObject.SetActive(false);
        pressE.gameObject.SetActive(false);

        timer = tombstoneTime;

        canCount = false;
    }

    void Update()
    {
        CheckInput();

        if (canCount == true)
        {
            timer -= Time.deltaTime;

            displayTimer.text = timer.ToString("0") + "s";

            if (timer <= 0)
            {
                Instantiate(zombie, transform.position, Quaternion.identity);

                displayTimer.gameObject.SetActive(false);

                timer = tombstoneTime;

                canCount = false;
            }
        }
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.E) && inCollider == true)
        {
            StartTombstone();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inCollider = true;

            if (canCount == false)
            {
                pressE.gameObject.SetActive(true);
            }
            else
            {
                pressE.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inCollider = false;

            pressE.gameObject.SetActive(false);
        }
    }

    private void StartTombstone()
    {
        displayTimer.gameObject.SetActive(true);
        pressE.gameObject.SetActive(false);

        canCount = true;
    }

}
