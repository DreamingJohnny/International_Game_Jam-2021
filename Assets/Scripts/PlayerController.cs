using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Properties")]
    public float speed = 10;
    public float playerDamage = -20f;

    [Header("References")]
    public SpriteRenderer sprite;

    private float inputX;
    private bool stopMovement = true;

    private float dashCooldown = 0f;
    private float attackCooldown = 0f;

    private Vector2 lookDirection;

    public LayerMask playerMask;
    public LayerMask playerMaskTwo;

    public bool canPlace;

    private void Start()
    {
        canPlace = false;
    }

    void FixedUpdate()
    {
        if (stopMovement == true)
        {
            inputX = Input.GetAxisRaw("Horizontal");
        }

        Vector2 movement = new Vector2(inputX * speed, -3);
        movement *= Time.fixedDeltaTime;


        if (inputX == 1)
        {
            sprite.flipX = false;
            lookDirection = Vector2.right;
        }

        if (inputX == -1)
        {
            sprite.flipX = true;
            lookDirection = Vector2.left;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, lookDirection, 5, playerMask);
        Debug.DrawRay(transform.position, lookDirection * 5, Color.red);

        transform.Translate(movement);


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

        if (Input.GetKeyDown(KeyCode.W) && canPlace == true)
        {
            Collider2D[] collders = Physics2D.OverlapCircleAll(transform.position, 3, playerMaskTwo);
            foreach (var wall in collders)
            {
                wall.gameObject.GetComponent<Walls>().PlaceWall();
            }
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
    }

    public bool GetCanPlace()
    {
        return canPlace;
    }

    public void SetCanPlace(bool canPlaceWall)
    {
        canPlace = canPlaceWall;
    }
}
