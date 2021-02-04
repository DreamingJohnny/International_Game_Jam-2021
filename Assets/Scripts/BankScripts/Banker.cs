using UnityEngine;
using System.Collections;

public class Banker : MonoBehaviour
{
    [Header("Properties")]
    public bool attackMode;
    [Space]
    public float speed;
    public float damage;
    [Space]
    public LayerMask layer;

    private Vector2 movement;

    private float timer;
    private bool doneOnce;

    void Start()
    {
        doneOnce = false;
        attackMode = false;
    }

    private void FixedUpdate()
    {
        if (attackMode == false)
        {
            movement = new Vector2(1 * speed, -3);

            movement *= Time.fixedDeltaTime;

            transform.Translate(movement);
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 1, layer);

        Debug.DrawRay(transform.position, Vector2.right * 1, Color.red);

        if (hit.collider != null)
        {
            Attack(hit.collider.gameObject);                     
        }
        else
        {
            if (doneOnce == false)
            {
                StartWalking();
            }

        }
    }
    private void Attack(GameObject enemy)
    {
        attackMode = true;
        doneOnce = false;

        timer += Time.deltaTime;

        if (timer >= 2 && attackMode == true)
        {
            enemy.GetComponent<Health>().ModifyHealth(-10);

            if (!enemy.gameObject.activeSelf)
            {
                if (doneOnce == true)
                {
                    StartWalking();
                }
            }

            // animation of attack

            timer = 0;
        }
    }

    void StartWalking()
    {
        attackMode = false;
        StartCoroutine(ZombieWalkDelay());

        doneOnce = true;
    }

    private IEnumerator ZombieWalkDelay()
    {
        float tempNumber = Random.Range(0.0f, 1.5f);
        yield return new WaitForSeconds(tempNumber);
        print(tempNumber);

    }
}

