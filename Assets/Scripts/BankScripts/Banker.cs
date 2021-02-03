using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banker : MonoBehaviour
{
    public float speed = 10;
    private Vector2 movement;

    public float damage;

    private bool attackMode;
    private float timer;

    public LayerMask layer;


    void Start()
    {
        attackMode = false;
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 2, layer);

        Debug.DrawRay(transform.position, Vector2.right * 2, Color.red);

        if (hit.collider != null)
        {
            if (hit.collider.tag == ("Zombie"))
            {
                Attack(hit.collider.gameObject);
            }
        }

        if (attackMode == false)
        {
            movement = new Vector2(1 * 2, -3);

            movement *= Time.fixedDeltaTime;

            transform.Translate(movement);
        }
    }

    void Attack(GameObject enemy)
    {
        attackMode = true;

        timer += Time.deltaTime;

        if (timer >= 2 && attackMode == true)
        {
            enemy.GetComponent<Health>().ModifyHealth(-10);

            if (!enemy.gameObject.activeSelf)
            {
                attackMode = false;
            }

            // animation of attack

            timer = 0;
        }

        //First, check if within range of homestead/building. If they are, then attack that.
        //Otherwise, next step is to check if within reach of zombies,
        //If they are, attack zombies,
        //In either of these cases, change (is attacking bool).

        //else... just move.
        //this should throw/change bool for enemies aswell, best if used by/on other script, as component, both zombies and bankers may use the same script after all.
    }
}
