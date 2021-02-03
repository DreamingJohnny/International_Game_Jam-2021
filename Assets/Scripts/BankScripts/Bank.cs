using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{

        //Needs to produce bankers at certain ticks,
        //Might want to offset that tick so it gets slower when bank is damaged.

        public float waveTime;        // The amount of time between each spawn.
        public float currentTime;

        public GameObject banker;

    void Update()
    {
        currentTime += Time.deltaTime;

        if ( currentTime >= waveTime )
        {
            Instantiate(banker, transform.position, Quaternion.identity);
            
            currentTime = 0;
        }

    }
}