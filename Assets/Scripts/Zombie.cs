using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private Vector2 movement;
    private bool attackMode;
    private float timer;
    private float attackTime;
    private float direction;
    private float lengthOfWalk;

    void Start()
    {
        //StartCoroutine(ZombieWander());
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 8);

        Debug.DrawRay(transform.position, Vector2.left * 8, Color.red);

        if (hit.collider.CompareTag("Enemy"))
        {
            Attack(hit.collider.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (attackMode == false)
        {
            movement = new Vector2(-1 * 2, -3);

            movement *= Time.fixedDeltaTime;

            transform.Translate(movement);
        }
    }

    private void Attack(GameObject enemy)
    {
        attackMode = true;

        timer += Time.deltaTime;

        if (timer <= 2)
        {
            enemy.GetComponent<Health>().ModifyHealth(-10);

            // animation of attack

            timer = 0;
        }
    }

    //private IEnumerator ZombieWander()
    //{
    //    direction = Random.Range(-1, 2);
    //    lengthOfWalk = Random.Range(3, 7);

    //    Debug.Log("Walking Time this cycle: " + lengthOfWalk);
    //    Debug.Log("Direction this cycle: " + direction);

    //    if (direction == 0)
    //    {
    //        lengthOfWalk = 3;
    //    }

    //    yield return new WaitForSeconds(lengthOfWalk);

    //    StartCoroutine(ZombieWander());
    //}
}
