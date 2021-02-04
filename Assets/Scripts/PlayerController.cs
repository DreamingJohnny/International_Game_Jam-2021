using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Properties")]
    public float speed = 10;

    [Header("References")]
    public SpriteRenderer sprite;

    private float inputX;
    private bool stopMovement = true;

    private float dashCooldown = 0f;
    private float attackCooldown = 0f;

    public float playerDamage = -20f;

    public LayerMask playerMask;

    private void Start()
    {

    }

    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 5, playerMask);
        Debug.DrawRay(transform.position, Vector2.left * 5, Color.red);

        if (stopMovement == true)
        {
            inputX = Input.GetAxisRaw("Horizontal");
        }

        Vector2 movement = new Vector2(inputX * speed, -3);
        movement *= Time.fixedDeltaTime;

        if (inputX == 1)
        {
            sprite.flipX = false;
        }

        if (inputX == -1)
        {
            sprite.flipX = true;
        }

        transform.Translate(movement);

        //Debug.Log(attackCooldown.ToString());
               

        if (Input.GetKey(KeyCode.Space) && attackCooldown <= 0f)
        {
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Enemy")
                {                    
                    Attack(hit.collider.gameObject);
                }
            }
        }
    }

    private void Update()
    {
        if (dashCooldown >= 0f)
        {
            dashCooldown = dashCooldown - Time.deltaTime;
        }

        if (attackCooldown >= 0f)
        {
            attackCooldown = attackCooldown - Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.S) && dashCooldown <= 0f)
        {
            StartCoroutine(DashTime());
        }
    }

    IEnumerator DashTime()
    {
        dashCooldown = 1.2f;
        speed = speed + 20f;
        stopMovement = false;
        yield return new WaitForSeconds(0.2f);
        stopMovement = true;
        speed = speed - 20f;
    }

    private void Attack(GameObject enemy)
    {
        attackCooldown = 3f;
        enemy.GetComponent<Health>().ModifyHealth(playerDamage);
        Debug.Log(enemy.GetComponent<Health>().ToString());
    }

    private void PlaceWall()
    {

    }
}
