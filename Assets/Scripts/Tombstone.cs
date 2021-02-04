using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tombstone : MonoBehaviour
{
    [Header("Properties")]
    public float tombstoneTime;
    public int spawnPrice;

    [Header("References")]
    public TMP_Text displayTimer;
    public TMP_Text pressE;
    [Space]
    public GameObject zombie;
    public GameObject graveDigger;

    private bool canCount;
    private bool inCollider;
    private float timer;

    void Start()
    {
        displayTimer.gameObject.SetActive(false);
        pressE.gameObject.SetActive(false);
        graveDigger.SetActive(false);

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
                Instantiate(zombie, transform.position + new Vector3(0, -2.4f, 0), Quaternion.identity);

                displayTimer.gameObject.SetActive(false);
                graveDigger.SetActive(false);

                timer = tombstoneTime;

                canCount = false;
            }
        }
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.E) && inCollider == true && CurrencyManager.Instance.Currency >= spawnPrice && canCount == false)
        {
            CurrencyManager.Instance.ModifyCurrency(-spawnPrice);

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
        graveDigger.SetActive(true);
        displayTimer.gameObject.SetActive(true);
        pressE.gameObject.SetActive(false);

        canCount = true;
    }
}
