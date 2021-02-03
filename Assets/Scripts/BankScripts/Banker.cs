using UnityEngine;

public class Banker : MonoBehaviour
{
    [Header("Properties")]
    public float speed;
    public float damage;
    [Space]
    public LayerMask layer;

    private Vector2 movement;

    private bool attackMode;
    private float timer;

    void Start()
    {
        attackMode = false;
    }

    private void FixedUpdate()
    {
        if (attackMode == false)
        {
            movement = new Vector2(1 * 2, -3);

            movement *= Time.fixedDeltaTime;

            transform.Translate(movement);
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 1, layer);

        Debug.DrawRay(transform.position, Vector2.right * 1, Color.red);

        if (hit.collider != null)
        {
            if (hit.collider.tag == ("Zombie") || hit.collider.tag == ("Homebase"))
            {
                Attack(hit.collider.gameObject);
            }
            else
            {
                attackMode = false;
            }
        }

    }

    void Attack(GameObject enemy)
    {
        attackMode = true;

        timer += Time.deltaTime;

        if (timer >= 2 && attackMode == true)
        {
            enemy.GetComponent<Health>().ModifyHealth(damage);

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
