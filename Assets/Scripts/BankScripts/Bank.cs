using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    //Might want to offset that tick so it gets slower when bank is damaged.

    public float timeBetweenWaves;        // The amount of time between each wave.
    public float currentTime;
    public float bankerSpacing = 1f;   //spacing between the different bankers as they spawn.

    public int amountInWave;        //Starting number of bankers per wave, increase 


    public Banker[] bankersWave;
    public GameObject banker;

    private void Start()
    {
    }

    void Update()
    {

        if (currentTime > timeBetweenWaves)
        {
            StartCoroutine(SpawnWave());
            currentTime = 0;

            amountInWave++;
        }
        else
        {
            currentTime += Time.deltaTime;

            currentTime = Mathf.Clamp(currentTime, 0f, Mathf.Infinity);
        }
    }

    IEnumerator SpawnWave()
    {
        bankersWave = new Banker[amountInWave];

        for (int i = 0; i < bankersWave.Length; i++)
        {
            SpawnEnemy();

            yield return new WaitForSeconds(bankerSpacing);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(banker, transform.position, Quaternion.identity);
    }
}