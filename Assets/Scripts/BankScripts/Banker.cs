using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banker : MonoBehaviour
{
    GameObject banker;

    public float speed = 10;
    public Vector2 movement;

    public float damage;

    public bool isAttacked;


    void Start()
    {
        movement = new Vector2(speed, 0);

        isAttacked = false;
    }

void Update()
    {
        //If not impacted by zombie, moves towards goal.
        Move();

        //If impacted by zombie/as in close by zombie, stands still & attacks zombie.
        Attacking();

        //
        //
    }

    void Move()
    {
        if(!isAttacked)
        {
            transform.Translate(movement * Time.deltaTime);
        }
    }

    void Attacking()
    {

        //First, check if within range of homestead/building. If they are, then attack that.
        //Otherwise, next step is to check if within reach of zombies,
        //If they are, attack zombies,
        //In either of these cases, change (is attacking bool).

        //else... just move.
        //this should throw/change bool for enemies aswell, best if used by/on other script, as component, both zombies and bankers may use the same script after all.
    }
}
